using PizzaCoreBuisnessLogic.Models;
using System.Collections.ObjectModel;

namespace PizzaCoreBuisnessLogic.UseCases.Interfaces
{
    public interface ILoadToppingsUseCase
    {        
        Task<ObservableCollection<Topping>> LoadInMemoryToppingsAsync();

        Task<ObservableCollection<Topping>> LoadWebApiToppingsAsync();        
    }
}
