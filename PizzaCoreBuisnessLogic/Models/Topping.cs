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

        // Denne representerer en farve med en HEX string.
        // I mit View der bruger jeg så en IvalueConverter til at Convertere HEX stringen -
        // Til en Maui.Graphics.Color 
        public string ToppingImageHexColor {  get; set; }
    }
}

// public Color? ToppingImage { get; set; }   




