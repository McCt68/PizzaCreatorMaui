using PizzaCoreBuisnessLogic.Models;
using PizzaCoreBuisnessLogic.UseCases.Interfaces;
using PropertyChanged;
using System.Collections.ObjectModel;
using System.Windows.Input;


namespace PizzaCreatorMaui.MVVM.ViewModels
{
    // Using Nuget Package PropertyChanged.Fody - Implement INotifyPropertyChanged behind the schenes -
    // Avoiding to much boiler plate code.
    // In each Property within this class the execution of OnPropertyChanged is -
    // automatically invoked when the setter is called.
    // So when using the setter of a Property it will update the value of the Coresponding Object in the XAML file.
    // With this I can bind to any source property which is part of a XAML control that has a bindable property.
    [AddINotifyPropertyChangedInterface]

    // Passing parameters with shell - Skal lige forstå det her bedre ??    
    [QueryProperty(nameof(TotalPizzaPrice), nameof(TotalPizzaPrice))]    
    [QueryProperty(nameof(UserSelectedToppings), nameof(UserSelectedToppings))]     
    [QueryProperty(nameof(CurrentCarouselItem), nameof(CurrentCarouselItem))]
    public class CreatePizzaViewModel
    {
        #region PizzaSize       
        public decimal PizzaSizePrice { get; set; } = decimal.Zero;
        public PizzaSize CurrentCarouselItem { get; set; } 
        public ObservableCollection<PizzaSize> PizzaSizes { get; set; }  
        public ICommand PizzaSizeChanged =>
            new Command(() =>
            {
                PizzaSizePrice = CurrentCarouselItem.Price;
                TotalPizzaPrice = PizzaSizePrice + TotalToppingsPrice;
            });
        #endregion

        #region Toppings

        private bool _isVeggieSwitchOn;

        public bool IsVeggieSwitchOn
        {
            get
            { return _isVeggieSwitchOn; }
            set
            {
                _isVeggieSwitchOn = value;

                ToppingsSelector();
            }
        }

        public ObservableCollection<Topping> Toppings { get; set; }
        public ObservableCollection<Topping> UserSelectedToppings { get; set; } = new ObservableCollection<Topping>();

        // Property used for handling the SelectedToppings from the CollectionView in the XAML file
        public List<object> SelectedToppingsList { get; set; } =
            new List<object>();

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

        public decimal TotalPizzaPrice { get; set; } = new(); // Implicity knows its a decimal. set to default value zero

        private readonly ILoadToppingsUseCase loadToppingsUseCase;

        // Bruger DI til at give ILoadToppingsUseCase.
        // public CreatePizzaViewModel(ILoadToppingsUseCase loadToppingsUseCase)
        public CreatePizzaViewModel(ILoadToppingsUseCase loadToppingsUseCase, ObservableCollection<PizzaSize> pizzaSizes)
        {
            this.loadToppingsUseCase = loadToppingsUseCase;

            this.Toppings = new ObservableCollection<Topping>();

            this.PizzaSizes = pizzaSizes;

            // This should not be declared here, but loaded from the corebuisness model instead
            // Or better provided by DI
            // TEST REMOVE THIS AND GET IT FROM CONSTRUCTOR WITH DI
            //this.PizzaSizes = new ObservableCollection<PizzaSize>()
            //{
            //    new PizzaSize (PizzaSize.Sizes.Small, 35m),
            //    new PizzaSize (PizzaSize.Sizes.Medium, 40m),
            //    new PizzaSize (PizzaSize.Sizes.Large, 45m)
            //};
            // END TEST SIZE SIZE TEST END !!!!

            // Set the Initial Pizza size to medium
            CurrentCarouselItem = PizzaSizes[1];
            PizzaSizePrice = CurrentCarouselItem.Price;

            // Total price - Maybe try and retrive this from the useCase in the Class Library
            TotalPizzaPrice = CurrentCarouselItem.Price + TotalToppingsPrice;
        }

        // Method for selecting toppings with the switch      
        private async void ToppingsSelector()        
        {            
            this.TotalToppingsPrice = 0;          
            this.SelectedToppingsList.Clear();            
            this.TotalPizzaPrice = this.PizzaSizePrice;

            // Hent Toppings fra CoreBuisnessLogic Library ved hjælp af UseCases
            if (IsVeggieSwitchOn)
            {                
                this.Toppings = await loadToppingsUseCase.LoadWebApiToppingsAsync();                               
            }
            else
            {                
                this.Toppings = await loadToppingsUseCase.LoadInMemoryToppingsAsync();

                // Bruge metoden her i ViewModel til at gøre det samme
                // await LoadToppingsAsync();                
            }

            // Hvorfor behøver jeg dette her ?
            this.UserSelectedToppings.Clear();
            // this.TotalToppingsPrice = 0;
        }


        // -------------************ MAYBE I CAN OMIT THIS *********----------
        // Load Data from the Usecase
        public async Task LoadToppingsAsync()
        {            
            var toppings = await loadToppingsUseCase.LoadInMemoryToppingsAsync();

            // Set the ObservableCollection af Toppings brugeren ser til den collection der kommer fra USeCase.
            Toppings = toppings;
        }

        // Load Toppings From Web Api
        public async Task LoadWebApiToppingsAsync()
        {            
            var toppings = await loadToppingsUseCase.LoadWebApiToppingsAsync();
            
            Toppings = toppings;
        }

        // END OMIT THIS THIS OMIT END END

        // Bruger denne til at resette switch knappen
        public void ResetSwitch()
        {
            IsVeggieSwitchOn = false; 
        }

        // Navigation med shell
        // Jeg kan navigere til de sider der er specificeret som Routes i classen AppShell.xaml.cs             
        // Parametre bliver sendt med som et Dictionary af k:String V:object
        public ICommand NavigateToCustomer =>
            new Command(async () => await Shell.Current.GoToAsync($"customer",
                new Dictionary<string, object>()
                {
                    {"TotalPizzaPrice", TotalPizzaPrice },
                    // {"PizzaSizePrice", PizzaSizePrice },
                    {"UserSelectedToppings", UserSelectedToppings },
                    {"CurrentCarouselItem", CurrentCarouselItem }
                }));

        //Denne virker med et parameter kun
        // new Command(async () => await Shell.Current.GoToAsync($"{nameof(CustomerView)}?TotalPizzaPrice={TotalPizzaPrice}"));
        
        // Denne virker også med bedre syntax
        // new Command(async () => await Shell.Current.GoToAsync($"customer?TotalPizzaPrice={TotalPizzaPrice}"));        
    }
}





