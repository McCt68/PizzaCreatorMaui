using PizzaCoreBuisnessLogic.Models;
using PizzaCoreBuisnessLogic.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaCoreBuisnessLogic.Data
{
    public class LocalToppingsData
    {
        public RandomColorGenerator TestColor { get; set; } = new RandomColorGenerator();

        public ObservableCollection<Topping> GetLocalToppingsData()
        {
            return new ObservableCollection<Topping>
                {
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
