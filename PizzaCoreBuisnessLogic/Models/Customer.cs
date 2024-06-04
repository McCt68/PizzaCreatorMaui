﻿using PropertyChanged;

namespace PizzaCoreBuisnessLogic.Models
{
    [AddINotifyPropertyChangedInterface]
    public class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerPhone { get; set; }
        public string Email { get; set; }
    }
}
