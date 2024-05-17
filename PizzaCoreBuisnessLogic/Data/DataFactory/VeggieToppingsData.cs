using PizzaCoreBuisnessLogic.Models;
using PizzaCoreBuisnessLogic.Utilities;
using System.Collections.ObjectModel;

namespace PizzaCoreBuisnessLogic.Data.DataFactory
{
    public class VeggieToppingsData : BaseToppingsData
    {
        public RandomColorGenerator TestColor { get; set; } = new RandomColorGenerator();

        public override async Task <ObservableCollection<Topping>> GetToppingsData()        
        {
            return new ObservableCollection<Topping>
                {
                 new Topping
                    {
                       ToppingName = "VeggieToppings",
                       ToppingPrice = 1m,
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
                        ToppingName = "Chili",
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
                    ToppingName = "Aurbergine",
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
                    ToppingName = "Mushrooms",
                    ToppingPrice = 15m,
                    ToppingImage = TestColor.GetRandomColor()
                    },
                new Topping
                    {
                    ToppingName = "Tomatos",
                    ToppingPrice = 8m,
                    ToppingImage = TestColor.GetRandomColor()
                    }                 
            };
        }
    }
}
