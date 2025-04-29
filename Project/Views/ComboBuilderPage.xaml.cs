/*
I acknowledge the following statements:

1. That the code I provide below is my own work and NOT copied from any outside resource, which includes, but not limited to, an artificial intelligence program unless given explicit permission by the instructor.

2. That the code I provide below is my own work and NOT the work of my peers, tutors, or any other individual unless given explicit permission by the instructor.

3. That if the code below is in violation of statements 1 and 2 above, I may be reported to the Academic Integrity office and subject to penalties as described in the Academic Integrity Policy.

Your Name: Pappu Jha
Your Student ID: w10168315
*/


using System.Collections.ObjectModel;

namespace RestaurantAppFullImp.Project.Views;
using RestaurantAppFullImp.Project.Models;

public partial class ComboBuilderPage : ContentPage
{
	MenuItem? selectedEntree = null;
	MenuItem? selectedSide = null;
	MenuItem? selectedDrink = null;
	Models.MenuSizeType MealSize = Models.MenuSizeType.SMALL;

    public ComboBuilderPage()
	{
		InitializeComponent();

		var entrees = App.Menu.GetItems(MenuItemType.ENTREE);
		var sides = App.Menu.GetItems(MenuItemType.SIDE);
		var drinks = App.Menu.GetItems(MenuItemType.DRINK);

		ObservableCollection<ComboItemView> entreeViews = new();
		foreach (var entree in entrees)
		{
			RestaurantAppFullImp.Project.Models.MenuItem item  = entree.DeepCopy();
			entreeViews.Add(new ComboItemView { Item = item });
		}
		ObservableCollection<ComboItemView> sideViews = new();
		foreach (var side in sides)
		{
            MenuItem item = side.DeepCopy();
            sideViews.Add(new ComboItemView { Item = item });
		}
		ObservableCollection<ComboItemView> drinkViews = new();
		foreach (var drink in drinks)
		{
            MenuItem item = drink.DeepCopy();
            drinkViews.Add(new ComboItemView { Item = item });
		}
		collEntreeSelection.ItemsSource = entreeViews;
		collSideSelection.ItemsSource = sideViews;
		collDrinkSelection.ItemsSource = drinkViews;

		collSizeSelection.ItemsSource = new ObservableCollection<SizeTypeView>
		{
            new SizeTypeView {Text = "Small" },
            new SizeTypeView {Text = "Medium", Rate=$"+{MenuItem.MEDIUM_RATE:F2}%" },
            new SizeTypeView {Text = "Large", Rate=$"+{MenuItem.LARGE_RATE:F2}%" }
        };
	}

	private void SelectEntree(object sender, SelectionChangedEventArgs e)
	{

		if (collEntreeSelection.SelectedItem == null)
			return;
		else
			selectedEntree = (collEntreeSelection.SelectedItem as ComboItemView).Item;

		RefreshCost();
	}

	private void SelectSide(object sender, SelectionChangedEventArgs e)
	{
		if (collSideSelection.SelectedItem == null)
			return;
		else
			selectedSide = (collSideSelection.SelectedItem as ComboItemView).Item;

        RefreshCost();
	}

	private void SelectDrink(object sender, SelectionChangedEventArgs e)
	{
		if (collDrinkSelection.SelectedItem == null)
			return;
		else
			selectedDrink = (collDrinkSelection.SelectedItem as ComboItemView).Item;

        RefreshCost();
	}
    private void SelectSize(object sender, SelectionChangedEventArgs e)
    {
        if (collSizeSelection.SelectedItem == null)
            return;
        else
		{
			SizeTypeView s = (SizeTypeView)collSizeSelection.SelectedItem;

			if (s != null && s.Text == "Small")
				MealSize = MenuSizeType.SMALL;
			else if (s != null && s.Text == "Medium")
				MealSize = MenuSizeType.MEDIUM;
			else if (s != null && s.Text == "Large")
				MealSize = MenuSizeType.LARGE;
		}

        RefreshCost();
    }

    void RefreshCost()
	{
		if (selectedEntree == null || selectedSide == null || selectedDrink == null)
			lblCost.Text = "";
		else
		{
			Project.Models.ComboItem c = new();
			c.Entree = selectedEntree;
			c.Side = selectedSide;
			c.Drink = selectedDrink;

			if (c.Entree.HasSize)
				c.Entree.Size = MealSize;
			if(c.Side.HasSize)
				c.Side.Size = MealSize;
			if(c.Drink.HasSize)
				c.Drink.Size = MealSize;

			lblCost.Text = $"${c.GetCost():F2}";
		}
	}

    private async void AddComboClicked(object sender, EventArgs e)
    {
		if (selectedEntree == null || selectedSide == null || selectedDrink == null)
			await DisplayAlert("Error", "Error:  You must select a combo, side, and drink.", "Ok");
        else
        {
            Project.Models.ComboItem c = new();      
			c.Entree = selectedEntree;
            c.Side = selectedSide;
            c.Drink = selectedDrink;

			App.Cart.AddItem(c);
			App.Current.Windows[0].Page = new MainMenuPage();
        }
    }
}