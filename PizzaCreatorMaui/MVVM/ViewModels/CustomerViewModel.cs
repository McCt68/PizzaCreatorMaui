using PizzaCreatorMaui.MVVM.Models;
using PizzaCreatorMaui.MVVM.Views;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PizzaCreatorMaui.MVVM.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class CustomerViewModel
    {
        #region Properties
        public Customer CurrentCustomer { get; set; } = new Customer();
        public decimal TotalPizzaPrice { get; set; }
        #endregion

        #region Commands
        public ICommand NavigateBack => 
            new Command(async () => await Shell.Current.GoToAsync(".."));
        #endregion

        public CustomerViewModel()
        {
            
        }

    }
}
