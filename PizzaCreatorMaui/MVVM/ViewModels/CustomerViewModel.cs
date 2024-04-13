using PizzaCreatorMaui.MVVM.Models;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaCreatorMaui.MVVM.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    internal class CustomerViewModel
    {
        // Used for Naviagtion, its the same property as in the source ViewModel
        public string Name { get; set; }

        public Customer CurrentCustomer { get; set; } = new Customer();
        public decimal TotalPizzaPrice { get; set; }

        public CustomerViewModel()
        {
            
        }

    }
}
