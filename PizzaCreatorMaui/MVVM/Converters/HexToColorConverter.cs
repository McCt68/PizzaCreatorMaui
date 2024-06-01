using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
