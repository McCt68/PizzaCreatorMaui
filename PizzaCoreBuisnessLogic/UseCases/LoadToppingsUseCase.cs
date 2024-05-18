using PizzaCoreBuisnessLogic.Models;
using PizzaCoreBuisnessLogic.Repositorys;
using PizzaCoreBuisnessLogic.UseCases.Interfaces;
using System.Collections.ObjectModel;

namespace PizzaCoreBuisnessLogic.UseCases
{           
    public class LoadToppingsUseCase : ILoadToppingsUseCase
    {               
        private readonly IToppingRepository localToppingRepository;
        private readonly IToppingRepository webApiToppingRepository;

        // Når Denne klasse instantieres, så sørger Maui selv for at give konstruktøren -
        // de objecter den har brug for.
        // Disse objecter er specificeret i MAUiProgram builder sektionen.
        // Her er det en IEnumrable.               
        public LoadToppingsUseCase(IEnumerable<IToppingRepository> repositories)
        {
            this.localToppingRepository = repositories.OfType<ToppingInMemoryRepository>().First();   
            this.webApiToppingRepository = repositories.OfType<ToppingWebApiRepository>().First();   
        }

        // Specificer de metoder som interfacet indeholder.        
        public async Task<ObservableCollection<Topping>> LoadInMemoryToppingsAsync()
        {
            // denne skal return local toppings mixed 
            return await this.localToppingRepository.GetToppingsAsync();
        }
        public async Task<ObservableCollection<Topping>> LoadWebApiToppingsAsync()
        {
            // Denne skal return webapi repo veggie
            return await this.webApiToppingRepository.GetToppingsAsync();
        }
    }
}


// Denne ctor virker men kun med et repo
//public LoadToppingsUseCase(IToppingRepository toppingRepository)
//{
//    this.toppingRepository = toppingRepository;
//}

// teste ctor med 2 repo - virker ikke helt men programmet kører uden at manakna vælge
//public LoadToppingsUseCase(IToppingRepository localToppingRepository, IToppingRepository webApiToppingRepository)
//{
//    this.localToppingRepository = localToppingRepository;
//    this.webApiToppingRepository = webApiToppingRepository;
//}



