/*
I acknowledge the following statements:

1. That the code I provide below is my own work and NOT copied from any outside resource, which includes, but not limited to, an artificial intelligence program unless given explicit permission by the instructor.

2. That the code I provide below is my own work and NOT the work of my peers, tutors, or any other individual unless given explicit permission by the instructor.

3. That if the code below is in violation of statements 1 and 2 above, I may be reported to the Academic Integrity office and subject to penalties as described in the Academic Integrity Policy.

Your Name: Pappu Jha
Your Student ID: w10168315
*/

using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;
using RestaurantAppFullImp.Project.Models;
using ProjectMenuItem = RestaurantAppFullImp.Project.Models.MenuItem;

namespace RestaurantAppFullImp.Project.Services
{
    public class DatabaseService
    {
        private readonly SQLiteAsyncConnection _database;

        public DatabaseService(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<ProjectMenuItem>().Wait(); 
        }

        public Task<List<ProjectMenuItem>> GetMenuItemsAsync() =>
            _database.Table<ProjectMenuItem>().ToListAsync();

        public Task<int> AddMenuItemAsync(ProjectMenuItem item) =>
            _database.InsertAsync(item);

        public Task<int> UpdateMenuItemAsync(ProjectMenuItem item) =>
            _database.UpdateAsync(item);

        public Task<int> DeleteMenuItemAsync(ProjectMenuItem item) =>
            _database.DeleteAsync(item);

        public async Task SeedDataAsync()
        {
            var items = await GetMenuItemsAsync();
            if (items.Count > 0)
                return; 

            var seedItems = new List<ProjectMenuItem>
            {
                new ProjectMenuItem { ItemName = "Soda", ItemPrice = 1.95M, HasSize = true, Type = MenuItemType.DRINK, Icon = "soda.png" },
                new ProjectMenuItem { ItemName = "Tea", ItemPrice = 1.50M, HasSize = true, Type = MenuItemType.DRINK, Icon = "tea.png" },
                new ProjectMenuItem { ItemName = "Coffee", ItemPrice = 1.25M, HasSize = true, Type = MenuItemType.DRINK, Icon = "coffee.png" },
                new ProjectMenuItem { ItemName = "Buffalo Wings", ItemPrice = 5.95M, HasSize = false, Type = MenuItemType.APPETIZER, Icon = "wings.png" },
                new ProjectMenuItem { ItemName = "Chicken Alfredo", ItemPrice = 13.95M, HasSize = false, Type = MenuItemType.ENTREE, Icon = "chickenalfredo.png" },
                new ProjectMenuItem { ItemName = "Classic Fries", ItemPrice = 1.95M, HasSize = false, Type = MenuItemType.SIDE, Icon = "fries.png" },
                new ProjectMenuItem { ItemName = "Apple Pie", ItemPrice = 5.95M, HasSize = false, Type = MenuItemType.DESSERT, Icon = "applepie.png" }
            };

            foreach (var item in seedItems)
            {
                await AddMenuItemAsync(item);
            }
        }
    }
}