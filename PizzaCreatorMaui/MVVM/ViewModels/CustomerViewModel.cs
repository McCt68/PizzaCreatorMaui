
using PizzaCreatorMaui.MVVM.Models;
using PropertyChanged;
using System.Windows.Input;

namespace PizzaCreatorMaui.MVVM.ViewModels
{
    // Teste passing parameters with shell - Skal lige forstå det her bedre ??
    [QueryProperty(nameof(TotalPizzaPrice), nameof(TotalPizzaPrice))]

    [AddINotifyPropertyChangedInterface]
    public class CustomerViewModel
    {
        #region Properties
        public Customer CurrentCustomer { get; set; }// = new Customer();
        public decimal TotalPizzaPrice { get; set; }
        #endregion

        // Clear user Inputs - Try to make use of a UseCase instead
        public ICommand ClearUserInfo =>
            new Command(() => 
            {
                ClearUserInputs();
                //if(CurrentCustomer.CustomerName != string.Empty)
                //{
                //    CurrentCustomer.CustomerName = string.Empty;
                //}
                //else
                //{
                //    return;
                //}
                // var testVar = CurrentCustomer.CustomerName;
                // CurrentCustomer.CustomerName = string.Empty
            });

        #region Naviagation        
        public ICommand NavigateBack =>
            new Command(async () => await Shell.Current.GoToAsync(".."));

        // new Command(async () => await Shell.Current.GoToAsync($".." ? TotalPizzaPrice ={TotalPizzaPrice}));
        #endregion

        public CustomerViewModel()
        {
            CurrentCustomer = new Customer();

        }

        private void ClearUserInputs()
        {
            CurrentCustomer.CustomerName = "Set string to empty";
            // CurrentCustomer.CustomerName = string.Empty;
        }
    }
}


// DETTE VAR FØR MVVM TOOLKIT OG DET VIRKET`UNDTAGEN RESET COMMAND
// Teste passing parameters with shell - Skal lige forstå det her bedre ??
//[QueryProperty(nameof(TotalPizzaPrice), nameof(TotalPizzaPrice))]

//[AddINotifyPropertyChangedInterface]
//public class CustomerViewModel
//{
//    #region Properties
//    public Customer CurrentCustomer { get; set; } = new Customer();
//    public decimal TotalPizzaPrice { get; set; }
//    #endregion

//    // Clear user Inputs - Try to make use of a UseCase instead
//    public ICommand ClearUserInfo =>
//        new Command(() =>
//        {
//            CurrentCustomer.CustomerName = string.Empty;
//        });

//    #region Naviagation        
//    public ICommand NavigateBack =>
//        new Command(async () => await Shell.Current.GoToAsync(".."));

//    // new Command(async () => await Shell.Current.GoToAsync($".." ? TotalPizzaPrice ={TotalPizzaPrice}));
//    #endregion

//    public CustomerViewModel()
//    {

//    }

//}


// NYT TEST MED MVVM TOOLKIT: SOM JEG IKKE RBUGER HJUS AT FJERNE MVVM TOOLKIT
//[QueryProperty(nameof(TotalPizzaPrice), nameof(TotalPizzaPrice))]
//public partial class CustomerViewModel : ObservableObject
//{
//    #region Properties
//    [ObservableProperty]
//    private Customer currentCustomer; // { get; set; } = new Customer();

//    // This may not work since I used another library for the observable object

//    public decimal TotalPizzaPrice { get; set; }
//    #endregion

//    // Clear user Inputs - Try to make use of a UseCase instead
//    public ICommand ClearUserInfo =>
//        new Command(() =>
//        {
//            CurrentCustomer.CustomerName = string.Empty;
//        });

//    #region Naviagation        
//    public ICommand NavigateBack =>
//        new Command(async () => await Shell.Current.GoToAsync(".."));

//    // new Command(async () => await Shell.Current.GoToAsync($".." ? TotalPizzaPrice ={TotalPizzaPrice}));
//    #endregion

//    public CustomerViewModel()
//    {

//    }

//}
