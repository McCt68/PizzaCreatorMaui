using Microsoft.Maui.Controls.Shapes;
using PizzaCreatorMaui.Data;
using PizzaCreatorMaui.MVVM.Models;
using PizzaCreatorMaui.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaCreatorMaui.Services
{
    internal class ToppingImpl : IToppings
    {
        public RandomColorMaker TestColor { get; set; } = new RandomColorMaker();        

        // THIS IS IMPORTANT UNCOMMENT TO USE IT
        public ObservableCollection<Topping> GetToppings()
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
                        ToppingPrice =8m,
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
