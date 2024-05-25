using PizzaCoreBuisnessLogic.Models;
using System.Collections.ObjectModel;

namespace PizzaCreatorMaui.MVVM.ViewModels.Navigation
{
    // Denne klasse er til at holde styr på Properties der skla bruges til at navigere imellem Views
    // Det virker ikke endnu. bare slet hvis jeg ikke for det til at virke !
    public class PizzaNavigationData
    {
        public decimal TotalPizzaPrice  { get; set; }
        public decimal PizzaSizePrice  { get; set; }
        public ObservableCollection<Topping> UserSelectedToppings { get; set; }
    }
}
