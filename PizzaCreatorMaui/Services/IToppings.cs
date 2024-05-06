using PizzaCreatorMaui.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaCreatorMaui.Services
{
    internal interface IToppings
    {
        // I COMMENT OUT THIS CODE - TO BE USRE THE MODEL COMES FROM CORE BUISNESS

        // Lave denne som asynchron og bruge delay for at vise at data skal loades først ?
        //ObservableCollection<Topping> GetToppings();
    }
}
