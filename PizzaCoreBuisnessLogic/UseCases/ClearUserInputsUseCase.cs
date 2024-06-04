using PizzaCoreBuisnessLogic.Models;
using PizzaCoreBuisnessLogic.UseCases.Interfaces;
using PropertyChanged;


namespace PizzaCoreBuisnessLogic.UseCases
{
    [AddINotifyPropertyChangedInterface]
    public class ClearUserInputsUseCase : IClearUserData
    {         
        private Customer _currentCustomer { get; set; } 
        public void ClearUserInputs() 
        {                       
            _currentCustomer.CustomerName = string.Empty;
            _currentCustomer.CustomerAddress = string.Empty;
            _currentCustomer.CustomerPhone = string.Empty;
            _currentCustomer.Email = string.Empty;
        }        
        
        // Får en instans af Customer når den har brug for den
        public ClearUserInputsUseCase(Customer currentCustomer)
        {            
            _currentCustomer = currentCustomer;
        }        
    }
}
