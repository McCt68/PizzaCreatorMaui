using PizzaCoreBuisnessLogic.Models;
using PizzaCoreBuisnessLogic.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PizzaCoreBuisnessLogic.Data.DataFactory
{
    public class ToppingsDataFromWebApi : BaseToppingsData
    {
        public RandomColorGenerator TestColor { get; set; } = new RandomColorGenerator();

        // Create a httpClient I can use to communicate with the WebApi -
        // The repsonse the client return is a string formatted in JSon.
        private HttpClient _httpClient;

        // Create a JSonSerializerOptions I can use in this class constrcutor to configure how i want to -
        // D/Serialize the JSon that comes back from the WebApi 
        private JsonSerializerOptions _jsonSerializerOptions;

        public ToppingsDataFromWebApi()
        {
            _httpClient = new HttpClient();
            _jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true,
            };
        }

        // Get Toppings
        public async Task<ObservableCollection<Topping>> GetToppingsAsync()
        {
            var toppings = new ObservableCollection<Topping>();

            // also try this api "https://localhost:7017;http://localhost:5133"
            // web api address - https://localhost:7017/api/toppings
            // 10.0.2.2 er for android ?? -- Mine is at https://localhost:7017/api/toppings // maybe 5270 ??
            var uri = new Uri("http://10.0.2.2:7017/api/toppings"); // Tror ikke det er den rigtige addresse endnu ??
            var response = await _httpClient.GetAsync(uri);

            if(response != null)
            {
                string content = await response.Content.ReadAsStringAsync();
                toppings = JsonSerializer.Deserialize<ObservableCollection<Topping>>(content, _jsonSerializerOptions);
            }

            ToppingsFromApiCollection = toppings;
            return toppings;
        }

        public ObservableCollection<Topping> ToppingsFromApiCollection {  get; set; }

        // I Need to somehow set this to the toppings list i get back from the webapi
        public override ObservableCollection<Topping> GetToppingsData()
        {           
            return ToppingsFromApiCollection;                                              
        }
    }
}
