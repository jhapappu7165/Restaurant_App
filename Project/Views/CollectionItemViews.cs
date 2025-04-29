/*
I acknowledge the following statements:

1. That the code I provide below is my own work and NOT copied from any outside resource, which includes, but not limited to, an artificial intelligence program unless given explicit permission by the instructor.

2. That the code I provide below is my own work and NOT the work of my peers, tutors, or any other individual unless given explicit permission by the instructor.

3. That if the code below is in violation of statements 1 and 2 above, I may be reported to the Academic Integrity office and subject to penalties as described in the Academic Integrity Policy.

Your Name: Pappu Jha
Your Student ID: w10168315
*/



using RestaurantAppFullImp.Project.Models;
using MenuItem = RestaurantAppFullImp.Project.Models.MenuItem;

namespace RestaurantAppFullImp.Project.Views
{

    public class ComboItemView : BindableObject
    {
        public MenuItem Item { get; set; }

        public string ItemName
        {
            get
            {
                return $"{Item.ItemName}\n${Item.GetCost():F2}";
            }
        }

        public string Icon
        {
            get { return Item.Icon; }
        }
    }

    class ItemSelectView : BindableObject
    {
        public MenuItem Item { get; set; }

        public string ItemName
        {
            get
            {
                return $"{Item.ItemName}\n${Item.GetCost():F2}";
            }
        }

        public string Icon
        {
            get { return Item.Icon; }
        }
    }

    public class SizeTypeView : BindableObject
    {
        public string Text { get; set; } = "";
        public string Rate { get; set; } = "";
    }

    public partial class CartPopupItemView : BindableObject
    {
        public CartItem Item { get; set; }
        public string Detail
        {

            get
            {
                if ((Item as RestaurantAppFullImp.Project.Models.MenuItem) != null)
                {
                    //output just name of item.
                    return (Item as RestaurantAppFullImp.Project.Models.MenuItem).ItemName;

                }
                else if ((Item as RestaurantAppFullImp.Project.Models.ComboItem) != null)
                {
                    //output combo details
                    string ss = "";
                    ss += "** Combo **\n";
                    ss += " --> ";
                    ss += (Item as RestaurantAppFullImp.Project.Models.ComboItem).Entree.ItemName;
                    ss += "\n";
                    ss += " --> ";
                    ss += (Item as RestaurantAppFullImp.Project.Models.ComboItem).Side.ItemName;
                    ss += "\n";
                    ss += " --> ";
                    ss += (Item as RestaurantAppFullImp.Project.Models.ComboItem).Drink.ItemName;
                    ss += "\n";

                    return ss;
                }
                else
                    return "";
            }
        }

        public string ItemCost
        {
            get
            {
                return $"${Item.GetCost():F2}";
            }
        }
    }
}
