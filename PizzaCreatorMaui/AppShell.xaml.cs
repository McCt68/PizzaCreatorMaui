using PizzaCreatorMaui.MVVM.Views;

namespace PizzaCreatorMaui
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            // Registering the posible routes to navigate to as key value pairs.            
            Routing.RegisterRoute(nameof(CreatePizzaView), typeof(CreatePizzaView));
            Routing.RegisterRoute(nameof(CustomerView), typeof(CustomerView));
            Routing.RegisterRoute(nameof(PaymentView), typeof(PaymentView));
        }
    }
}
