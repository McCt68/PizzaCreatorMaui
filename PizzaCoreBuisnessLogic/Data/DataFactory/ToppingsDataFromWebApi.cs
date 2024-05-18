//using PizzaCoreBuisnessLogic.Models;
//using PizzaCoreBuisnessLogic.Utilities;
//using System;
//using System.Collections.Generic;
//using System.Collections.ObjectModel;
//using System.Linq;
//using System.Text;
//using System.Text.Json;
//using System.Threading.Tasks;

//namespace PizzaCoreBuisnessLogic.Data.DataFactory
//{
//    public class ToppingsDataFromWebApi : BaseToppingsData
//    {
//        public RandomColorGenerator TestColor { get; set; } = new RandomColorGenerator();

//        // DONT THINK I USE THIS ?? ANd for what if i do ?
//        public ObservableCollection<Topping> ToppingsFromApiCollection { get; set; }

//        // Create a httpClient I can use to communicate with the WebApi -
//        // The repsonse the client return is a string formatted in JSon.
//        private HttpClient _httpClient;

//        // Create a JSonSerializerOptions I can use in this class constrcutor to configure how i want to -
//        // D/Serialize the JSon that comes back from the WebApi 
//        private JsonSerializerOptions _jsonSerializerOptions;

//        public ToppingsDataFromWebApi()
//        {
//            _httpClient = new HttpClient();
//            _jsonSerializerOptions = new JsonSerializerOptions
//            {
//                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
//                WriteIndented = true,
//            };
//        }

//        // DETTE VIRKER, Nu Loader toppings fra API. Toppings bliver dog ikke vist ordenligt -
//        // Der mangler farver stadigvæk

//        public async Task<ObservableCollection<Topping>> GetToppingsAsync()
//        {
//            var toppings = new ObservableCollection<Topping>();

//            // http addressen virker i .net maui android - 10.0.2.2 er for android - Læs docs her
//            // https://learn.microsoft.com/en-us/dotnet/maui/data-cloud/local-web-services?view=net-maui-8.0#local-web-services-running-over-http
//            Uri uri = new Uri("http://10.0.2.2:5133/api/toppings");            

//            // TROR JEG SKAL BRUGE AWAIT SAMMEN MED ASYNC

//            // var response = await _httpClient.GetAsync(uri);

//            // Dette virker. men det er ikke med await og giver derfor ikke mening at bruge async
//            var response = _httpClient.GetAsync(uri).Result;
            
//            if (response.IsSuccessStatusCode)
//            {
//                string content = await response.Content.ReadAsStringAsync();
//                toppings = JsonSerializer.Deserialize<ObservableCollection<Topping>>(content, _jsonSerializerOptions);
//            }


//            // DONT THINK I NEED THIS OR WHY WOULD I ??
//            // ToppingsFromApiCollection = toppings;


//            return toppings;
//        }



//        // Get Toppings from Api

//        // This sorta works ?? - Do not DELTE UNTIL OTHER WAY WORKS.
//        //public async Task<ObservableCollection<Topping>> GetToppingsAsync()
//        //{
//        //    var toppings = new ObservableCollection<Topping>();


//        //    //// 10.0.2.2 er for android ?? 

//        //    // I en anden app bruger de http adressen istedet for og det er denne der virker i .net maui           
//        //    // var uri = new Uri("http://10.0.2.2:5133/api/toppings"); // Tror ikke det er den rigtige addresse endnu ??
//        //    Uri uri = new Uri("http://10.0.2.2:5133/api/toppings"); // Tror ikke det er den rigtige addresse endnu ??

//        //    // Er ikke sikker på om det er denne url. det er den den loader i browser. men umiddelbart skal denne ikke bruges 
//        //    // da https er indviklet med android
//        //    // var uri = new Uri("http://10.0.2.2:7017/api/toppings"); // Tror ikke det er den rigtige addresse endnu ??


//        //    // var response = await _httpClient.GetAsync(uri);
//        //    var response =  _httpClient.GetAsync(uri).Result;

//        //    if(response != null)
//        //    {
//        //        string content = await response.Content.ReadAsStringAsync();
//        //        toppings = JsonSerializer.Deserialize<ObservableCollection<Topping>>(content, _jsonSerializerOptions);
//        //    }

//        //    ToppingsFromApiCollection = toppings;
//        //    return toppings;
//        //}



//        // I Need to somehow set this to the toppings list i get back from the webapi
//        public override async Task <ObservableCollection<Topping>> GetToppingsData()
//        {
//            try
//            {
//                return await GetToppingsAsync();
//                //return ToppingsFromApiCollection;
//            }
//            catch(Exception ex)
//            {
//                Console.WriteLine($"{ex.Message}");
//            }

//            return null;


//        }
//    }
//}
