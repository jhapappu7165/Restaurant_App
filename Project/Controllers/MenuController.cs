/*
I acknowledge the following statements:

1. That the code I provide below is my own work and NOT copied from any outside resource, which includes, but not limited to, an artificial intelligence program unless given explicit permission by the instructor.

2. That the code I provide below is my own work and NOT the work of my peers, tutors, or any other individual unless given explicit permission by the instructor.

3. That if the code below is in violation of statements 1 and 2 above, I may be reported to the Academic Integrity office and subject to penalties as described in the Academic Integrity Policy.

Your Name: Pappu Jha
Your Student ID: w10168315
*/


using System.Collections.ObjectModel;
using RestaurantAppFullImp.Project.Models;
using MenuItem = RestaurantAppFullImp.Project.Models.MenuItem;

namespace RestaurantAppFullImp.Project.Controllers
{
    public class MenuController
    {
        List<MenuItem> _menuItems;

        public MenuController()
        {
            _menuItems = setup_menu();
        }

        public List<MenuItem> GetItems(MenuItemType? type = null)
        {
            if (type == null)
                return new List<MenuItem>(_menuItems);
            else
            {
                var result = from item in _menuItems
                             where item.Type == type
                             select item;

                return result.ToList();
            }
        }

        List<MenuItem> setup_menu()
        {
            return new List<MenuItem>()
            {
                new MenuItem { ItemName = "Seafood Alfredo", Type = MenuItemType.ENTREE, ItemPrice=15.95M},
                new MenuItem { ItemName = "Chicken Alfredo", Type = MenuItemType.ENTREE, ItemPrice=13.95M },
                new MenuItem { ItemName = "Chicken Picatta", Type = MenuItemType.ENTREE, ItemPrice=13.95M },
                new MenuItem { ItemName = "Turkey Club", Type = MenuItemType.ENTREE, ItemPrice=11.95M },
                new MenuItem { ItemName = "Lobster Pie", Type = MenuItemType.ENTREE, ItemPrice=19.95M },
                new MenuItem { ItemName = "Prime Rib", Type = MenuItemType.ENTREE, ItemPrice=20.95M },
                new MenuItem { ItemName = "Shrimp Scampi", Type = MenuItemType.ENTREE, ItemPrice=18.95M },
                new MenuItem { ItemName = "Turkey Dinner", Type = MenuItemType.ENTREE, ItemPrice=13.95M },
                new MenuItem { ItemName = "Stuffed Chicken", Type = MenuItemType.ENTREE, ItemPrice=14.95M },
                new MenuItem { ItemName = "Classic Fries", Type = MenuItemType.SIDE, ItemPrice=1.95M, HasSize=true },
                new MenuItem { ItemName = "Spicy Fries", Type = MenuItemType.SIDE, ItemPrice=2.50M, HasSize=true },
                new MenuItem { ItemName = "Mashed Potatoes", Type = MenuItemType.SIDE, ItemPrice=1.95M, HasSize=true },
                new MenuItem { ItemName = "Steamed Vegetables", Type = MenuItemType.SIDE, ItemPrice=2.50M, HasSize=true },
                new MenuItem { ItemName = "Garden Salad", Type = MenuItemType.SIDE, ItemPrice=2.95M },
                new MenuItem { ItemName = "Loaded Potatos", Type = MenuItemType.SIDE, ItemPrice=3.50M },
                new MenuItem { ItemName = "Mac and Cheese", Type = MenuItemType.SIDE , ItemPrice=2.50M, HasSize=true },
                new MenuItem { ItemName = "Soda", Type = MenuItemType.DRINK, ItemPrice=1.95M, HasSize=true },
                new MenuItem { ItemName = "Tea", Type = MenuItemType.DRINK, ItemPrice=1.50M, HasSize=true },
                new MenuItem { ItemName = "Coffee", Type = MenuItemType.DRINK, ItemPrice=1.25M, HasSize=true },
                new MenuItem { ItemName = "Mineral Water", Type = MenuItemType.DRINK, ItemPrice=2.95M, HasSize=true },
                new MenuItem { ItemName = "Juice", Type = MenuItemType.DRINK, ItemPrice=2.50M, HasSize=true },
                new MenuItem { ItemName = "Buffalo Wings", Type = MenuItemType.APPETIZER, ItemPrice=15.95M },
                new MenuItem { ItemName = "Buffalo Fingers", Type = MenuItemType.APPETIZER, ItemPrice=15.95M },
                new MenuItem { ItemName = "Potato Skins", Type = MenuItemType.APPETIZER, ItemPrice=15.95M },
                new MenuItem { ItemName = "Nachos", Type = MenuItemType.APPETIZER, ItemPrice=15.95M },
                new MenuItem { ItemName = "Mushrooms Caps", Type = MenuItemType.APPETIZER, ItemPrice=15.95M },
                new MenuItem { ItemName = "Shrimp Cocktail", Type = MenuItemType.APPETIZER, ItemPrice=15.95M },
                new MenuItem { ItemName = "Chips and Salsa", Type = MenuItemType.APPETIZER, ItemPrice=15.95M },
                new MenuItem { ItemName = "Apple Pie", Type = MenuItemType.DESSERT, ItemPrice=5.95M },
                new MenuItem { ItemName = "Sundae", Type = MenuItemType.DESSERT, ItemPrice=3.95M },
                new MenuItem { ItemName = "Carrot Cake", Type = MenuItemType.DESSERT, ItemPrice=5.95M },
                new MenuItem { ItemName = "Mud Pie", Type = MenuItemType.DESSERT , ItemPrice=4.95M },
                new MenuItem { ItemName = "Apple Crisp", Type = MenuItemType.DESSERT, ItemPrice=5.95M }
            };
        }
    }
}
