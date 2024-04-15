using PizzaCreatorMaui.MVVM.Views;

namespace PizzaCreatorMaui
{
    // THIS IS KINDA THE ENTRY PONT OF THE APPLICATION
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // I am not totally sure how this works. I think I do but why is it Mainpage ?
            MainPage = new AppShell();

            

            // virker
            // MainPage = new NavigationPage(new CreatePizzaView());
        }
    }
}
