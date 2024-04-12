using Microsoft.Maui.Controls.Shapes;
using PizzaCreatorMaui.Data;
using PizzaCreatorMaui.MVVM.Models;
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
        // Prøver at lave et fake image
        //Random randomCircle = new Random();
        //Color randomColor = Color.FromArgb(255, (byte)randomCircle.Next(256), (byte)random.Next(256), (byte)random.Next(256));

        
        public ObservableCollection<Topping> GetToppings()
        {
            return new ObservableCollection<Topping>
                {
                new Topping
                   {
                        ToppingName = "Pineapple",
                        ToppingPrice = 8m,
                        
                    },
                new Topping
                    {
                        ToppingName = "Ham",
                        ToppingPrice = 15m
                    },
                new Topping
                    {
                        ToppingName = "Onions",
                        ToppingPrice = 6m
                    },
                new Topping
                    {
                        ToppingName = "Shrimps",
                        ToppingPrice = 15m
                    },
                new Topping
                    {
                        ToppingName = "Green Peber",
                        ToppingPrice =8m
                    },
                new Topping
                    {
                        ToppingName = "Tuna",
                        ToppingPrice = 15m
                    },
                new Topping
                    {
                        ToppingName = "Tomatos",
                        ToppingPrice = 8m
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
                }

            };
        }
    }
}
