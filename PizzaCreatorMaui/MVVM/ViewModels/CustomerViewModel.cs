using PizzaCreatorMaui.MVVM.Models;
using PropertyChanged;
using System.Windows.Input;

namespace PizzaCreatorMaui.MVVM.ViewModels
{
    // Teste passing parameters with shell - Skal lige forstå det her bedre ??
    [QueryProperty(nameof(TotalPizzaPrice), nameof(TotalPizzaPrice))]

    [AddINotifyPropertyChangedInterface]
    public class CustomerViewModel
    {
        #region Properties
        public Customer CurrentCustomer { get; set; } = new Customer();
        public decimal TotalPizzaPrice { get; set; }
        #endregion

        #region Commands
        // test bool animate i naviagateToAsync
        public ICommand NavigateBack =>
            new Command(async () => await Shell.Current.GoToAsync(".."));

            // new Command(async () => await Shell.Current.GoToAsync($".." ? TotalPizzaPrice ={TotalPizzaPrice}));
        #endregion

        public CustomerViewModel()
        {
            
        }

    }
}
