//using Microsoft.AspNetCore.Mvc;


//namespace MovieTicket.Web.Data.Components
//{
//    public class ShoppingCartSummary : ViewComponent
//    {
//        private readonly ShoppingCart _shoppingCart;
//        public ShoppingCartSummary(ShoppingCart shoppingCart)
//        {
//            _shoppingCart = shoppingCart;
//        }

//        public async Task<IViewComponentResult> Invoke()
//        {
//            var items = await _shoppingCart.GetAllShoppingCartItemsAsync();

//            return View(items.Count);
//        }
//    }
//}
