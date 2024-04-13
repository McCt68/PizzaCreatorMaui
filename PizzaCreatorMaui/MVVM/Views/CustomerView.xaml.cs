using PizzaCreatorMaui.MVVM.ViewModels;

namespace PizzaCreatorMaui.MVVM.Views;

public partial class CustomerView : ContentPage
{
	public CustomerView()
	{
		InitializeComponent();
            BindingContext = new CustomerViewModel();

	}

    // Second Consctructor Can take an argument
    //public CustomerView(string name)
    //{
    //    InitializeComponent();
    //    // Set the txtName attribute to the value that was passed in when creating the CustomerView
    //    txtName.Text = name;
    //}

    // Go back to Create Pizza
    private void Button_Clicked(object sender, EventArgs e)
    {
		Navigation.PushAsync(new CreatePizzaView());
    }

    // Goto Payment View
    // Modal Naviagtion - Can only naviagte to here when all fields are filled
    private void CompleteCustomerForm(object sender, EventArgs e)
    {        
        // Navigation.PushAsync(new PaymentView());
    }

    
}