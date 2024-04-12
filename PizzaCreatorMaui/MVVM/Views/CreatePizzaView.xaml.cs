using PizzaCreatorMaui.MVVM.ViewModels;

namespace PizzaCreatorMaui.MVVM.Views;

public partial class CreatePizzaView : ContentPage
{
	public CreatePizzaView()
	{
		InitializeComponent();

		BindingContext = new CreatePizzaViewModel();

	}

  //  private void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
  //  {
		//var selectedElement = e.CurrentSelection;
  //  }
}