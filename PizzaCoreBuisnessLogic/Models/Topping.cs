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
        public string ToppingImageString { get; set; }

        // This works - before i try to make it a string instead
        public Color? ToppingImage { get; set; }


        //// TRYING NEW THINGS TO MAKE TOPPINGIMAGE A String instead

        //// Method to convert Color to string representation
        public static string ColorToString(Color color)
        {
            return $"{color.Red},{color.Green},{color.Blue},{color.Alpha}";
        }

        //// Method to convert string representation to Color
        public static Color StringToColor(string colorString)
        {
            var parts = colorString.Split(',');
            if (parts.Length == 4 &&
                double.TryParse(parts[0], out double r) &&
                double.TryParse(parts[1], out double g) &&
                double.TryParse(parts[2], out double b) &&
                double.TryParse(parts[3], out double a))
            {
                return Color.FromRgba(r, g, b, a);
            }
            return Colors.Transparent;            
        }
    }
}

    
