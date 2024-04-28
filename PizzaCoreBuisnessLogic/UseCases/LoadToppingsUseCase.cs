using PizzaCoreBuisnessLogic.Data;
using PizzaCoreBuisnessLogic.Models;
using PizzaCoreBuisnessLogic.UseCases.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaCoreBuisnessLogic.UseCases
{
    public class LoadToppingsUseCase : ILoadToppingsUseCase
    {
        private readonly LocalToppingsData _data;

        public LoadToppingsUseCase(LocalToppingsData data)
        {
            this._data = data;
            _data = new LocalToppingsData();
            _data.GetLocalToppingsData();
        }
        public async Task<ObservableCollection<Topping>> LoadToppingsAsync()
        {
            await Task.Delay(1000);
            return _data.GetLocalToppingsData();
        }
        
    }
}
