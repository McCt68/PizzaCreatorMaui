using PizzaCoreBuisnessLogic.Models;
using PizzaCoreBuisnessLogic.UseCases;
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
        #region Text and Mail Validation
        // Using Nuget package MauiCommunityToolkit for text, and email validation.
        public bool IsNameProvided { get; set; }
        public bool IsAddressProvided { get; set; }        
        public bool IsEmailProvided { get; set; }
        public bool IsEmailFormatValid { get; set; }
        #endregion        

        // Definer CurrentCustomer af typen Customer fra CoreBuisness Project.
        public PizzaCoreBuisnessLogic.Models.Customer CurrentCustomer { get; set; }
        
        #region Navigation Properties
        public decimal TotalPizzaPrice { get; set; }        
        public PizzaSize CurrentCarouselItem { get; set; }       
        public ObservableCollection<Topping> UserSelectedToppings { get; set; }
        #endregion

        // Clear user Inputs / Dont think i use the obj here ?
        public ICommand ClearUserInfoCommand =>
            new Command((obj) => 
            {
                App.Current.MainPage.DisplayAlert("Reset fields", "Reset all user info", "OK");
                
                ClearUserInputsUseCase clearUserInputs = new ClearUserInputsUseCase(CurrentCustomer);
                clearUserInputs.ClearUserInputs();                
            });       

        #region Navigation            
        // Denne kan forbedres så enten switch knappen i PizzaCreatorView bliver nulstillet, -
        // eller at den fobliver hvor den er, men så skal den loadede liste blive -
        // hvor den kom fra da jeg navigerede herhen
        public ICommand NavigateBackCommand =>
            new Command(async () => await Shell.Current.GoToAsync(".."));        
        #endregion

        #region Constructors
        // public CustomerViewModel(IClearUserData clearUserInputsUseCase)
        public CustomerViewModel()
        // public CustomerViewModel(IClearUserData clearUserInputsUseCase, Customer customer)
        {                        
            CurrentCustomer = new PizzaCoreBuisnessLogic.Models.Customer();                                  
        }
        #endregion

        public ICommand PlaceOrderCommand =>
            new Command(async () =>
            {
                // This works
                //ValidateCustomer();
                await ValidateCustomer();                                                                        
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
            await Application.Current.MainPage.DisplayAlert(
                "Order Completed",
                $"\nHello {CurrentCustomer.CustomerName}.\n" +

                $"\nYour Total is: {TotalPizzaPrice} Kr.\n" +

                $"Your Pizza Size is: {CurrentCarouselItem.Size}.\n" +

                $"Your Pizza Topings are: {UserSelectedToppings.Count}.\n- " +

                // Brug LINQ - laver en ny Collection der kun indeholder ToppingName fra alle UserSelectedToppings
                // Og Joiner dem i en samlet komma seperaret string med hvert navn på en ny linie
                string.Join("\n- ", UserSelectedToppings.Select(topping => topping.ToppingName)),

                "OK");

            return true;            
        }
        #endregion
    }
}



