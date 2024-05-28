using PizzaCreatorMaui.MVVM.Views;

namespace PizzaCreatorMaui
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            // Initializer det UI Component der er defineret i den anden halvdel af denne klasse
            InitializeComponent();

            // Registering the posible routes to navigate to as key value pairs.            
            // Registrer de Routes der skal være mulige at navigere til, ved at kalde klassen Routing  -
            // og denne's Static method RegisterRoute. Den metode tager to parametre -
            // en string hvor vi angiver navnet på den route vi vil bruge, samt den reelle route vi vil navigere til
            // Jeg kan så gå til den angivne reelle route ved at kalde det navn der passer med den.
            Routing.RegisterRoute(nameof(CreatePizzaView), typeof(CreatePizzaView));

            // virker
            //Routing.RegisterRoute(nameof(CustomerView), typeof(CustomerView));

            // tester
            Routing.RegisterRoute("customer", typeof(CustomerView));

            Routing.RegisterRoute(nameof(PaymentView), typeof(PaymentView));

            // test size parameter its an enum
            //Routing.RegisterRoute("pizzaSize", typeof(CustomerView));
        }
    }
}
