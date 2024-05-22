using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Drawing;

namespace WebApi.Models
{
    // Dette er en Entity class. Den representerer et object der kan gemmes i databasen
    public class Topping
    {
        // Maybe better to call it ToppingId, since Ent Framework attepts to make a key based on the class name and Id
        public int Id { get; set; } // ToppingID
        public string? ToppingName { get; set; }
        public decimal ToppingPrice { get; set; }        
        public Color? ToppingImage { get; set; } // was color in other model - this works but only loads as black
        public string ToppingImageString { get; set; }    
        
        // public int ToppingImage { get; set; }

    }    


    // Use for converting the Color type
    class ColorToInt32Converter : ValueConverter<Color, int>
    {
        public ColorToInt32Converter()
            : base(c => c.ToArgb(), v => Color.FromArgb(v)) { }
    }
}
