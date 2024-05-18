using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
// using PizzaCoreBuisnessLogic.Data;
using PizzaCoreBuisnessLogic.Data.DataFactory;
using PizzaCoreBuisnessLogic.Models;
using PizzaCoreBuisnessLogic.Repositorys;
using PizzaCoreBuisnessLogic.UseCases;
using PizzaCoreBuisnessLogic.UseCases.Interfaces;
using PizzaCreatorMaui.MVVM.ViewModels;
using PizzaCreatorMaui.MVVM.Views;


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

            // LOADING TWO REPOSITORIES.
            // This works loading from Memory
            builder.Services.AddSingleton<IToppingRepository, ToppingInMemoryRepository>();
            // Load from Api - This works 
            builder.Services.AddSingleton<IToppingRepository, ToppingWebApiRepository>();





            // Configure Usecases
            // Maybe this should be transient to create a new one everytime   
            builder.Services.AddTransient<ILoadToppingsUseCase, LoadToppingsUseCase>();         
            // builder.Services.AddSingleton<ILoadToppingsUseCase, LoadToppingsUseCase>();

            // Singleton - One Instance througout the lifetime of the app.
            builder.Services.AddSingleton<CreatePizzaViewModel>();                       
            builder.Services.AddSingleton<CustomerViewModel>();  // Maybe this should be transient to create a new one everytime           

            // DI for pages - maybe transient works when nvaigating back and forst the stack - this works but not naviagate
            builder.Services.AddSingleton<CreatePizzaView>();

            // Maybe it must be transient ?
            // builder.Services.AddTransient<CreatePizzaView>();

            
            builder.Services.AddTransient<CustomerView>(); // maybe singleton is better ?
                 
            
#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
