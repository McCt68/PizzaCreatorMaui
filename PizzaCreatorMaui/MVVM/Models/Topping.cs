﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaCreatorMaui.MVVM.Models
{
    internal class Topping
    {
        public int Id { get; set; }
        public string ToppingName { get; set; }
        public decimal ToppingPrice { get; set; }
        public string ToppingImage { get; set; }
    }
}
