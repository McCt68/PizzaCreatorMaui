using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaCoreBuisnessLogic.Models
{
    public class PizzaSize
    {        
        public enum Sizes
        {
            Small,
            Medium,
            Large,
        }        
        public Sizes Size { get; set; }
        public decimal Price { get; set; }        
        
        public PizzaSize(PizzaSize.Sizes size, decimal price)
        {
            Size = size;
            Price = price;
        }
    }
}
