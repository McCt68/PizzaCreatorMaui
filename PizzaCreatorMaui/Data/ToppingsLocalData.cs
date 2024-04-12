using PizzaCreatorMaui.MVVM.Models;
using System.Collections.ObjectModel;

namespace PizzaCreatorMaui.Data
{
    internal class ToppingsLocalData
    {
        
        private ObservableCollection<Topping> _localToppings = new ObservableCollection<Topping>()
        {
            new Topping
            {
                ToppingName = "Pineapple",
                ToppingPrice = 8m
            },
            new Topping
            {
                ToppingName = "Ham",
                ToppingPrice = 15m
            },
             new Topping
            {
                ToppingName = "Egg",
                ToppingPrice = 8m
            },
              new Topping
            {
                ToppingName = "Extra Cheese",
                ToppingPrice = 8m
            },
               new Topping
            {
                ToppingName = "Bacon",
                ToppingPrice = 12m
            }, new Topping
            {
                ToppingName = "Spinnach",
                ToppingPrice = 8m
            }
        };

        // Redundant for now
        public ToppingsLocalData()
        {
            
        }

        public ObservableCollection<Topping> GetToppings()
        {
            return _localToppings;
        }
        
    }
}
