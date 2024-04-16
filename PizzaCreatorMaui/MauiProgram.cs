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
                        
            // I Think this works as long as i only navigate within the shell scope
            // Injecting ViewModels - When ever a class ask for a ViewModel
            builder.Services.AddSingleton<CustomerViewModel>();
            builder.Services.AddSingleton<CreatePizzaViewModel>();

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
