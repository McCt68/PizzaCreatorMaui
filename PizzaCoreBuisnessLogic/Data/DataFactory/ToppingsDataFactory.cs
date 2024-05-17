using Microsoft.Maui;
using PizzaCoreBuisnessLogic.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaCoreBuisnessLogic.Data.DataFactory
{
    // This class is generic, meaning it can work with different data types as long as they -
    // inherit from a base class named BaseToppingsData.

    // Input: It takes a single argument of type T, which represents a concrete data type -
    // that is inheriting from BaseToppingsData.
    public static class ToppingsDataFactory<T> where T : BaseToppingsData
    {            
        // VIRKER MED GAMLET
        // public static ObservableCollection<Topping> GetToppingsData(T toppingsData)
        public static Task <ObservableCollection<Topping>> GetToppingsData(T toppingsData)
        {
            return toppingsData.GetToppingsData();
        }
    }
}
