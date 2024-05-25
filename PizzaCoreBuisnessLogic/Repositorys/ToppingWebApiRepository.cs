using PizzaCoreBuisnessLogic.Models;
using PizzaCoreBuisnessLogic.Utilities;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Text.Json;

// This file contains the HTTP client that I kinda use to talk to the WebApi

// TODO - Maybe I can use LINQ here if i put some data in the Collection that I dont want to show -
// i can use link to filter it out

namespace PizzaCoreBuisnessLogic.Repositorys
{
    public class ToppingWebApiRepository : IToppingRepository
    {
        // Not sure if i need this
        public RandomColorGenerator TestColor { get; set; } = new RandomColorGenerator();

        // In order to talk to the WebApi I need a Http client object
        // Create a httpClient I can use to communicate with the WebApi -
        // The repsonse the client return is a string formatted in JSon.
        private HttpClient _httpClient;

        // Http client returns a string in Json format, to be able use it I need to D/Serialize it, and configure -
        // how I wan't to do that in this class contructor.
        private JsonSerializerOptions _jsonSerializerOptions;

        public ToppingWebApiRepository()
        {
            _httpClient = new HttpClient();

            // An instance of the JsonSerializerOptions class from the Newtonsoft.Json library.
            // It specifies how JSON data is serialized and deserialized.
            // In this case, it is set to use camel case naming and indent the JSON output for better readability.
            _jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
        }


        public async Task<ObservableCollection<Topping>> GetToppingsAsync()
        {
            var toppings = new ObservableCollection<Topping>();

            // http addressen virker i .net maui android - 10.0.2.2 er for android - Læs docs her
            // https://learn.microsoft.com/en-us/dotnet/maui/data-cloud/local-web-services?view=net-maui-8.0#local-web-services-running-over-http
            Uri uri = new Uri("http://10.0.2.2:5133/api/toppings");
            
            var response = await _httpClient.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                toppings = JsonSerializer.Deserialize<ObservableCollection<Topping>>(content, _jsonSerializerOptions);
            }

            // Maybe I should use the IValueConverter to convert the color type here

            //SystemColorToMauiColorConverter myColorConverter = new SystemColorToMauiColorConverter();
            //foreach (var topping in toppings) 
            //{
            //    topping.ToppingImage
            //    System.Drawing.Color color = topping.ToppingImage;
            //    Microsoft.Maui.Graphics.Color = myColorConverter.Convert(topping.ToppingImage);
            //}


            return toppings;
        }
    }    
}
