using PizzaCoreBuisnessLogic.Models;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text.Json;

// Denne klasse indeholder en HTTP client som der bruges til at snakke med WebApi
namespace PizzaCoreBuisnessLogic.Repositorys
{
    public class ToppingWebApiRepository : IToppingRepository
    {
        // Not sure if i need this
        // public RandomColorGenerator TestColor { get; set; } = new RandomColorGenerator();

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
            Uri uri = new Uri("http://10.0.2.2:5133/api/toppings"); /// denne er den rigtige der virker

            // Fejler hvis den angivne adresse ikke findes ( Formattet skal være korrekt)
            // Uri uri = new Uri("http://dotcom.gg"); // Test Forkert Adresse

            // Wrap inden i try catch. Hvis der ikke kommer svar eller lignende. 
            try
            {
                var response = await _httpClient.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    toppings = JsonSerializer.Deserialize<ObservableCollection<Topping>>(content, _jsonSerializerOptions);
                }                
                Debug.WriteLine("--- BESKED FRA TRY BLOCK ---");
            }
            catch (HttpRequestException ex)
            {                
                Debug.WriteLine($"--- HEJ FRA CATCH BLOCK {ex.Message} ---");
                // Kunne også bruge en logger til yderligere fejlfinding
            }
            catch (Exception ex) 
            {
                Debug.WriteLine(ex.GetType().ToString());
                Debug.WriteLine($"An error occurred while getting toppings: {ex.Message}");                
            }          
            return toppings;
        }
    }    
}
