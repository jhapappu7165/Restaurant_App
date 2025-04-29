/*
I acknowledge the following statements:

1. That the code I provide below is my own work and NOT copied from any outside resource, which includes, but not limited to, an artificial intelligence program unless given explicit permission by the instructor.

2. That the code I provide below is my own work and NOT the work of my peers, tutors, or any other individual unless given explicit permission by the instructor.

3. That if the code below is in violation of statements 1 and 2 above, I may be reported to the Academic Integrity office and subject to penalties as described in the Academic Integrity Policy.

Your Name: Pappu Jha
Your Student ID: w10168315
*/


using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RestaurantAppFullImp.Project.Models;

namespace RestaurantAppFullImp.Project.Controllers
{
    public class CartController
    {
        private List<CartItem> CartItems { get; set; } = new List<CartItem>();

        public void AddItem(CartItem item)
        {
            CartItems.Add(item);
        }

        public void RemoveItem(int ID)
        {
            var item = CartItems.Find(x => x.ID == ID);
            
            if(item != null) 
                CartItems.Remove(item);
        }

        public ObservableCollection<CartItem> GetCartItems()
        {
            return new ObservableCollection<CartItem>(CartItems);
        }
    }
}
