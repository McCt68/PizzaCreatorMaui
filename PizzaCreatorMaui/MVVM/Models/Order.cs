using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaCreatorMaui.MVVM.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        // Should be the sum of all pizza prices
        public decimal TotalPrice { get; set; }

        // Belongs to the customer
        public int CustomerId {  get; set; }


    }
}
