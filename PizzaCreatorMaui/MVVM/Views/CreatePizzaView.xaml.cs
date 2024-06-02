using PizzaCreatorMaui.MVVM.ViewModels;

namespace PizzaCreatorMaui.MVVM.Views;

/* 
 * This object has a dependency of the ViewModel. So I need to DI into this class constrcutor
 * The ViewModel has a dependency of the Model, So i need to DI that into the ViewModel class 
 */

public partial class CreatePizzaView : ContentPage
{
    private readonly CreatePizzaViewModel _toppingsViewModel;
    
    public CreatePizzaView(CreatePizzaViewModel toppingsViewModel)
    {
        InitializeComponent();

        this._toppingsViewModel = toppingsViewModel;
        this.BindingContext = toppingsViewModel;     
    }
    
    protected override async void OnAppearing()
    {
        base.OnAppearing(); // Kald metode fra Base class

        // Test af reset switch property
        _toppingsViewModel.ResetSwitch();
        _toppingsViewModel.ToppingsType = "Mixed Toppings.";

        await this._toppingsViewModel.LoadToppingsAsync(); // Load Toppings with method from Viewmodel        
    }    
}