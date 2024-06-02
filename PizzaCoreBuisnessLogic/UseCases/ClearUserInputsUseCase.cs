using PizzaCoreBuisnessLogic.Models;
using PizzaCoreBuisnessLogic.UseCases.Interfaces;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PizzaCoreBuisnessLogic.UseCases
{
    [AddINotifyPropertyChangedInterface]
    public class ClearUserInputsUseCase : IClearUserData
    {
        // public Customer CurrentCustomer { get; set; } 
        private Customer _currentCustomer { get; set; } 
        public void ClearUserInputs() 
        {            
            // CurrentCustomer.CustomerName = "Set string to empty"; 
            //CurrentCustomer.CustomerName = string.Empty;
            //CurrentCustomer.CustomerAddress = string.Empty;
            //CurrentCustomer.CustomerPhone = string.Empty;
            //CurrentCustomer.Email = string.Empty;

            _currentCustomer.CustomerName = string.Empty;
            _currentCustomer.CustomerAddress = string.Empty;
            _currentCustomer.CustomerPhone = string.Empty;
            _currentCustomer.Email = string.Empty;
        }        
        
        // I should try to provide Customer argument with DI
        public ClearUserInputsUseCase(Customer currentCustomer)
        {
            // CurrentCustomer = currentCustomer;
            _currentCustomer = currentCustomer;
        }        
    }
}
