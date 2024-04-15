using PizzaCreatorMaui.MVVM.Views;

namespace PizzaCreatorMaui
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            // Testing Naviagation
            // Key:Value Pair
            Routing.RegisterRoute(nameof(CreatePizzaView), typeof(CreatePizzaView));
            Routing.RegisterRoute(nameof(CustomerView), typeof(CustomerView));
            Routing.RegisterRoute(nameof(PaymentView), typeof(PaymentView));
        }
    }
}
