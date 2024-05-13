//using Microsoft.Maui.Graphics.Converters;
//using System;
//using System.Collections.Generic;
//using System.Globalization;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace PizzaCoreBuisnessLogic.Utilities
//{
//    public class StringToColorConverter : IValueConverter
//    {
//        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
//        {
//            string colorString = value as string;
//            if (string.IsNullOrEmpty(colorString))
//            {
//                return Colors.Transparent; // Or a default color
//            }

//            try
//            {
//                // Try converting hex string
//                if (colorString.StartsWith("#"))
//                {
//                    return Color.Parse(colorString.Substring(1)); // Use Color.Parse for hex strings
//                }
//                else
//                {
//                    // Handle named colors (optional)
//                    return Color.FromName(colorString, true); // Case-insensitive
//                }
//            }
//            catch (Exception)
//            {
//                // Handle conversion errors (e.g., invalid hex string, unknown named color)
//                return Colors.Gray; // Or a fallback color
//            }
//        }

//        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
//        {
//            throw new NotImplementedException(); // Not required for one-way binding
//        }
//    }
//}
