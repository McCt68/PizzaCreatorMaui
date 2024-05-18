using PizzaCoreBuisnessLogic.Models;
using PizzaCoreBuisnessLogic.Utilities;
using System.Collections.ObjectModel;

namespace PizzaCoreBuisnessLogic.Repositorys
{
    public class ToppingInMemoryRepository : IToppingRepository
    {
        public RandomColorGenerator TestColor { get; set; } = new RandomColorGenerator();

        public static ObservableCollection<Topping> _toppings;
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
            };
        }
        public Task<ObservableCollection<Topping>> GetToppingsAsync()
        {          
            return Task.FromResult(_toppings);           
        }
    }
}
