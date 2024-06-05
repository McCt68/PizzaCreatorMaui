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
        // Disse objecter er specificeret i MauiProgram builder sektionen.
        // Her er det en IEnumrable.               
        public LoadToppingsUseCase(IEnumerable<IToppingRepository> repositories)
        {
            // Find det første repository af denne type og sæt det til variablen
            this.localToppingRepository = repositories.OfType<ToppingInMemoryRepository>().First();   
            this.webApiToppingRepository = repositories.OfType<ToppingWebApiRepository>().First();   
        }

        // Kod de metoder som interfacet indeholder.        
        public async Task<ObservableCollection<Topping>> LoadInMemoryToppingsAsync()
        {            
            return await this.localToppingRepository.GetToppingsAsync();
        }
        public async Task<ObservableCollection<Topping>> LoadWebApiToppingsAsync()
        {            
            return await this.webApiToppingRepository.GetToppingsAsync();
        }
    }
}


