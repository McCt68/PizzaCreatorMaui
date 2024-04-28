using PizzaCreatorMaui.MVVM.ViewModels;

namespace PizzaCreatorMaui.MVVM.Views;

/*
 * I will try to add DI
 * This object has a dependency of the ViewModel. So I need to DI into this class constrcutor
 * The ViewModel has a dependency of the Model, So i need to DI that into the ViewModel class
 * 
 * */

public partial class CreatePizzaView : ContentPage
{
    // private readonly CreatePizzaViewModel _createPizzaViewModel;

    // 
    //public CreatePizzaView()
    //{
    //    InitializeComponent();
    //    //this.createPizzaViewModel = createPizzaViewModel;
    //    //this.BindingContext = _createPizzaViewModel;
    //    this.BindingContext = new CreatePizzaViewModel();
    //    // BindingContext = _createPizzaViewModel;
    //}

    // TEST MED DI
    public CreatePizzaView(CreatePizzaViewModel vm)
    {
        InitializeComponent();

        // this._createPizzaViewModel = vm;        
        //this.BindingContext = createPizzaViewModel;

        //this._createPizzaViewModel = _createPizzaViewModel;
        BindingContext = vm; // _createPizzaViewModel;
    }

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