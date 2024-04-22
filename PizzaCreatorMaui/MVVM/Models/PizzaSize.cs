using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaCreatorMaui.MVVM.Models
{
    public class PizzaSize
    {
        // This works
        public enum Sizes
        {
            Small,
            Medium,
            Large,
        }
        // Virker
        public Sizes Size { get; set; }        
        public decimal Price { get; set; }


        // Defualt constrcutor this works
        public PizzaSize()
        {
            
        }
        public PizzaSize(PizzaSize.Sizes size, decimal price)
        {
            Size = size;
            Price = price;
        }


    }
}
