using PizzaCreatorMaui.MVVM.ViewModels;

namespace PizzaCreatorMaui.MVVM.Views;

/*
 * I will try to add DI
 * This object has a dependency of the ViewModel. So I need to DI into this class constrcutor
 * The ViewModel has a dependency of the Model, So i need to DI that into the ViewModel class 
 */

public partial class CreatePizzaView : ContentPage
{
    private readonly CreatePizzaViewModel toppingsViewModel;

    // TEST MED DI
    public CreatePizzaView(CreatePizzaViewModel toppingsViewModel)
    {
        InitializeComponent();

        this.toppingsViewModel = toppingsViewModel;
        this.BindingContext = toppingsViewModel;     
    }

    // Dont even think i need this anymore ?
    protected override async void OnAppearing()
    {
        base.OnAppearing(); // Kald metode fra Base class

        await this.toppingsViewModel.LoadToppingsAsync(); // Load Toppings with method from Viewmodel
    }


    // ---****** THIS WORKS BEFORE I TEST DI WITH THE OLD VIEW MODEL CODE ****-----
    //public CreatePizzaView(CreatePizzaViewModel vm)
    //{
    //    InitializeComponent();

    //    BindingContext = vm; // _createPizzaViewModel;        

    //}
    // ---****** THIS WORKS BEFORE I TEST DI WITH TH EOLD VIEW MODEL CODE END TEST END TEST ! ****-----

    // TEST OnAppering.
    //protected override void OnAppearing()
    //{
    //    base.OnAppearing();

    //    // TESTER
    //    // _createPizzaViewModel.TotalPizzaPrice = _createPizzaViewModel.TotalPizzaPrice + _createPizzaViewModel.CurrentCarouselItem.Price;


    //    // Tror ikke jeg skal have logic beregning her. det hører til view og laver ged i den ??
    //    // Dette semi virker
    //    // _createPizzaViewModel.TotalPizzaPrice = _createPizzaViewModel.PizzaSizePrice + _createPizzaViewModel.TotalToppingsPrice;

    //    // Tror jeg skal have hver enkelt value til at blive vist her og ikke en beregning
    //    //_createPizzaViewModel.TotalPizzaPrice = _createPizzaViewModel.PizzaSizePrice + _createPizzaViewModel.TotalToppingsPrice;
    //    //createPizzaViewModel.TotalPizzaPrice = createPizzaViewModel.PizzaSizePrice + createPizzaViewModel.TotalToppingsPrice;



    //    // DETTE SEMI VIRKER
    //    // _createPizzaViewModel.TotalPizzaPrice = _createPizzaViewModel.TotalPizzaPrice + _createPizzaViewModel.CurrentCarouselItem.Price;
    //}

    // Måske skal jeg her også bruge DI Contructoren og angive et parameter for ViewMode
    // Eller bedre gå væk fra at videregive data til næste view på den her måde
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