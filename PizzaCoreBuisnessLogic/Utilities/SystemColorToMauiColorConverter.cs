using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaCoreBuisnessLogic.Utilities
{
    public class SystemColorToMauiColorConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is System.Drawing.Color drawingColor)
            {
                return new Microsoft.Maui.Graphics.Color(drawingColor.R, drawingColor.G, drawingColor.B, drawingColor.A);
            }

            return null; // Or throw an exception if the conversion fails
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

        
    
}
