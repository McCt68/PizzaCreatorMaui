using PizzaCoreBuisnessLogic.Data;
using PizzaCoreBuisnessLogic.Data.DataFactory;
using PizzaCoreBuisnessLogic.Models;
using PizzaCoreBuisnessLogic.UseCases;
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
// using Topping = PizzaCoreBuisnessLogic.Models.Topping;

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
    // [QueryProperty(nameof(TotalPizzaPrice), nameof(TotalPizzaPrice))]
    [QueryProperty(nameof(TotalPizzaPrice), nameof(TotalPizzaPrice))]
    public class CreatePizzaViewModel
    {       
        #region PizzaSize       
        public decimal PizzaSizePrice { get; set; } = decimal.Zero;
        public PizzaSize CurrentCarouselItem { get; set; } // = new PizzaSize(PizzaSize.Sizes.Medium, 40m);
        public ObservableCollection<PizzaSize> PizzaSizes { get; set; } // = new ObservableCollection<PizzaSize>(); 
        public ICommand PizzaSizeChanged =>
            new Command(() =>
            {                
                PizzaSizePrice = CurrentCarouselItem.Price;                
                TotalPizzaPrice = PizzaSizePrice + TotalToppingsPrice;
            });
        #endregion

        #region Toppings

        // This works with the Topping from this project
        //public ObservableCollection<Topping> UserSelectedToppings { get; set; } = new ObservableCollection<Topping>();

        // Using the Model from CoreBuisness Project instead
        public ObservableCollection<Topping> UserSelectedToppings { get; set; } = new ObservableCollection<Topping>();


        // MÅSKE SKAL DENNE IKKE VÆRE NEW; MEN SÆTTES I CONSTRUCTOR TIL AT LOADE FRA USECASE
        // DENNE VIRKER MED MODEL FRA DET HER PROJECT
        // public ObservableCollection<Topping> Toppings { get; set; } // = new ObservableCollection<Topping>();

        // PRØVER AT BRUGE MODEL FRA COREBUISNESS PROJECT
        public ObservableCollection<Topping> Toppings { get; set; }


        // Property used for handling the SelectedToppings from the CollectionView in the XAML file
        public List<object> SelectedToppingsList { get; set; } =
            new List<object>();

        // TRYING TO HAVE A VAR ONLY FOR TOPPINGS PRICE
        public decimal TotalToppingsPrice { get; set; } = new();

        #endregion        


        #region CollectionView
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
         *            
         *  Command Creation:
         *      new Command<object>((obj) => ...) creates a new Command object, specifying that it expects -
         *      an argument of type object when executed. The (obj) => ... part is a lambda expression -
         *      defining the command's execution logic.
         * */

        public ICommand PizzaToppingsChangedCommand =>
            new Command(() =>
            {
                // testing only toppings price
                UserSelectedToppings.Clear();

                var toppingsList =
                    SelectedToppingsList;

                if (toppingsList.Count > 0)
                {
                    foreach (var topping in toppingsList)
                    {
                        UserSelectedToppings.Add((Topping)topping);
                    }

                    TotalToppingsPrice = UserSelectedToppings.Sum(x => x.ToppingPrice); 
                    TotalPizzaPrice = TotalToppingsPrice + PizzaSizePrice;
                }
                else
                {
                    TotalToppingsPrice = 0m;                    
                    UserSelectedToppings.Clear();

                    TotalPizzaPrice = PizzaSizePrice + TotalToppingsPrice;
                }                                
            });
        #endregion


        // This should be set to the total of size + toppings price
        public decimal TotalPizzaPrice { get; set; } = new(); // Implicity knows its a decimal. set to defualt value zero

        // Trying with simple DI to inject the ToppingImpl
        //public CreatePizzaViewModel(IToppings localToppings)
        public CreatePizzaViewModel()
        {                       
            // This should not be declared here, but loaded from the corebuisness model instead
            this.PizzaSizes = new ObservableCollection<PizzaSize>()
            {
                new PizzaSize (PizzaSize.Sizes.Small, 35m),
                new PizzaSize (PizzaSize.Sizes.Medium, 40m),
                new PizzaSize (PizzaSize.Sizes.Large, 45m)
            };                           
            
            // TRYING TO GET TOPPINGS FROM COREBUISNESS FACTORY WAY            
            ObservableCollection<Topping> toppingsTask1 = ToppingsDataFactory<LocalToppingsData1>.GetToppingsData(new LocalToppingsData1());
            Toppings = toppingsTask1;
            // END FACTORY TRY

            // Set the Initial Pizza size to medium
            CurrentCarouselItem = PizzaSizes[1];     
            PizzaSizePrice = CurrentCarouselItem.Price;

            // Total price - Maybe try and retrive this from the useCase in the Class Library
            TotalPizzaPrice = CurrentCarouselItem.Price + TotalToppingsPrice;             
        }

        // Navigation with shell        
        public ICommand NavigateToCustomer =>                     
            new Command(async() => await Shell.Current.GoToAsync($"{nameof(CustomerView)}?TotalPizzaPrice={TotalPizzaPrice}"));
    }
}

/* Stuff from Consctructor that was tested or old ways of doing things
 * 
 * // THIS WORKS FROM MAUI PROJECT
            //this.PizzaSizes = new ObservableCollection<PizzaSize>()
            //{
            //    new PizzaSize (PizzaSize.Sizes.Small, 35m),
            //    new PizzaSize (PizzaSize.Sizes.Medium, 40m),
            //    new PizzaSize (PizzaSize.Sizes.Large, 45m)                
            //};

 * // CAN BE DELETED IF NOT USING MODEL AND BUISNESS FROM MAUI PROJECT
            // Initial list of Toppings FROM MAUI PROJECT
            //ToppingImpl localToppings = new ToppingImpl();
            //this.Toppings = localToppings.GetToppings();

// USING TOPPINGS FROM COREBUISNESS
            //LocalToppingsData localToppingsData = new LocalToppingsData(); 
            //LoadToppingsUseCase localtoppings = new LoadToppingsUseCase(localToppingsData);             
            //this.Toppings = localToppingsData.GetLocalToppingsData();
            // END TRY THAT WORKED
 * */
