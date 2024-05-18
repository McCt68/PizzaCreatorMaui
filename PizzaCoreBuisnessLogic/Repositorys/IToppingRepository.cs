using PizzaCoreBuisnessLogic.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaCoreBuisnessLogic.Repositorys
{
    public interface IToppingRepository
    {
        // Maybe this should be an observableColection instead of List
        Task<ObservableCollection<Topping>> GetToppingsAsync();

        //Task<List<Topping>> GetToppingsAsync();
    }
}
