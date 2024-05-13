using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Drawing;

namespace WebApi.Models
{
    public class Topping
    {       
        public int Id { get; set; }
        public string? ToppingName { get; set; }
        public decimal ToppingPrice { get; set; }        
        public Color? ToppingImage { get; set; } // was color in other model
        public string ToppingImageString { get; set; }
        

    }    


    // Use for converting the Color type
    class ColorToInt32Converter : ValueConverter<Color, int>
    {
        public ColorToInt32Converter()
            : base(c => c.ToArgb(), v => Color.FromArgb(v)) { }
    }
}
