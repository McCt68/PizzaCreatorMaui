using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaCreatorMaui.MVVM.Models
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
    }
}
