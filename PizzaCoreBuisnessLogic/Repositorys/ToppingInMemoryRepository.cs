using PizzaCoreBuisnessLogic.Models;
using PizzaCoreBuisnessLogic.Utilities;
using System.Collections.ObjectModel;

namespace PizzaCoreBuisnessLogic.Repositorys
{
    public class ToppingInMemoryRepository : IToppingRepository
    {        
        private ObservableCollection<Topping> _toppings; 
        public ToppingInMemoryRepository()
        {
            _toppings = new ObservableCollection<Topping>()
            {
                new Topping
                    {
                       ToppingName = "Toppings from in memory repository",
                       ToppingPrice = 0m,                       
                       ToppingImageHexColor = "#1494C6"
                    },
                new Topping
                    {
                       ToppingName = "Peperoni",
                       ToppingPrice = 12m,                       
                       ToppingImageHexColor = RandomColorGenerator.GetRandomColorHex()
                    },
                new Topping
                   {
                        ToppingName = "Pineapple",
                        ToppingPrice = 8m,                        
                        ToppingImageHexColor = RandomColorGenerator.GetRandomColorHex()
                    },
                new Topping
                    {
                        ToppingName = "Ham",
                        ToppingPrice = 15m,                        
                        ToppingImageHexColor = RandomColorGenerator.GetRandomColorHex()
                    },
                new Topping
                   {
                        ToppingName = "Tomatos",
                        ToppingPrice = 8m,                        
                        ToppingImageHexColor = RandomColorGenerator.GetRandomColorHex()
                    },
                new Topping
                    {
                        ToppingName = "Mushrooms",
                        ToppingPrice = 8m,                        
                        ToppingImageHexColor = RandomColorGenerator.GetRandomColorHex()
                    },
                new Topping
                   {
                        ToppingName = "Tuna",
                        ToppingPrice = 15m,                        
                        ToppingImageHexColor = RandomColorGenerator.GetRandomColorHex()
                    },
                new Topping
                    {
                        ToppingName = "Potatos",
                        ToppingPrice = 10m,                        
                        ToppingImageHexColor = RandomColorGenerator.GetRandomColorHex()
                    },
                new Topping
                   {
                        ToppingName = "Shrimps",
                        ToppingPrice = 15m,                        
                        ToppingImageHexColor = RandomColorGenerator.GetRandomColorHex()
                    },
                new Topping
                    {
                        ToppingName = "Beef",
                        ToppingPrice = 20m,                        
                        ToppingImageHexColor = RandomColorGenerator.GetRandomColorHex()
                    },
                new Topping
                   {
                        ToppingName = "Green Peber",
                        ToppingPrice = 8m,                        
                        ToppingImageHexColor = RandomColorGenerator.GetRandomColorHex()
                    },
                new Topping
                    {
                        ToppingName = "Jalapenios",
                        ToppingPrice = 6m,                        
                        ToppingImageHexColor = RandomColorGenerator.GetRandomColorHex()
                    },
                new Topping
                    {
                        ToppingName = "Chicken",
                        ToppingPrice = 15m,                        
                        ToppingImageHexColor = RandomColorGenerator.GetRandomColorHex()
                    },
                new Topping
                    {
                        ToppingName = "Onions",
                        ToppingPrice = 6m,                        
                        ToppingImageHexColor = RandomColorGenerator.GetRandomColorHex()
                    },
                new Topping
                    {
                        ToppingName = "Asparagus",
                        ToppingPrice = 10m,                       
                        ToppingImageHexColor = RandomColorGenerator.GetRandomColorHex()
                    },
                new Topping
                    {
                        ToppingName = "Artichoke",
                        ToppingPrice = 8m,                        
                        ToppingImageHexColor = RandomColorGenerator.GetRandomColorHex()
                    },
            };
        }

        // This static method of the Task class creates a Task that is already completed successfully -
        // with the specified result, which in this case is _toppings.
        public Task<ObservableCollection<Topping>> GetToppingsAsync()
        {          
            return Task.FromResult(_toppings);           
        }
    }
}
