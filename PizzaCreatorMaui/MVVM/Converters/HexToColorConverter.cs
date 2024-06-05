using System.Globalization;

namespace PizzaCreatorMaui.MVVM.Converters
{
    public class HexToColorConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is string hexString && hexString.StartsWith("#"))
            {
                try
                {
                    // Remove the "#" symbol from the HEX string
                    string colorPart = hexString.Substring(1);
                    return Color.FromArgb(colorPart);                    
                }
                catch (FormatException)
                {
                    // Håndter invalid HEX Format
                    return null; // eller f.eks en defualt Color
                    
                }
            }
            // Hvis det object der skal Converteres allerede er af typen Maui.Grpahics.Color
            // Så skal det ikke Converteres.
            else if (value is Microsoft.Maui.Graphics.Color color)
            {
                // Hvis objectet der prøves at convertere allerede en en Color, så bare returner det.
                return color;
            }            
            else
            {
                return null; 
            }
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is Color color)
            {
                return color.ToHex(); // Get HEX string from Color object
            }
            else
            {
                return null; // Or return a default string
            }
        }
    }
}
