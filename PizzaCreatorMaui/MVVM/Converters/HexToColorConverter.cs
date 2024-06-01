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
                    // return Color.FromHex(colorPart);
                }
                catch (FormatException)
                {
                    // Handle invalid HEX format
                    return null; // Or return a default color
                }
            }
            // Begin Test - Testing to see if I can omit convert if its already a Maui Color
            else if (value is Microsoft.Maui.Graphics.Color color)
            {
                // If the value is already a Color, return it directly
                return color;
            }
            // End test
            else
            {
                return null; // Or return a default color
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
