using PizzaCoreBuisnessLogic.Utilities;
using PizzaCoreBuisnessLogic.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaCoreBuisnessLogic.Data.LocalData
{
    public class LocalToppingsData1
    {
        // MAYBE the construtor of this class should return the Observablecollection of topings
        public RandomColorGenerator TestColor { get; set; } = new RandomColorGenerator();

        public ObservableCollection<Topping> GetLocalToppingsData()
        {
            return new ObservableCollection<Topping>
                {
                 new Topping
                    {
                       ToppingName = "Test From Core",
                       ToppingPrice = 120m,
                       ToppingImage = TestColor.GetRandomColor()
                    },
                new Topping
                   {
                        ToppingName = "Pineapple",
                        ToppingPrice = 8m,
                        ToppingImage = TestColor.GetRandomColor()
                    },
                new Topping
                    {
                        ToppingName = "Ham",
                        ToppingPrice = 15m,
                        ToppingImage = TestColor.GetRandomColor()
                    },
                new Topping
                    {
                    ToppingName = "Onions",
                    ToppingPrice = 6m,
                    ToppingImage = TestColor.GetRandomColor()
                    },
                new Topping
                    {
                    ToppingName = "Shrimps",
                    ToppingPrice = 15m,
                    ToppingImage = TestColor.GetRandomColor()
                    },
                new Topping
                    {
                    ToppingName = "Green Peber",
                    ToppingPrice = 8m,
                    ToppingImage = TestColor.GetRandomColor()
                    },
                new Topping
                    {
                    ToppingName = "Tuna",
                    ToppingPrice = 15m,
                    ToppingImage = TestColor.GetRandomColor()
                    },
                new Topping
                    {
                    ToppingName = "Tomatos",
                    ToppingPrice = 8m,
                    ToppingImage = TestColor.GetRandomColor()
                    },
                 new Topping
                    {
                     ToppingName = "Egg",
                     ToppingPrice = 8m,
                     ToppingImage = TestColor.GetRandomColor()
                    },
                  new Topping
                    {
                      ToppingName = "Extra Cheese",
                      ToppingPrice = 8m,
                      ToppingImage = TestColor.GetRandomColor()
                    },
                   new Topping
                    {
                       ToppingName = "Bacon",
                       ToppingPrice = 12m,
                       ToppingImage = TestColor.GetRandomColor()
                    }
            };
        }
    }
}
