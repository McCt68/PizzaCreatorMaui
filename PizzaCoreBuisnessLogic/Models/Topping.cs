using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PizzaCoreBuisnessLogic.Models
{
    public class Topping
    {
        public int Id { get; set; }
        public string ToppingName { get; set; }
        public decimal ToppingPrice { get; set; }                
        public Color? ToppingImage { get; set; }   
        
        // I need a property of type string that represents a Color with a HEX string like "#00FF00"
        // And with that then i can use an IValueConverter in the View to convert it to a Maui Color
        public string ToppingImageHexColor {  get; set; }
    }
}

    
