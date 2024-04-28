using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaCoreBuisnessLogic.Utilities
{
    public class RandomColorGenerator
    {
        public Color GetRandomColor()
        {
            Random random = new Random();
            int red = random.Next(0, 256); // Generate a random number between 0 and 255 (inclusive)
            int green = random.Next(0, 256);
            int blue = random.Next(0, 256);
            return Color.FromRgb(red, green, blue);
        }

        public RandomColorGenerator()
        {
            GetRandomColor();
        }
    }
}
