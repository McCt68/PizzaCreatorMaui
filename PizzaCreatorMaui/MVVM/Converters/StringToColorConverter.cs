using Microsoft.Maui.Graphics.Converters;
using System.Globalization;

// I Properly Don't even need this one, as I will use the HEX ToColor Converter instead

namespace PizzaCreatorMaui.MVVM.Converters
{
    public class StringToColorConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            ColorTypeConverter converter = new ColorTypeConverter();
            Color color = (Color)(converter.ConvertFromInvariantString((string)value));
            return color; ;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            string colorString = "White"; //TODO

            return colorString;
        }
    }
}
