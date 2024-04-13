using PizzaCreatorMaui.MVVM.Views;

namespace PizzaCreatorMaui
{
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
