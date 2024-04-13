using PizzaCreatorMaui.MVVM.ViewModels;

namespace PizzaCreatorMaui.MVVM.Views;

public partial class CreatePizzaView : ContentPage
{
	public CreatePizzaView()
	{
		InitializeComponent();

		BindingContext = new CreatePizzaViewModel();

	}        
    private void NavigateToCustomerForm(object sender, EventArgs e)
    {
        var currentViewModel =
            // ((CreatePizzaViewModel)BindingContext).Name;
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

    //  private void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    //  {
    //var selectedElement = e.CurrentSelection;
    //  }

    

    

}