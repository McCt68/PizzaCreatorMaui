using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// NOT USED YET - BE AWARE WHERE THE MODEL I USE COME FROM !

namespace PizzaCoreBuisnessLogic.Models
{
    public class Pizza
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public PizzaSize Size { get; set; }
        public List<Topping> Toppings { get; set; }
    }
}
