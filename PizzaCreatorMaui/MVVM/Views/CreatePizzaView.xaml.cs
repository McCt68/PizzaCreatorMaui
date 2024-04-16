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
    // used for DI
    // private readonly CreatePizzaViewModel createPizzaViewModel;
	// public CreatePizzaView(CreatePizzaViewModel createPizzaViewModel)
	public CreatePizzaView()
	{
		InitializeComponent();
        // this.createPizzaViewModel = createPizzaViewModel;

		// this.BindingContext = createPizzaViewModel;
		this.BindingContext = new CreatePizzaViewModel(); 
	}        

    private void NavigateToCustomerForm(object sender, EventArgs e)
    {
        var currentViewModel =            
            ((CreatePizzaViewModel)BindingContext).TotalPizzaPrice;
        // Pass the value from the txtName Control along to the detination
        Navigation.PushAsync(new CustomerView
        {
            BindingContext = new CustomerViewModel
            {
                // Name = currentViewModel
                TotalPizzaPrice = currentViewModel
            }
        });       

        // TODO
        // Pass the TotalPrice of the Pizza to the page where the customer fills out his information
    }   
}