using PizzaCoreBuisnessLogic.Models;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text.Json;

// Denne klasse indeholder en HTTP client som der bruges til at komunikere med WebApi
namespace PizzaCoreBuisnessLogic.Repositorys
{
    public class ToppingWebApiRepository : IToppingRepository
    {               
        // For at kommunikere med WepApi skal jeg bruge et HttpClient object
        // HttpClient bruges til at kommunikere web WebApi, den response der kommer tilbage når -
        // jeg kommunikerer er en string formateret som JSON
        private HttpClient _httpClient;
        
        // Bruges til at Serializere / Desirialisere den string af JSON der kommer tilbage fra HttpClient
        private JsonSerializerOptions _jsonSerializerOptions;

        public ToppingWebApiRepository()
        {
            _httpClient = new HttpClient();            

            // Opretter instans af JsonSerializerOptions class fra Newtonsoft.Json library.
            // Denne specificer hvordan JSON bliver Serialized / Desirialized
            // konfigurer den med CamelCase og indent JSON, så det er nemmere at læse
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
            Uri uri = new Uri("http://10.0.2.2:5133/api/toppings"); // denne er den rigtige der virker

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
            //catch (HttpRequestException ex)
            //{                
            //    Debug.WriteLine($"--- HEJ FRA CATCH BLOCK {ex.Message} ---");
            //    
            //}
            catch (Exception ex) 
            {
                Debug.WriteLine($"Der er opstået en fejl af denne type: {ex.GetType().ToString()}");
                Debug.WriteLine($"--- Fejl ved forsøg på at hente toppings data: {ex.Message} ---");
                // Kunne også bruge en logger til yderligere fejlfinding osv osv
            }
            return toppings;
        }
    }    
}
