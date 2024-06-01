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
        public System.Drawing.Color? ToppingImage { get; set; } // was color in other model - this works but only loads as black
        public string ToppingImageString { get; set; }    

        // Maui Color - first migrate and update db before using this
        // Try to migrate and test now
        // public Microsoft.Maui.Graphics.Color? ToppingImageMaui {  get; set; } // DO NOT DELETE YET
        
        // public int ToppingImage { get; set; }

    }

    // Use for converting the Color type - works with system color type. denne giver dog kun sort tilbage
    // Prøver med en anden converter
    class ColorToInt32Converter : ValueConverter<System.Drawing.Color, int>
    {
        public ColorToInt32Converter() : base
            (c => c.ToArgb(), v => System.Drawing.Color.FromArgb(v))
        { }
    }


    // TEST SLU MÅ OKKE SLTTES SLETTES MÅ IKKE !


    // TEST NY CONVERTER TEST TEST - Prøv den her i stedet !
    //class ColorToInt32Converter : ValueConverter<System.Drawing.Color, int>
    //{
    //    public ColorToInt32Converter() : base(
    //        c => System.Drawing.Color.FromArgb(c.R, c.G, c.B, c.A),
    //        v =>
    //        {
    //            if (v == 0) return System.Drawing.Color.Empty; // Handle null or empty values
    //            var colorDict = JsonConvert.DeserializeObject<Dictionary<string, int>>(v.ToString());
    //            return System.Drawing.Color.FromArgb(colorDict["r"], colorDict["g"], colorDict["b"], colorDict["a"]);
    //        })
    //    { }
    //}



    // TEST WITH MAUI COLOR DO NOT DELETE
    // This is new and untested i may have to delete it
    // Maui Color Converter
    //class MauiColorConverter : ValueConverter<Microsoft.Maui.Graphics.Color, string>
    //{
    //    public MauiColorConverter(): base
    //        ( v=> v.ToHex(), // Convert Color to hex string when saving to the database
    //        v => Microsoft.Maui.Graphics.Color.FromArgb(v) // Convert hex string to Color when reading from the database
    //        )
    //    {

    //    }
    //}
}
