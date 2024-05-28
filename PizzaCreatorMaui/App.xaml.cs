using PizzaCreatorMaui.MVVM.Views;

namespace PizzaCreatorMaui
{
    // THIS IS KINDA THE ENTRY PONT OF THE APPLICATION
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // Gå til den første route der er defineret i AppShell.xaml
            MainPage = new AppShell();           
                       
        }
    }
}
