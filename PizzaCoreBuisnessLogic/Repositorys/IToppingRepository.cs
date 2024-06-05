using PizzaCoreBuisnessLogic.Models;
using System.Collections.ObjectModel;

namespace PizzaCoreBuisnessLogic.Repositorys
{
    public interface IToppingRepository
    {        
        Task<ObservableCollection<Topping>> GetToppingsAsync();        
    }
}
