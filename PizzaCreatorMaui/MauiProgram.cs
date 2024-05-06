using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
// using PizzaCoreBuisnessLogic.Data;
using PizzaCoreBuisnessLogic.Data.DataFactory;
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


            // I Think this works as long as i only navigate within the shell scope
            // Injecting ViewModels - When ever a class ask for a ViewModel

            // Dependency injection in the contructor. When ever a object depends on another object -
            // The framework will create it.
            // Singleton - One Instance througout the lifetime of the app.
            builder.Services.AddSingleton<CreatePizzaViewModel>();

            // Maybe this should be transient to create a new one everytime
            
            builder.Services.AddSingleton<CustomerViewModel>();

            // DI for pages
            builder.Services.AddSingleton<CreatePizzaView>();
            // Not used yet
            builder.Services.AddTransient<CustomerView>(); // maybe singleton is better ?

            // Maybe I should try to DI the Toppings List into the CreatePizzaViewModel
            // builder.Services.AddSingleton<LocalToppingsData>();
            // builder.Services.AddSingleton<ToppingsDataFactory>(LocalToppingsData.);


#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
