using PizzaCoreBuisnessLogic.Models;
using PizzaCoreBuisnessLogic.UseCases;

// using PizzaCoreBuisnessLogic.UseCases;
using PizzaCoreBuisnessLogic.UseCases.Interfaces;
using PropertyChanged;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace PizzaCreatorMaui.MVVM.ViewModels
{
    // Passing parameters with shell Navigation. 
    [QueryProperty(nameof(TotalPizzaPrice), nameof(TotalPizzaPrice))]    
    [QueryProperty(nameof(UserSelectedToppings), nameof(UserSelectedToppings))]        
    [QueryProperty(nameof(CurrentCarouselItem), nameof(CurrentCarouselItem))]

    [AddINotifyPropertyChangedInterface]
    public class CustomerViewModel
    {
        // private readonly IClearUserData _clearUserInputsUseCase;
        // private readonly Customer _customer;

        #region Text and Mail Validation
        // Using Nuget package MauiCommunityToolkit for text, and email validation.
        public bool IsNameProvided { get; set; }
        public bool IsAddressProvided { get; set; }        
        public bool IsEmailProvided { get; set; }
        public bool IsEmailFormatValid { get; set; }
        #endregion        

        // Defining a CurrentCustomer of type Customer from the CoreBuisness Project.
        public PizzaCoreBuisnessLogic.Models.Customer CurrentCustomer { get; set; }

        // For naviagtion purposes
        #region Naviagtion Properties
        public decimal TotalPizzaPrice { get; set; }        

        public PizzaSize CurrentCarouselItem { get; set; }        

        public ObservableCollection<Topping> UserSelectedToppings { get; set; }

        #endregion

        // Clear user Inputs / Dont think i use the obj here ?
        public ICommand ClearUserInfoCommand =>
            new Command((obj) => 
            {
                App.Current.MainPage.DisplayAlert("Reset fields", "Reset all user info", "OK");

                // Using the usecase from the CoreBuisness Project - Maybe inject this into the constrcutor ??
                ClearUserInputsUseCase clearUserInputs = new ClearUserInputsUseCase(CurrentCustomer);
                clearUserInputs.ClearUserInputs();

                // _clearUserInputsUseCase.ClearUserInputs(); // Denne virker ikke ligenu !!!
            });

        


        #region Navigation    
        
        // Denne kan forbedres så enten switch knappen i PizzaCreatorView bliver nulstillet, -
        // eller at den fobliver hvor den er, men så skal den loadede liste blive -
        // hvor den kom fra da jeg navigerede herhen
        public ICommand NavigateBackCommand =>
            new Command(async () => await Shell.Current.GoToAsync(".."));

        // new Command(async () => await Shell.Current.GoToAsync($".." ? TotalPizzaPrice ={TotalPizzaPrice}));
        #endregion

        #region Constructors
        // public CustomerViewModel(IClearUserData clearUserInputsUseCase)
        public CustomerViewModel()
        // public CustomerViewModel(IClearUserData clearUserInputsUseCase, Customer customer)
        {            
            // prøv denne med DI også
            CurrentCustomer = new PizzaCoreBuisnessLogic.Models.Customer();
            // this._clearUserInputsUseCase = clearUserInputsUseCase;

            

            // this._customer = customer;

            // this.CurrentCustomer = _customer; // TEST TEST
        }
        #endregion

        public ICommand PlaceOrderCommand =>
            new Command(async () =>
            {
                // This works
                //ValidateCustomer();
                await ValidateCustomer();               
                                
                
                // TODO 
                // About validation https://www.youtube.com/watch?v=sNter79tWb4&ab_channel=FrankLiu
                // Validation - Use .NET Mau i toolkit -
                // In the XAML do validation
                // The validation reference. should be in the Command in the ViewModel I think
                // Check if all Properties of CurrentUser is not empty strings, and then if not -
                // send a mail to CurrentUser with all information about the pizza
                // start with the total price
                // Later implement detaisl about toppings, and size
            });
        
        #region Text Validation
        private async Task<bool> ValidateCustomer()
        {
            if (!this.IsNameProvided)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Name is required", "OK");
                return false;
            }

            if (!this.IsAddressProvided)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Address is required", "OK");
                return false;
            }

            if (!this.IsEmailProvided)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Email is required", "OK");
                return false;
            }

            if (!this.IsEmailFormatValid)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Email format not valid", "OK");
                return false;
            }

            // Hvis alle validations er ok så -
            // Giv besked til bruger om hvad ordren indeholder. Når denne placerer Ordren.
            // Dette kunne så åbne betalings løsning eller lignende istedet for en Display Alert.
            // Dette virker inden test
            //await Application.Current.MainPage.DisplayAlert(
            //    "Order Completed",

            //    $"\nYour Total is: {TotalPizzaPrice} Kr.\n" +

            //    $"Your Pizza Size is: {CurrentCarouselItem.Size}.\n" +

            //    $"Your Pizza Topings are: {UserSelectedToppings.Count}.\n- " +                

            //    // Using LINQ
            //    string.Join("\n- ", UserSelectedToppings.Select(topping => topping.ToppingName)), 

            //    "OK");

            // Test med at sende til customer.navn
            await Application.Current.MainPage.DisplayAlert(
                "Order Completed",
                $"\nHello {CurrentCustomer.CustomerName}.\n" +

                $"\nYour Total is: {TotalPizzaPrice} Kr.\n" +

                $"Your Pizza Size is: {CurrentCarouselItem.Size}.\n" +

                $"Your Pizza Topings are: {UserSelectedToppings.Count}.\n- " +

                // Using LINQ
                string.Join("\n- ", UserSelectedToppings.Select(topping => topping.ToppingName)),

                "OK");

            return true;            
        }
        #endregion
    }
}



