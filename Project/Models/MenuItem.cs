/*
I acknowledge the following statements:

1. That the code I provide below is my own work and NOT copied from any outside resource, which includes, but not limited to, an artificial intelligence program unless given explicit permission by the instructor.

2. That the code I provide below is my own work and NOT the work of my peers, tutors, or any other individual unless given explicit permission by the instructor.

3. That if the code below is in violation of statements 1 and 2 above, I may be reported to the Academic Integrity office and subject to penalties as described in the Academic Integrity Policy.

Your Name: Pappu Jha
Your Student ID: w10168315
*/

using SQLite;  
using System;

namespace RestaurantAppFullImp.Project.Models
{
    public enum MenuItemType { ENTREE, SIDE, DRINK, DESSERT, APPETIZER }
    public enum MenuSizeType { SMALL, MEDIUM, LARGE }

    public abstract class CartItem
    {
        private static int _idCounter = 0;
        private static int _id;
        public abstract decimal GetCost();

        public int ID { get { return _id; } }

        public CartItem()
        {
            _id = _idCounter++;
        }
    }

    public class MenuItem : CartItem
    {
        public static decimal MEDIUM_RATE = 0.25M;
        public static decimal LARGE_RATE = 0.75M;

        [PrimaryKey, AutoIncrement]  
        public int DatabaseID { get; set; } = 0;

        public string ItemName { get; set; } = "NA";

        public decimal ItemPrice { get; set; } = 0.0M;

        public bool HasSize { get; set; } = false;

        public MenuSizeType Size { get; set; } = MenuSizeType.SMALL;

        public MenuItemType Type { get; set; } = MenuItemType.ENTREE;

        public string Icon { get; set; } = "eagle.png";

        public override decimal GetCost()
        {
            if (!HasSize)
                return ItemPrice;
            else
            {
                if (Size == MenuSizeType.SMALL)
                    return ItemPrice;
                else if (Size == MenuSizeType.MEDIUM)
                    return ItemPrice + ItemPrice * MEDIUM_RATE;
                else
                    return ItemPrice + ItemPrice * LARGE_RATE;
            }
        }

        public MenuItem DeepCopy()
        {
            return new MenuItem
            {
                DatabaseID = this.DatabaseID,
                ItemName = this.ItemName,
                ItemPrice = this.ItemPrice,
                HasSize = this.HasSize,
                Size = this.Size,
                Type = this.Type,
                Icon = this.Icon
            };
        }
    }

    public class ComboItem : CartItem
    {
        public static decimal DiscountRate = 0.10M;
        public MenuItem? Entree { get; set; }
        public MenuItem? Side { get; set; }
        public MenuItem? Drink { get; set; }


        public decimal Cost
        {
            get
            {
                decimal sum = Entree.GetCost() + Side.GetCost() + Drink.GetCost();
                sum = sum - sum * DiscountRate;
                return sum;
            }
        }

        public override decimal GetCost()
        {
            return Cost;
        }
    }
}
