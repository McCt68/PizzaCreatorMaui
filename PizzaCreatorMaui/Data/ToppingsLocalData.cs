using PizzaCreatorMaui.MVVM.Models;
using PizzaCreatorMaui.Utilities;
using System.Collections.ObjectModel;

namespace PizzaCreatorMaui.Data
{
    public class ToppingsLocalData
    {
        public RandomColorMaker TestColor { get; set; } = new RandomColorMaker();

        private ObservableCollection<Topping> _localToppings = new ObservableCollection<Topping>()
        {            
 

        // DO NOT DELETE
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
