using PizzaCoreBuisnessLogic.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaCoreBuisnessLogic.UseCases.Interfaces
{
    public interface ILoadToppingsUseCase
    {

        // Virker
        Task<ObservableCollection<Topping>> LoadToppingsAsync();        
        // Task<ObservableCollection<Topping>> LoadToppingsAsync();        
    }
}
