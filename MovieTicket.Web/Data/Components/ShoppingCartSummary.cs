using Microsoft.AspNetCore.Mvc;
using MovieTicket.Web.Models;


namespace MovieTicket.Web.Data.Components
{
    public class ShoppingCartSummary : ViewComponent
    {
        private readonly ShoppingCart _shoppingCart;
        public ShoppingCartSummary(ShoppingCart shoppingCart)
        {
            _shoppingCart = shoppingCart;
        }

        public IViewComponentResult Invoke()
        {
            var items = _shoppingCart.GetAllShoppingCartItems();

            return View(items.Count);
        }
    }
}
