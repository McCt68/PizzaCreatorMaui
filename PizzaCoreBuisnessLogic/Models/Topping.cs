using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// NOT USED YET - BE AWARE WHERE THE MODEL I USE COME FROM !

namespace PizzaCoreBuisnessLogic.Models
{ 
    public class Topping
    {
        public int Id { get; set; }
        public string ToppingName { get; set; }
        public decimal ToppingPrice { get; set; }
        //public string ToppingImage { get; set; }

        // Testing another type
        public Color ToppingImage { get; set; } // Det her virker !

        // public ImageSource ToppingImage1 { get; set; } // Måske den her type ?
    }
}
