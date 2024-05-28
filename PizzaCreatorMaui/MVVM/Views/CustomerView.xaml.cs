using PizzaCreatorMaui.MVVM.ViewModels;
namespace PizzaCreatorMaui.MVVM.Views;

public partial class CustomerView : ContentPage
{
    public CustomerView(CustomerViewModel customerViewModel)
    {
        InitializeComponent();
        BindingContext = customerViewModel;
    }   
      
    // Goto Payment View - Not Implemented yet
    // Modal Naviagtion - Can only naviagte to here when all fields are filled
    private void CompleteCustomerForm(object sender, EventArgs e)
    {        
        // Navigation.PushAsync(new PaymentView());
    }

    
}