﻿using PizzaCoreBuisnessLogic.Data.DataFactory;
using PizzaCoreBuisnessLogic.Models;
using PizzaCreatorMaui.MVVM.Views;
using PropertyChanged;
using System.Collections.ObjectModel;
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
                     
        private bool _isVeggieSwitchOn;

        private bool _isToppingsDataLoading;

        public bool IsToppingsDataLoading
        {
            get => _isToppingsDataLoading;
            set
            {
                _isToppingsDataLoading = value;
                // LoadData();
            }
        }
        public bool IsVeggieSwitchOn
        {
            get
            { return _isVeggieSwitchOn; }
            set
            {
                _isVeggieSwitchOn = value;
                LoadData();
                ToppingsSelector();
            }
        }    
        


        // Using the Model from CoreBuisness Project 
        public ObservableCollection<Topping> Toppings { get; set; }
        public ObservableCollection<Topping> UserSelectedToppings { get; set; } = new ObservableCollection<Topping>();


        // MÅSKE SKAL DENNE IKKE VÆRE NEW; MEN SÆTTES I CONSTRUCTOR TIL AT LOADE FRA USECASE
        // DENNE VIRKER MED MODEL FRA DET HER PROJECT
        // public ObservableCollection<Topping> Toppings { get; set; } // = new ObservableCollection<Topping>();

        // PRØVER AT BRUGE MODEL FRA COREBUISNESS PROJECT
        


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

            // TODO MAKE SWITCH SO USER CAN SELECT BETWEEN VEGIE AND MIXED

            // VeggieToppings
            //ObservableCollection<Topping> veggieToppings = ToppingsDataFactory<VeggieToppingsData>.GetToppingsData(new VeggieToppingsData());
            //Toppings = veggieToppings;

            // MixedToppings
            ObservableCollection<Topping> MixedToppings = ToppingsDataFactory<MixedToppingsData>.GetToppingsData(new MixedToppingsData());
            Toppings = MixedToppings;


            // Set the Initial Pizza size to medium
            CurrentCarouselItem = PizzaSizes[1];     
            PizzaSizePrice = CurrentCarouselItem.Price;

            // Total price - Maybe try and retrive this from the useCase in the Class Library
            TotalPizzaPrice = CurrentCarouselItem.Price + TotalToppingsPrice;             
        }

        // Method for selecting toppings with the switch
        private void ToppingsSelector()
        {            
            ObservableCollection<Topping> VeggieToppings = ToppingsDataFactory<VeggieToppingsData>.GetToppingsData(new VeggieToppingsData());
            ObservableCollection<Topping> MixedToppings = ToppingsDataFactory<MixedToppingsData>.GetToppingsData(new MixedToppingsData());

            if (IsVeggieSwitchOn)
            {
                
                this.Toppings.Clear();
                this.Toppings = VeggieToppings;
                this.TotalPizzaPrice = 0;
            }
            else
            {
                this.Toppings.Clear();
                this.Toppings = MixedToppings;
                this.TotalPizzaPrice = 0;
            }
        }
        // Method for showing the user that data is loading while he switch toppings type

        public async Task LoadData()
        {
            IsToppingsDataLoading = true;
            // Your data loading logic here (e.g., API call, database access)
            await Task.Delay(5000); // Simulate data loading time
                                    // Update your data source
            IsToppingsDataLoading = false;
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
