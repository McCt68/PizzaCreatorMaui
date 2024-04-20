﻿using PizzaCreatorMaui.MVVM.Models;
using PizzaCreatorMaui.MVVM.Views;
using PizzaCreatorMaui.Services;
using PizzaCreatorMaui.Utilities;
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
    // So when using the setter of a Property it will set the -
    // private var in the ViewModelFile, and thereby also update the value of the Coresponding Object in the XAML file.

    [AddINotifyPropertyChangedInterface]
    // Teste passing parameters with shell - Skal lige forstå det her bedre ??
    [QueryProperty(nameof(TotalPizzaPrice), nameof(TotalPizzaPrice))]
    public class CreatePizzaViewModel
    {
        // TODO !
        /*
         * I should load the model data (Always empty when the app initializes) -
         * instead of defining the list in the constrcutor.
         * */

        // Used for testing passing an arguemtn along different ViewModels
        // public string Name { get; set; } 

        public ObservableCollection<PizzaSize> PizzaSizes { get; set; } = new ObservableCollection<PizzaSize>();

        // Property used for handlign the PizzaSize Price
        public decimal SizePrice { get; set; } = new();

        public ObservableCollection<Topping> UserSelectedToppings { get; set; } = new ObservableCollection<Topping>();
        
        // This should be set to the price of the initial selected PizzaSize.Price
        public decimal TotalPizzaPrice { get; set; } = new(); // New way of doing the same, it implicity knows its a decimal
                                            

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
                // Maybe I should define a method to do all this I can call in here                
                UserSelectedToppings.Clear();

                var toppingsList =
                    SelectedToppingsList;

                // Instead I need to get the price of the currentlySelectedSize
                SizePrice = PizzaSizes.FirstOrDefault().Price;
                decimal prize = SizePrice = PizzaSizes.FirstOrDefault().Price;

                // new logic - need to be better
                //if(toppingsList.Count == 0)
                //{
                //    TotalPizzaPrice = prize;
                //}
                //else if (toppingsList.Count > 0)
                //{
                //    foreach (var topping in toppingsList)
                //    {
                //        UserSelectedToppings.Add((Topping)topping);
                //    }

                //    TotalPizzaPrice = UserSelectedToppings.Sum(x => x.ToppingPrice) + prize;
                //    // TotalPizzaPrice = UserSelectedToppings.Sum(x => x.ToppingPrice) ;
                //}
                //else
                //{
                //    TotalPizzaPrice = 0m;
                //    UserSelectedToppings.Clear();
                //}


                // old logic works
                if (toppingsList.Count > 0)
                {
                    foreach (var topping in toppingsList)
                    {
                        UserSelectedToppings.Add((Topping)topping);
                    }

                    TotalPizzaPrice = UserSelectedToppings.Sum(x => x.ToppingPrice) + prize;
                    // TotalPizzaPrice = UserSelectedToppings.Sum(x => x.ToppingPrice) ;
                }
                else
                {
                    TotalPizzaPrice = 0m;
                    UserSelectedToppings.Clear();
                }
            });

        #endregion        

        // Trying with simple DI to inject the ToppingImpl
        //public CreatePizzaViewModel(IToppings localToppings)
        public CreatePizzaViewModel()
        {
            //this.PizzaSizes = new ObservableCollection<PizzaSize>()
            //{                
            //    new PizzaSize {Size = PizzaSize.Sizes.Small},
            //    new PizzaSize {Size = PizzaSize.Sizes.Medium, Price =40m},
            //    new PizzaSize {Size = PizzaSize.Sizes.Large, Price = 45m}
            //};

            this.PizzaSizes = new ObservableCollection<PizzaSize>()
            {
                new PizzaSize (PizzaSize.Sizes.Small, 35m),
                new PizzaSize (PizzaSize.Sizes.Medium, 40m),
                new PizzaSize (PizzaSize.Sizes.Large, 45m)                
            };

            ToppingImpl localToppings = new ToppingImpl();
            this.Toppings = localToppings.GetToppings();                                  
        }

        // Testing navigation with shell
        // Kan jeg turn off animation Tjek GototAsync overloads ?
        public ICommand NavigateToCustomer =>            
            // new Command(async() => await Shell.Current.GoToAsync(nameof(CustomerView)));

            new Command(async() => await Shell.Current.GoToAsync($"{nameof(CustomerView)}?TotalPizzaPrice={TotalPizzaPrice}"));
    }
}
