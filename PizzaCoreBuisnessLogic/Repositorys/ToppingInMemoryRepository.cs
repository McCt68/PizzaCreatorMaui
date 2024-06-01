using PizzaCoreBuisnessLogic.Models;
using PizzaCoreBuisnessLogic.Utilities;
using System.Collections.ObjectModel;

namespace PizzaCoreBuisnessLogic.Repositorys
{
    public class ToppingInMemoryRepository : IToppingRepository
    {
        public RandomColorGenerator TestColor { get; set; } = new RandomColorGenerator();

        // Hvorfor er denne public static, kunne den ikke være private ?
        // public static ObservableCollection<Topping> _toppings;

        private ObservableCollection<Topping> _toppings; // kan ikke se hvorfor denne ikke skal være private ??
        public ToppingInMemoryRepository()
        {
            _toppings = new ObservableCollection<Topping>()
            {
                new Topping
                    {
                       ToppingName = "Toppings from in memory repository",
                       ToppingPrice = 2m,
                       ToppingImage = TestColor.GetRandomColor()
                    },
                new Topping
                    {
                       ToppingName = "MixedToppings",
                       ToppingPrice = 2m,
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
                        ToppingName = "Tomatos",
                        ToppingPrice = 8m,
                        ToppingImage = TestColor.GetRandomColor()
                    },
                new Topping
                    {
                        ToppingName = "Mushrooms",
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
                        ToppingName = "Potatos",
                        ToppingPrice = 10m,
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
                        ToppingName = "Beef",
                        ToppingPrice = 20m,
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
                        ToppingName = "Jalapenios",
                        ToppingPrice = 6m,
                        ToppingImage = TestColor.GetRandomColor()
                    },
                new Topping
                    {
                        ToppingName = "Chicken",
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
                        ToppingName = "Asparagus",
                        ToppingPrice = 10m,
                        ToppingImage = TestColor.GetRandomColor()
                    },
                new Topping
                    {
                        ToppingName = "Artichoke",
                        ToppingPrice = 8m,
                        ToppingImage = TestColor.GetRandomColor()
                    },
            };
        }
        public Task<ObservableCollection<Topping>> GetToppingsAsync()
        {          
            return Task.FromResult(_toppings);           
        }
    }
}
