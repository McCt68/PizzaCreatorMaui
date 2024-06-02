using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using PizzaCoreBuisnessLogic.Models;
using PizzaCoreBuisnessLogic.Repositorys;
using PizzaCoreBuisnessLogic.UseCases;
using PizzaCoreBuisnessLogic.UseCases.Interfaces;
using PizzaCreatorMaui.MVVM.ViewModels;
using PizzaCreatorMaui.MVVM.Views;
using System.Collections.ObjectModel;


namespace PizzaCreatorMaui
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            // using for validation in CustomerView Entry's
            builder.UseMauiApp<App>().UseMauiCommunityToolkit();

            /*
             * Configuring Dependency injection.              
             * Dependency injection in the contructor. When ever a object depends on another object -
             * The framework will create it.
             */

            // When any object needs a type of IToppingRepository -
            // the Program will inject the concrete implementation specified here ( ToppingInMemoryRepository )
            // It could also be any other implementation.            
            builder.Services.AddSingleton<IToppingRepository, ToppingInMemoryRepository>();                       
            builder.Services.AddSingleton<IToppingRepository, ToppingWebApiRepository>();

            // Configure Usecases              
            builder.Services.AddTransient<ILoadToppingsUseCase, LoadToppingsUseCase>();
                        
            // Register the ObservableCollection<PizzaSize> as a singleton
            builder.Services.AddSingleton<ObservableCollection<PizzaSize>>(provider =>
            {
                return new ObservableCollection<PizzaSize>
                {
                    new PizzaSize(PizzaSize.Sizes.Small, 35m),
                    new PizzaSize(PizzaSize.Sizes.Medium, 40m),
                    new PizzaSize(PizzaSize.Sizes.Large, 45m)
                };
            });
            
            // Singleton - One Instance througout the lifetime of the app.
            builder.Services.AddSingleton<CreatePizzaViewModel>();                                                
            builder.Services.AddSingleton<CustomerViewModel>(); 
            

            builder.Services.AddSingleton<CreatePizzaView>();
            builder.Services.AddTransient<CustomerView>(); // maybe singleton is better ?


            // Register Routes - DO i need this ?
            Routing.RegisterRoute("customer", typeof(CustomerView));                                                
            
#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
