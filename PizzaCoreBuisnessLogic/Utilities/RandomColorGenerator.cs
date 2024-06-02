namespace PizzaCoreBuisnessLogic.Utilities
{
    // Dette er en static klasse. Den kan ikke instantieres. men kan kaldes direkte.
    // De to static metoder, kan også kaldes direkte på selve klassen selv.    
    public static class RandomColorGenerator
    {                         
        public static string GetRandomColorHex()
        {
            Random random = new Random();
            string hexValues = "0123456789ABCDEF";

            // Generate a random hex code string
            string randomColor = "#";
            for (int i = 0; i < 6; i++)
            {
                // Sæt randomColor til sig selv + næste random char fra listen 6 gange 
                randomColor += hexValues[random.Next(hexValues.Length)];
            }
            return randomColor;
        }

        // Bruges ikke Alligevel
        public static Color GetRandomColor()
        {
            Random random = new Random();
            int red = random.Next(0, 256); // Generate a random number between 0 and 255 (inclusive)
            int green = random.Next(0, 256);
            int blue = random.Next(0, 256);
            return Color.FromRgb(red, green, blue);
        }
    }
}
