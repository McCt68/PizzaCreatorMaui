﻿using PizzaCoreBuisnessLogic.Models;
using PizzaCoreBuisnessLogic.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaCoreBuisnessLogic.Data.DataFactory
{
    public class ToppingsDataColorAsString : BaseToppingsData
    {
        public RandomColorGenerator TestColor { get; set; } = new RandomColorGenerator();

        // public override ObservableCollection<Topping> GetToppingsData()
            public override async Task <ObservableCollection<Topping>> GetToppingsData()
        {
            return new ObservableCollection<Topping>
        {
            new Topping
            {
                ToppingName = "Topping Color as string",
                ToppingPrice = 2m,
                ToppingImageString = Topping.ColorToString(TestColor.GetRandomColor()),
                
                // ToppingImageString = Topping.StringToColor("128,255,0,100");
            },
            new Topping
            {
                ToppingName = "Topping Color as string",
                ToppingPrice = 2m,
                ToppingImageString = Topping.ColorToString(TestColor.GetRandomColor())
            },
            new Topping
            {
                ToppingName = "Topping Color as string",
                ToppingPrice = 2m,
                ToppingImageString = Topping.ColorToString(TestColor.GetRandomColor())
            },
            new Topping
            {
                ToppingName = "Topping Color as string",
                ToppingPrice = 2m,
                ToppingImageString = Topping.ColorToString(TestColor.GetRandomColor())
            },
            new Topping
            {
                ToppingName = "Topping Color as string",
                ToppingPrice = 2m,
                ToppingImageString = Topping.ColorToString(TestColor.GetRandomColor())
            },
            
            // Add other toppings here with string representation of color
        };
        }
    }
}
