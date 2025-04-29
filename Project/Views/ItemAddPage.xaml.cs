/*
I acknowledge the following statements:

1. That the code I provide below is my own work and NOT copied from any outside resource, which includes, but not limited to, an artificial intelligence program unless given explicit permission by the instructor.
2. That the code I provide below is my own work and NOT the work of my peers, tutors, or any other individual unless given explicit permission by the instructor.
3. That if the code below is in violation of statements 1 and 2 above, I may be reported to the Academic Integrity office and subject to penalties as described in the Academic Integrity Policy.

Your Name: PAPPU JHA
Your Student ID: w10168315
*/



using System.Collections.ObjectModel;

namespace RestaurantAppFullImp.Project.Views;
using Project.Models;

public partial class ItemAddPage : ContentPage
{
    private MenuItemType _category;
    private MenuItem? _currentSelection = null;
    private MenuSizeType _chosenSize = MenuSizeType.MEDIUM;
    private static MenuItem? _previousSelection = null;

    public ItemAddPage(MenuItemType category)
    {
        InitializeComponent();
        _category = category;
        Title = $"Please Add a {category}";

        var availableItems = App.Menu.GetItems(_category);
        ObservableCollection<ComboItemView> viewList = new();

        for (int i = 0; i < availableItems.Count; i++)
        {
            var duplicatedItem = availableItems[i].DeepCopy();
            viewList.Add(new ComboItemView { Item = duplicatedItem });
        }

        collItemSelection.ItemsSource = viewList;

        if (_previousSelection != null)
        {
            var restoredItem = viewList.FirstOrDefault(entry => entry.Item.ItemName == _previousSelection.ItemName);
            collItemSelection.SelectedItem = restoredItem;
        }

        collSizeSelection.ItemsSource = new ObservableCollection<SizeTypeView>
        {
            new SizeTypeView { Text = "Medium", Rate = $"+{MenuItem.MEDIUM_RATE:F2}%" },
            new SizeTypeView { Text = "Large", Rate = $"+{MenuItem.LARGE_RATE:F2}%" }
        };
    }

    private void SelectItem(object sender, SelectionChangedEventArgs e)
    {
        if (collItemSelection.SelectedItem == null)
            return;

        _currentSelection = (collItemSelection.SelectedItem as ComboItemView)?.Item;
        _previousSelection = _currentSelection;
        layoutSizeSelectView.IsVisible = _currentSelection?.HasSize == true;
    }

    private void SelectSize(object sender, SelectionChangedEventArgs e)
    {
        if (collSizeSelection.SelectedItem == null)
            return;

        var chosen = (SizeTypeView)collSizeSelection.SelectedItem;
        if (chosen.Text == "Medium")
            _chosenSize = MenuSizeType.MEDIUM;
        else if (chosen.Text == "Large")
            _chosenSize = MenuSizeType.LARGE;
    }

    private async void AddItemClicked(object sender, EventArgs e)
    {
        if (_currentSelection == null)
        {
            await DisplayAlert("Notice", "You need to select an item first.", "OK");
            return;
        }

        if (_currentSelection.HasSize)
        {
            _currentSelection.Size = _chosenSize;
        }

        App.Cart.AddItem(_currentSelection);
        App.Current.Windows[0].Page = new MainMenuPage();
    }
}
