using PizzaCreatorMaui.MVVM.ViewModels;
using PizzaCreatorMaui.MVVM.ViewModels.Navigation;
using System.Reflection.Metadata;

namespace PizzaCreatorMaui.MVVM.Views;

// Denne virker - før forsøg med IQueryAttributable Interface
public partial class CustomerView : ContentPage

//public partial class CustomerView : ContentPage, IQueryAttributable
{
    public CustomerView(CustomerViewModel customerViewModel)
    {
        InitializeComponent();
        BindingContext = customerViewModel;
    }

    // Bruger denne til at pass parameters fra CreatePizzaViewModel
    //public void ApplyQueryAttributes(IDictionary<string, object> query)
    //{
    //    throw new NotImplementedException();
    //}

    // trying to pass anaviagation class object
    //public void OnNavigatedTo(ShellNavigationState state, object parameter)
    //{
    //    if (parameter is PizzaNavigationData data)
    //    {
    //        BindingContext = data;
    //    }
    //}

    // This works without DI
    //public CustomerView()
    //{
    //	InitializeComponent();
    //           BindingContext = new CustomerViewModel();

    //}



    // Go back to Create Pizza
    //  private void Button_Clicked(object sender, EventArgs e)
    //  {
    //Navigation.PushAsync(new CreatePizzaView());
    //  }

    // Goto Payment View
    // Modal Naviagtion - Can only naviagte to here when all fields are filled
    private void CompleteCustomerForm(object sender, EventArgs e)
    {        
        // Navigation.PushAsync(new PaymentView());
    }

    
}