using PizzaCreatorMaui.MVVM.Views;

namespace PizzaCreatorMaui
{
    // THIS IS KINDA THE ENTRY PONT OF THE APPLICATION
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // MainPage = new AppShell();

            // 
            MainPage = new NavigationPage(new CreatePizzaView());
        }
    }
}
