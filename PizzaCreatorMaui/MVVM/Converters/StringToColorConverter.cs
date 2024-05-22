using Microsoft.Maui.Graphics.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
