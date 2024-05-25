using Microsoft.Maui.Graphics.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaCoreBuisnessLogic.Utilities
{
    public class StringToColorConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is Microsoft.Maui.Graphics.Color color)
            {
                return color.ToString(); // Convert Color to string (e.g., "FF0000")
            }
            return null; // Handle invalid input gracefully
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is string colorString)
            {
                return Color.FromRgba(colorString); // Convert string back to Color
            }
            return null; // Handle invalid input gracefully
        }
    }
}

//    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
//    {
//        ColorTypeConverter converter = new ColorTypeConverter();
//        Color color = (Color)(converter.ConvertFromInvariantString((string)value));
//        return color;
//    }

//    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
//    {
//        string colorString = "White"; //TODO

//        return colorString;
//    }
//}
