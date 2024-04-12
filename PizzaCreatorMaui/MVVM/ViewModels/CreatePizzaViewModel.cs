using PizzaCreatorMaui.MVVM.Models;
using PizzaCreatorMaui.Services;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PizzaCreatorMaui.MVVM.ViewModels
{
    // Using Nuget Package PropertyChanged.Fody - Implement INotifyPropertyChanged behind the schenes -
    // Avoiding to much boiler plate code.
    // In each Property within this class the execution of OnPropertyChanged is -
    // automatically invoked when the setter is called.
    // So when using the setter of a Property it will set both the -
    // private var in the ViewModelFile, and also the Coresponding the Object in the XAML file.

    [AddINotifyPropertyChangedInterface]
    internal class CreatePizzaViewModel
    {
        // TODO !
        /*
         * I should load the model data (Alwasy empty when the app initializes) -
         * instead of defining the list in the constrcutor.
         * */

        #region Fields
        // I had to change to type to object instead of Topping.
        // Ask Teacher why, or in fact ask how I can avoid doing this ? (I Dont like doing this, is this a normal aproach ?)
        // private List<object> _selectedToppingsList =  new List<object>();

        // I like this instead of making a list of object. But it don't work with .NET Maui CollectionView
        // private List<Topping> _selectedToppingsList1;        

        private int _totalToppingsPrice;
        #endregion

        public ObservableCollection<Topping> Toppings { get; set; } 

        // Property used for handling the SelectedToppings from the CollectionView in the XAML file
        public List<object> SelectedToppingsList { get; set; } =
            new List<object>();


        #region Commands
        /*
         * The commanding interface provides an alternative approach to implementing commands that -
         * is much better suited to the MVVM architecture. The viewmodel can contain commands, -
         * which are methods that are executed in reaction to a specific activity in the view such as a Button click.
         * Data bindings are defined between these commands and the Button.
         * */

        // From youtube example -- https://www.youtube.com/watch?v=y6txSmc-o9E&ab_channel=deepusTheCoder

        /*
         * Property Declaration:
         *      Declares a public property named PizzaToppingsChangedCommandYT of type ICommand.
         *      
         * Immediate Initialization:
         *      The => syntax is a method expression that initializes the property immediately -
         *      with the value returned by the expression on the right-hand side.
         *      *      
         *  Command Creation:
         *      new Command<object>((obj) => ...) creates a new Command object, specifying that it expects -
         *      an argument of type object when executed. The (obj) => ... part is a lambda expression -
         *      defining the command's execution logic.
         * */
        public ICommand PizzaToppingsChangedCommandYT => new Command<object>((obj) =>
        {
            var selectedItem = obj as Topping;
            decimal TotalPrice = selectedItem.ToppingPrice;
            // can use it now  -----   selectedItem.
        });

        // From Udemy video course
        public ICommand PizzaToppingsChangedCommand =>
            new Command(() =>
            {               
                var toppingsList =
                    SelectedToppingsList;

                var totalPrice = ToppingPrice;

                // Topping myTopping = (Topping)toppingsList.ElementAt(0);
                // myTopping.ToppingPrice = _totalToppingsPrice;

                // Måske virker det her ?
                decimal totalPrice = Toppings.Sum(item => item.ToppingPrice);

            });

        #endregion

        // Er dette en god måde at gøre det på ?
        public CreatePizzaViewModel()
        {
            ToppingImpl localToppings = new ToppingImpl();

            this.Toppings = localToppings.GetToppings();

            // I should preselect the medium Size Pizza
        }

        // Medtode til at beregne pris
        //private void OnSelectionChanged()
        //{
        //    decimal totalPrice = 0;
        //    foreach (var topping in Toppings)
        //    {
        //        topping += topping.
        //    }
        //}


        //public CreatePizzaViewModel()
        //{
        //    this.Toppings = new ObservableCollection<Topping>
        //    {
        //        new Topping
        //        {
        //            ToppingName = "Pineapple",
        //            ToppingPrice = 8m,
        //        },
        //        new Topping
        //        {
        //            ToppingName = "Pineapple",
        //            ToppingPrice = 8m,
        //        },
        //        new Topping
        //        {
        //            ToppingName = "Pineapple",
        //            ToppingPrice = 8m,
        //        },
        //        new Topping
        //        {
        //            ToppingName = "Pineapple",
        //            ToppingPrice = 8m,
        //        },
        //        new Topping
        //        {
        //            ToppingName = "Pineapple",
        //            ToppingPrice = 8m,
        //        },
        //        new Topping
        //        {
        //            ToppingName = "Pineapple",
        //            ToppingPrice = 8m,
        //        },
        //        new Topping
        //        {
        //            ToppingName = "Pineapple",
        //            ToppingPrice = 8m,

        //        },
        //        new Topping
        //        {
        //            ToppingName = "Pineapple",
        //            ToppingPrice = 8m,
        //        },
        //        new Topping
        //        {
        //            ToppingName = "Pineapple",
        //            ToppingPrice = 8m,
        //        },
        //        new Topping
        //        {
        //            ToppingName = "Pineapple",
        //            ToppingPrice = 8m,
        //        },
        //    };


        //    }
    }
}
