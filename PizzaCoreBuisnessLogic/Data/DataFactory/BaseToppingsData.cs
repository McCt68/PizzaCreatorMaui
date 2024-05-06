using PizzaCoreBuisnessLogic.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaCoreBuisnessLogic.Data.DataFactory
{
    public abstract class BaseToppingsData
    {              
        public abstract ObservableCollection<Topping> GetToppingsData();
    }
}
