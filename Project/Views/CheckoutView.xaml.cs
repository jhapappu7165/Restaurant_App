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

public partial class CheckoutView : ContentPage
{
    ObservableCollection<CartPopupItemView> view_items;
    public const Decimal TAX_RATE = 0.07M;
    Decimal _tax = 0.0M;
    Decimal _subTotal = 0.0M;
    Decimal _mealCost = 0.0M;
    Decimal _tip_amount = 0.0M;

    public CheckoutView()
    {
        InitializeComponent();


        view_items = new();

        var controller_items = App.Cart.GetCartItems();

        foreach (var item in controller_items)
        {
            CartPopupItemView cartPopupItemView = new CartPopupItemView();
            cartPopupItemView.Item = item;
            view_items.Add(cartPopupItemView);
            _subTotal += item.GetCost();
        }

        collCheckoutCart.ItemsSource = view_items;

        UpdateCost();
    }

    private void ButtonSubmitOrder(object sender, EventArgs e)
    {

    }

    private void ButtonCancelCheckout(object sender, EventArgs e)
    {
        App.Current.Windows[0].Page = new MainMenuPage();
    }

    private void UpdateMealCost(object sender, TextChangedEventArgs e)
    {
        try
        {
           _tip_amount = Convert.ToDecimal(txtTip.Text);
            UpdateCost();
        }
        catch (Exception ex)
        {
            return;
        }
    }

    private void UpdateCost()
    {
        _tax = _subTotal * TAX_RATE;
        _mealCost = _subTotal + _tax + _tip_amount;

        lblSubTotal.Text = $"${_subTotal:F2}";
        lblTax.Text = $"${_tax:F2}";
        lblMealCost.Text = $"${_mealCost:F2}";
    }
}