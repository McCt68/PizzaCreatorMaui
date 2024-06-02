//using PizzaCoreBuisnessLogic.Models;
//using PizzaCoreBuisnessLogic.Utilities;
//using System.Collections.ObjectModel;

//namespace PizzaCoreBuisnessLogic.Data.DataFactory
//{
//    public class MixedToppingsData : BaseToppingsData
//    {
//        public RandomColorGenerator TestColor { get; set; } = new RandomColorGenerator();
//        public override async Task <ObservableCollection<Topping>> GetToppingsData()
//        {
//            return new ObservableCollection<Topping>
//                {                
//                 new Topping
//                    {
//                       ToppingName = "MixedToppings",
//                       ToppingPrice = 2m,
//                       ToppingImage = TestColor.GetRandomColor()
//                    },
//                new Topping
//                   {
//                        ToppingName = "Pineapple",
//                        ToppingPrice = 8m,
//                        ToppingImage = TestColor.GetRandomColor()
//                    },
//                new Topping
//                    {
//                        ToppingName = "Ham",
//                        ToppingPrice = 15m,
//                        ToppingImage = TestColor.GetRandomColor()
//                    },
//                new Topping
//                    {
//                    ToppingName = "Onions",
//                    ToppingPrice = 6m,
//                    ToppingImage = TestColor.GetRandomColor()
//                    },
//                new Topping
//                    {
//                    ToppingName = "Shrimps",
//                    ToppingPrice = 15m,
//                    ToppingImage = TestColor.GetRandomColor()
//                    },
//                new Topping
//                    {
//                    ToppingName = "Green Peber",
//                    ToppingPrice = 8m,
//                    ToppingImage = TestColor.GetRandomColor()
//                    },
//                new Topping
//                    {
//                    ToppingName = "Tuna",
//                    ToppingPrice = 15m,
//                    ToppingImage = TestColor.GetRandomColor()
//                    },
//                new Topping
//                    {
//                    ToppingName = "Tomatos",
//                    ToppingPrice = 8m,
//                    ToppingImage = TestColor.GetRandomColor()
//                    },
//                 new Topping
//                    {
//                     ToppingName = "Egg",
//                     ToppingPrice = 8m,
//                     ToppingImage = TestColor.GetRandomColor()
//                    },
//                  new Topping
//                    {
//                      ToppingName = "Extra Cheese",
//                      ToppingPrice = 8m,
//                      ToppingImage = TestColor.GetRandomColor()
//                    },
//                   new Topping
//                    {
//                       ToppingName = "Bacon",
//                       ToppingPrice = 12m,
//                       ToppingImage = TestColor.GetRandomColor()
//                    }
//            };
//        }    
//    }
//}
