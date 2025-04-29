/*
I acknowledge the following statements:

1. That the code I provide below is my own work and NOT copied from any outside resource, which includes, but not limited to, an artificial intelligence program unless given explicit permission by the instructor.

2. That the code I provide below is my own work and NOT the work of my peers, tutors, or any other individual unless given explicit permission by the instructor.

3. That if the code below is in violation of statements 1 and 2 above, I may be reported to the Academic Integrity office and subject to penalties as described in the Academic Integrity Policy.

Your Name: Pappu Jha
Your Student ID: w10168315
*/



using Microsoft.Maui.Controls;
using RestaurantAppFullImp.Project.Services;
using RestaurantAppFullImp.Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;

// Alias imports
using MauiMenuItem = Microsoft.Maui.Controls.MenuItem;
using ProjectMenuItem = RestaurantAppFullImp.Project.Models.MenuItem;

namespace RestaurantAppFullImp.Project.Views
{
    public partial class MenuDashboardPage : ContentPage
    {
        private readonly DatabaseService _db;
        private List<ProjectMenuItem> _allItems = new();  // ✅ initialized
        private ProjectMenuItem? _selectedItem;            // ✅ nullable

        public MenuDashboardPage(DatabaseService dbService)
        {
            InitializeComponent();
            _db = dbService;
            LoadItems();
        }
        

        private async void LoadItems()
        {
            _allItems = await _db.GetMenuItemsAsync();
            MenuListView.ItemsSource = _allItems;
        }

        private void SearchEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            FilterItems();
        }

        private void TypePicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterItems();
        }

        private void FilterItems()
        {
            var nameFilter = SearchEntry.Text?.ToLower() ?? "";
            var typeIndex = TypePicker.SelectedIndex - 1; // -1 because "All" is index 0

            var filtered = _allItems
                .Where(item =>
                    item.ItemName.ToLower().Contains(nameFilter) &&
                    (typeIndex == -1 || (int)item.Type == typeIndex)) // 👈 typecast to (int)
                .ToList();

            MenuListView.ItemsSource = filtered;
        }

        private void MenuListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            _selectedItem = (ProjectMenuItem)e.SelectedItem;
        }

        private async void OnAddClicked(object sender, EventArgs e)
        {
            var newItem = new ProjectMenuItem
            {
                ItemName = "New Item",
                ItemPrice = 0,
                HasSize = false,
                Size = MenuSizeType.SMALL,  
                Type = MenuItemType.ENTREE, 
                Icon = "default.png"
            };

            await _db.AddMenuItemAsync(newItem);
            LoadItems();
        }

        private async void OnEditClicked(object sender, EventArgs e)
        {
            if (_selectedItem == null)
                return;

            _selectedItem.ItemName += " (Updated)";
            await _db.UpdateMenuItemAsync(_selectedItem);
            LoadItems();
        }

        private async void OnDeleteClicked(object sender, EventArgs e)
        {
            if (_selectedItem == null)
                return;

            await _db.DeleteMenuItemAsync(_selectedItem);
            LoadItems();
        }
    }
}
