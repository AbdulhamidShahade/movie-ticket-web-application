//using Microsoft.EntityFrameworkCore;
//using MovieTicket.Web.Data;

//namespace MovieTicket.Web.Models
//{
//    public class ShoppingCart
//    {
//        private readonly ApplicationDbContext _context;
//        public string Email { get; set; }
//        public List<ShoppingCartItem> ShoppingCartItems { get; set; }

//        public ShoppingCart(ApplicationDbContext context)
//        {
//            _context = context;
//        }

//        public static ShoppingCart GetShoppingCart(IServiceProvider serviceProvider)
//        {

//        }


//        public async Task AddItemToCart(Movie movie)
//        {
//            var shoppingCartItem = await _context.ShoppingCartItems.FirstOrDefaultAsync(n => n.Movie.Id == movie.Id && n.Email == Email);

//            if (shoppingCartItem == null)
//            {
//                shoppingCartItem = new ShoppingCartItem()
//                {
//                    Email = Email,
//                    Movie = movie,
//                    Amount = 1
//                };

//                _context.ShoppingCartItems.Add(shoppingCartItem);
//            }
//            else
//            {
//                shoppingCartItem.Amount++;
//            }

//            await _context.SaveChangesAsync();
//        }

//        public async Task RemoveItemFromCart(Movie movie)
//        {
//            var shoppingCartItem = await _context.ShoppingCartItems.Where(m => m.Movie.Id == movie.Id && m.Email == Email).FirstOrDefaultAsync();

//            if (shoppingCartItem != null)
//            {
//                if (shoppingCartItem.Amount > 1)
//                {
//                    shoppingCartItem.Amount--;
//                }
//                else
//                {
//                    _context.ShoppingCartItems.Remove(shoppingCartItem);
//                }
//            }
//            await _context.SaveChangesAsync();
//        }

//        public decimal GetShoppingCartTotal()
//        {
//            return _context.ShoppingCartItems.Where(n => n.Email == Email).Select(n => n.Movie.Price * n.Amount).Sum();
//        }

//        public async Task ClearShoppingCartAsync()
//        {
//            var items = await _context.ShoppingCartItems.Where(s => s.Email == Email).ToListAsync();

//            _context.ShoppingCartItems.RemoveRange(items);

//            await _context.SaveChangesAsync();
//        }

//        public async Task<List<ShoppingCartItem>> GetAllShoppingCartItemsAsync()
//        {
//            return ShoppingCartItems ?? (ShoppingCartItems = await _context.ShoppingCartItems.Where(n => n.Email == Email).Include(n => n.Movie).ToListAsync());
//        }
//    }
//}
