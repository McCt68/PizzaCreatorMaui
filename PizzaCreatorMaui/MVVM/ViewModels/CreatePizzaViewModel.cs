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

        public decimal TotalPizzaPrice { get; set; } = 0m;

        public ObservableCollection<Topping> Toppings { get; set; } = new ObservableCollection<Topping>();

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

        public ICommand PizzaToppingsChangedCommand =>
            new Command(() =>
            {               
                var toppingsList =
                    SelectedToppingsList;

                               

            });

        #endregion

        // Er dette en god måde at gøre det på ?
        public CreatePizzaViewModel()
        {
            ToppingImpl localToppings = new ToppingImpl();

            this.Toppings = localToppings.GetToppings();

            // I should preselect the medium Size Pizza
        }

        
    }
}
