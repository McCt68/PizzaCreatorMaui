using PizzaCoreBuisnessLogic.Models;
using PizzaCoreBuisnessLogic.Repositorys;
using PizzaCoreBuisnessLogic.UseCases.Interfaces;
using System.Collections.ObjectModel;

// try this Dont think I need it since it comes from the same project ??
// using Topping = PizzaCoreBuisnessLogic.Models.Topping;

namespace PizzaCoreBuisnessLogic.UseCases
{
    public class LoadToppingsUseCase : ILoadToppingsUseCase
    {
        private readonly IToppingRepository toppingRepository;

        public LoadToppingsUseCase(IToppingRepository toppingRepository)
        {
            this.toppingRepository = toppingRepository;
        }

        // Specify the method that the interface says this implementation must have
        public async Task<ObservableCollection<Topping>> LoadToppingsAsync()
        {
            // 
            return await this.toppingRepository.GetToppingsAsync();           
            
        }








        //private readonly LocalToppingsData _data;

        //// try another constrcutor without parameters
        //public LoadToppingsUseCase()
        //{
        //    LoadToppingsAsync();
        //}

        //public LoadToppingsUseCase(LocalToppingsData data)
        //{
        //    this._data = data;
        //    _data = new LocalToppingsData();
        //    _data.GetLocalToppingsData();
        //}
        //public async Task<ObservableCollection<Topping>> LoadToppingsAsync()
        //{
        //    // THIS WORKS
        //    await Task.Delay(1000);

        //    return _data.GetLocalToppingsData();

        //    // maybe i can use the data from factory in here ? - try to do it from a duplicate method instead
        //    // from another implementation of ILoadToppingsUSeCase
        //}

    }
}
