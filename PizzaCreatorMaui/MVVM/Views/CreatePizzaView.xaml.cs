using PizzaCreatorMaui.MVVM.ViewModels;

namespace PizzaCreatorMaui.MVVM.Views;

/*
 * I will try to add DI
 * This object has a dependency of the ViewModel. So i need to DI into this class constrcutor
 * The ViewModel has a dependency of the Model, So i need to DI that into the ViewModel class
 * 
 * */

public partial class CreatePizzaView : ContentPage
{   

    // DEN HER VIRKER UDEN DI
    public CreatePizzaView()
    {
        InitializeComponent();
        // this.createPizzaViewModel = createPizzaViewModel;

        // this.BindingContext = createPizzaViewModel;
        this.BindingContext = new CreatePizzaViewModel();
    }

    // TEST MED DI
    public CreatePizzaView(CreatePizzaViewModel createPizzaViewModel)
    {
        InitializeComponent();
        // this.createPizzaViewModel = createPizzaViewModel;

        // this.BindingContext = createPizzaViewModel;
        BindingContext = createPizzaViewModel;
    }

    // M�ske skal jeg her ogs� bruge DI Contructoren og angive et parameter for ViewMode
    // Eller bedre g� v�k fra at videregive data til n�ste view p� den her m�de
    // Eller ved at bruge encapsiolation og have viewModellen som en readonly var i klassen

    // BRUGES IKKE MERE. BRUGER SHELL NAV NU
    //private void NavigateToCustomerForm(object sender, EventArgs e)
    //{
    //    var currentViewModel =
    //        ((CreatePizzaViewModel)BindingContext).TotalPizzaPrice;
    //    // Pass the value from the txtName Control along to the detination
    //    Navigation.PushAsync(new CustomerView
    //    {
    //        BindingContext = new CustomerViewModel
    //        {
    //            // Name = currentViewModel
    //            TotalPizzaPrice = currentViewModel
    //        }
    //    });
    //}   
}