/*
I acknowledge the following statements:

1. That the code I provide below is my own work and NOT copied from any outside resource, which includes, but not limited to, an artificial intelligence program unless given explicit permission by the instructor.

2. That the code I provide below is my own work and NOT the work of my peers, tutors, or any other individual unless given explicit permission by the instructor.

3. That if the code below is in violation of statements 1 and 2 above, I may be reported to the Academic Integrity office and subject to penalties as described in the Academic Integrity Policy.

Your Name: Pappu Jha
Your Student ID: w10168315
*/

using RestaurantAppFullImp.Project.Controllers;

namespace RestaurantAppFullImp
{
    public partial class App : Application
    {
        public static MenuController Menu;
        public static CartController Cart;
        
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new Project.Views.MainMenuPage());
        }

        static App()
        {
            Menu = new MenuController();
            Cart = new CartController();
        }
    }
}