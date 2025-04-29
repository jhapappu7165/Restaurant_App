/*
I acknowledge the following statements:

1. That the code I provide below is my own work and NOT copied from any outside resource, which includes, but not limited to, an artificial intelligence program unless given explicit permission by the instructor.

2. That the code I provide below is my own work and NOT the work of my peers, tutors, or any other individual unless given explicit permission by the instructor.

3. That if the code below is in violation of statements 1 and 2 above, I may be reported to the Academic Integrity office and subject to penalties as described in the Academic Integrity Policy.

Your Name: Pappu Jha
Your Student ID: w10168315
*/



using RestaurantAppFullImp.Project.Services;

using Microsoft.Maui.Controls.Platform;
using RestaurantAppFullImp.Project.Models;
using System.Collections.ObjectModel;
using System.Xml.Schema;

namespace RestaurantAppFullImp.Project.Views;

public partial class MainMenuPage : ContentPage
{
	bool CartShown = true;
	ObservableCollection<CartPopupItemView> view_items;

    public MainMenuPage()
	{
		InitializeComponent();
        collCart.IsVisible = true;

		view_items = new();

		var controller_items = App.Cart.GetCartItems();

		foreach( var item in controller_items )
		{
			CartPopupItemView cartPopupItemView = new CartPopupItemView();
			cartPopupItemView.Item = item;
			view_items.Add(cartPopupItemView);
		}

		collCart.ItemsSource = view_items;
    }

	private void ButtonToggleCart(object sender, EventArgs e)
	{
		if (CartShown)
		{
			CartShown = false;
			grdPageFrame.ColumnDefinitions[1].Width = 80;
			collCart.IsVisible = false;
			layoutCartControls.IsVisible = false;
        }
		else
		{
			CartShown = true;
            grdPageFrame.ColumnDefinitions[1].Width = 300;
            collCart.IsVisible = true;
			layoutCartControls.IsVisible = true;
        }
	}

    private void ButtonBuildCombo(object sender, EventArgs e)
    {
		App.Current.Windows[0].Page = new ComboBuilderPage();
    }

    private void ButtonDeleteCartItems(object sender, EventArgs e)
    {
		ObservableCollection<CartPopupItemView> selected = new();

        foreach (var selected_item in collCart.SelectedItems)
		{
            CartPopupItemView? item = (selected_item as CartPopupItemView);
			if (item != null)
			{
				App.Cart.RemoveItem(item.Item.ID);
				selected.Add(item);
			}
		}

		foreach (var item in selected)
			view_items.Remove(item);
    }

    private void ButtonCheckoutCart(object sender, EventArgs e)
    {
		App.Current.Windows[0].Page = new Project.Views.CheckoutView();
    }

    private void ButtonAddEntree(object sender, EventArgs e)
    {
		App.Current.Windows[0].Page = new Project.Views.ItemAddPage(MenuItemType.ENTREE);
    }

    private void ButtonAddSide(object sender, EventArgs e)
    {
        App.Current.Windows[0].Page = new Project.Views.ItemAddPage(MenuItemType.SIDE);
    }

    private void ButtonAddDrink(object sender, EventArgs e)
    {
        App.Current.Windows[0].Page = new Project.Views.ItemAddPage(MenuItemType.DRINK);
    }

    private void ButtonAddDessert(object sender, EventArgs e)
    {
        App.Current.Windows[0].Page = new Project.Views.ItemAddPage(MenuItemType.DESSERT);
    }
}