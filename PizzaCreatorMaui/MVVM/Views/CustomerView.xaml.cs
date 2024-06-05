using PizzaCreatorMaui.MVVM.ViewModels;

namespace PizzaCreatorMaui.MVVM.Views;

public partial class CustomerView : ContentPage
{
    public CustomerView(CustomerViewModel customerViewModel)
    {
        InitializeComponent();
        BindingContext = customerViewModel;
    }               
}