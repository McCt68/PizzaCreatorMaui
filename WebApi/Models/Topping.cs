using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Drawing;

namespace WebApi.Models
{
    // Dette er en Entity class. Den representerer et object der kan gemmes i databasen
    public class Topping
    {        
        public int Id { get; set; } 
        public string? ToppingName { get; set; }
        public decimal ToppingPrice { get; set; }        
        public System.Drawing.Color? ToppingImage { get; set; } 
                
        public string ToppingImageString { get; set; }        

        // Bruger et property af type string. Som jeg sætter til en HEX værdi der representer en Color
        // Så kan jeg bruge denne property sammen med en IvalueConverter i mit View til at -
        // Convertere fra HEX til Maui Color.
        public string ToppingImageHexColor { get; set; }                     
    }

    // Use for converting the Color type - works with system color type. denne giver dog kun sort tilbage
    // Prøver med en anden converter
    class ColorToInt32Converter : ValueConverter<System.Drawing.Color, int>
    {
        public ColorToInt32Converter() : base
            (c => c.ToArgb(), v => System.Drawing.Color.FromArgb(v))
        { }
    }             
}
