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

    #region Navigation Parameters
    // Passing parameters med shell.   
    [QueryProperty(nameof(TotalPizzaPrice), nameof(TotalPizzaPrice))]    
    [QueryProperty(nameof(UserSelectedToppings), nameof(UserSelectedToppings))]     
    [QueryProperty(nameof(CurrentCarouselItem), nameof(CurrentCarouselItem))]
    #endregion
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
        public ObservableCollection<Topping> Toppings { get; set; }
        public string ToppingsType { get; set; } // Mixed - Veggie

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
         *      Declares a public property named PizzaToppingsChangedCommand of type ICommand.
         *      
         * Immediate Initialization:
         *      The => syntax is a method expression that initializes the property immediately -
         *      with the value returned by the expression on the right-hand side. (Expresion bodied syntax)
         *            
         *  Command Creation:
         *      new Command<object>((obj) => ...) creates a new Command object, specifying that it expects -
         *      an argument of type object when executed. The (obj) => ... part is a lambda expression -
         *      defining the command's execution logic.
         * */

        // Bedre forkalring måske
        // new Command laver en ny concrete implementation af ICommand interfacet -
        // I Constructoren giver jeg en Lambda som parameter. Denne lambda har ikke noget input -
        // og den returnerer heller ikke noget. den udfører bare det kode der er angivet immellem -
        // Curly bracers

        public ICommand PizzaToppingsChangedCommand =>
            new Command(() => 
                {
                    UserSelectedToppings.Clear();

                    var toppingsList =
                        SelectedToppingsList;               

                    if (toppingsList.Count > 0)
                    {                   
                        // Brug af LINQ til type cast
                        // - Implicit using er enabled i .csproj (Derfor den ikke findes i top af denne))
                    
                        // OfType filtrer alle elementer i listen af type Topping
                        foreach (var topping in toppingsList.OfType<Topping>())
                        {                                                                     
                            UserSelectedToppings.Add(topping);

                            // Eller
                            // Add topping object til UserSelectedToppings med Type Casting
                            // UserSelectedToppings.Add((Topping)topping); // Type casting to a Topping
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

        public decimal TotalPizzaPrice { get; set; } = new(); // Implicity ved det er en decimal. sat til default value zero

        private readonly ILoadToppingsUseCase _loadToppingsUseCase;

        #region Constructors
        // Bruger DI til at give ILoadToppingsUseCase og PizzaSize        
        public CreatePizzaViewModel(ILoadToppingsUseCase loadToppingsUseCase, ObservableCollection<PizzaSize> pizzaSizes)
        {
            this._loadToppingsUseCase = loadToppingsUseCase;

            this.Toppings = new ObservableCollection<Topping>();

            this.PizzaSizes = pizzaSizes;            

            // Sæt initial PizzaSize og Price
            CurrentCarouselItem = PizzaSizes[1];
            PizzaSizePrice = CurrentCarouselItem.Price;
            
            TotalPizzaPrice = CurrentCarouselItem.Price + TotalToppingsPrice;
        }
        #endregion

        // Bruger valg af Toppings type.     
        // The main difference is that async void kinda just returns the moment code -
        // inside it hits await and I have no way to know when the execution of that method actually ends.
        // And because it just return and don't await the completion - It could end up in a situation where -
        // the code continues before something else completes
        // Because that something else has no way of telling you whether it completed or not

        // The returned Task object represents the state of the operation.
        // I can ask it if the operation is still running, completed, faulted etc.
        // Much more powerful that just running something in the background -
        // and having no way of communicating with it anymore like when doing it with void.               
        private async Task ToppingsSelector()        
        {            
            this.TotalToppingsPrice = 0;          
            this.SelectedToppingsList.Clear();            
            this.TotalPizzaPrice = this.PizzaSizePrice;

            // Hent Toppings fra CoreBuisnessLogic Library ved hjælp af UseCases
            if (IsVeggieSwitchOn)
            {               
                this.Toppings = await _loadToppingsUseCase.LoadWebApiToppingsAsync();
                this.ToppingsType = "Veggie Toppings.";                                             
            }
            else
            {                
                this.Toppings = await _loadToppingsUseCase.LoadInMemoryToppingsAsync();
                this.ToppingsType = "Mixed Toppings."; 

                // Kunne også bruge metoden her fra ViewModel til at gøre det samme
                // await LoadToppingsAsync();                
            }                        
        }

        #region LoadData From Repository
        // Load Data fra repository, og sæt Toppings ved brug af den Usecase der blev injectet i constructor
        public async Task LoadToppingsAsync()
        {            
            var toppings = await _loadToppingsUseCase.LoadInMemoryToppingsAsync();

            // Set den ObservableCollection af Toppings brugeren ser til den collection der kommer fra UseCase.
            Toppings = toppings;
        }

        // Load fra Web Api
        public async Task LoadWebApiToppingsAsync()
        {            
            var toppings = await _loadToppingsUseCase.LoadWebApiToppingsAsync();            
            Toppings = toppings;
        }
        #endregion

        // Bruger denne til at resette switch knappen
        public void ResetSwitch()
        {
            IsVeggieSwitchOn = false; 
        }
        #region Navigation
        // Navigation med shell
        // Jeg kan navigere til de sider der er specificeret som Routes i Classen AppShell.xaml.cs             
        // Parametre bliver sendt med som et Dictionary af k:String V:object
        public ICommand NavigateToCustomer =>
            new Command(async () => await Shell.Current.GoToAsync($"customer",
                new Dictionary<string, object>()
                {
                    {"TotalPizzaPrice", TotalPizzaPrice },                    
                    {"UserSelectedToppings", UserSelectedToppings },
                    {"CurrentCarouselItem", CurrentCarouselItem }
                }));
        #endregion
    }
}





