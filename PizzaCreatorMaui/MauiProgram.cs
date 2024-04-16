using Microsoft.Extensions.Logging;
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

            // I can add/Initialize other stuff here, like for example .NET Maui toolkit
            // I think I can add/Register Dependency injection here ?

            // builder.Services.AddSingleton(CreatePizzaView);
            // builder.Services.AddSingleton<CreatePizzaViewModel>(); // not sure if working

            // I Think this works as long as i only navigate within the shell scope
            builder.Services.AddSingleton<CustomerViewModel>();

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
