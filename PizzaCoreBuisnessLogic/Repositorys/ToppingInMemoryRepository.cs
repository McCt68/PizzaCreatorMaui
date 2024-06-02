using PizzaCoreBuisnessLogic.Models;
using PizzaCoreBuisnessLogic.Utilities;
using System.Collections.ObjectModel;

namespace PizzaCoreBuisnessLogic.Repositorys
{
    public class ToppingInMemoryRepository : IToppingRepository
    {
        // public RandomColorGenerator TestColor { get; set; } = new RandomColorGenerator();

        // Hvorfor er denne public static, kunne den ikke være private ?
        // public static ObservableCollection<Topping> _toppings;

        // Måske kan jeg lave en random hex string og give i værdi til ToppingImageHExColor

        private ObservableCollection<Topping> _toppings; // kan ikke se hvorfor denne ikke skal være private ??
        public ToppingInMemoryRepository()
        {
            _toppings = new ObservableCollection<Topping>()
            {
                new Topping
                    {
                       ToppingName = "Toppings from in memory repository",
                       ToppingPrice = 0m,
                       // ToppingImage = TestColor.GetRandomColor(),
                       // ToppingImage = RandomColorGenerator.GetRandomColor(), // TestColor.GetRandomColor(),
                       // test med hexColor 
                       ToppingImageHexColor = "#1494C6"
                    },
                new Topping
                    {
                       ToppingName = "Peperoni",
                       ToppingPrice = 12m,
                       // ToppingImage = TestColor.GetRandomColor(),
                       // ToppingImage = RandomColorGenerator.GetRandomColor(), // slettes hvis ikke virker
                       // ToppingImageHexColor = "#FF0000",
                       ToppingImageHexColor = RandomColorGenerator.GetRandomColorHex()
                    },
                new Topping
                   {
                        ToppingName = "Pineapple",
                        ToppingPrice = 8m,
                        // ToppingImage = TestColor.GetRandomColor()
                        // ToppingImage = RandomColorGenerator.GetRandomColor(), // slettes hvis ikke virker
                        ToppingImageHexColor = RandomColorGenerator.GetRandomColorHex()
                    },
                new Topping
                    {
                        ToppingName = "Ham",
                        ToppingPrice = 15m,
                        // ToppingImage = TestColor.GetRandomColor()
                        // ToppingImage = RandomColorGenerator.GetRandomColor(), // slettes hvis ikke virker
                        ToppingImageHexColor = RandomColorGenerator.GetRandomColorHex()
                    },
                new Topping
                   {
                        ToppingName = "Tomatos",
                        ToppingPrice = 8m,
                        // ToppingImage = TestColor.GetRandomColor()
                        ToppingImageHexColor = RandomColorGenerator.GetRandomColorHex()
                    },
                new Topping
                    {
                        ToppingName = "Mushrooms",
                        ToppingPrice = 8m,
                        // ToppingImage = TestColor.GetRandomColor()
                        ToppingImageHexColor = RandomColorGenerator.GetRandomColorHex()
                    },
                new Topping
                   {
                        ToppingName = "Tuna",
                        ToppingPrice = 15m,
                        // ToppingImage = TestColor.GetRandomColor()
                        ToppingImageHexColor = RandomColorGenerator.GetRandomColorHex()
                    },
                new Topping
                    {
                        ToppingName = "Potatos",
                        ToppingPrice = 10m,
                        // ToppingImage = TestColor.GetRandomColor()
                        ToppingImageHexColor = RandomColorGenerator.GetRandomColorHex()
                    },
                new Topping
                   {
                        ToppingName = "Shrimps",
                        ToppingPrice = 15m,
                        // ToppingImage = TestColor.GetRandomColor()
                        ToppingImageHexColor = RandomColorGenerator.GetRandomColorHex()
                    },
                new Topping
                    {
                        ToppingName = "Beef",
                        ToppingPrice = 20m,
                        // ToppingImage = TestColor.GetRandomColor()
                        ToppingImageHexColor = RandomColorGenerator.GetRandomColorHex()
                    },
                new Topping
                   {
                        ToppingName = "Green Peber",
                        ToppingPrice = 8m,
                        // ToppingImage = TestColor.GetRandomColor()
                        ToppingImageHexColor = RandomColorGenerator.GetRandomColorHex()
                    },
                new Topping
                    {
                        ToppingName = "Jalapenios",
                        ToppingPrice = 6m,
                        // ToppingImage = TestColor.GetRandomColor()
                        ToppingImageHexColor = RandomColorGenerator.GetRandomColorHex()
                    },
                new Topping
                    {
                        ToppingName = "Chicken",
                        ToppingPrice = 15m,
                        // ToppingImage = TestColor.GetRandomColor()
                        ToppingImageHexColor = RandomColorGenerator.GetRandomColorHex()
                    },
                new Topping
                    {
                        ToppingName = "Onions",
                        ToppingPrice = 6m,
                        // ToppingImage = TestColor.GetRandomColor()
                        ToppingImageHexColor = RandomColorGenerator.GetRandomColorHex()
                    },
                new Topping
                    {
                        ToppingName = "Asparagus",
                        ToppingPrice = 10m,
                        // ToppingImage = TestColor.GetRandomColor()
                        ToppingImageHexColor = RandomColorGenerator.GetRandomColorHex()
                    },
                new Topping
                    {
                        ToppingName = "Artichoke",
                        ToppingPrice = 8m,
                        // ToppingImage = TestColor.GetRandomColor()
                        ToppingImageHexColor = RandomColorGenerator.GetRandomColorHex()
                    },
            };
        }
        public Task<ObservableCollection<Topping>> GetToppingsAsync()
        {          
            return Task.FromResult(_toppings);           
        }
    }
}
