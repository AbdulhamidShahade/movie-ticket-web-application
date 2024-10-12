using Microsoft.EntityFrameworkCore;
using MovieTicket.Web.Data;
using System.Security.Claims;

namespace MovieTicket.Web.Models
{
    public class ShoppingCart
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _contextAccessor;
        private string _Email { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }

        public ShoppingCart(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _contextAccessor = httpContextAccessor;
            _Email = _contextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.Email)?.Value;

        }

        public static ShoppingCart GetShoppingCart(IServiceProvider serviceProvider)
        {
            return null;
        }


        public async Task AddItemToCart(Movie movie)
        {

            var shoppingCartItem = await _context.ShoppingCartItems.FirstOrDefaultAsync(n => n.Movie.Id == movie.Id && n.Email == _Email && n.Status);

            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem()
                {
                    Email = _Email,
                    Movie = movie,
                    Amount = 1,
                    Status = true,
                };

                _context.ShoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Amount++;
            }

            await _context.SaveChangesAsync();
        }

        public async Task RemoveItemFromCart(Movie movie)
        {
            var shoppingCartItem = await _context.ShoppingCartItems.Where(m => m.Movie.Id == movie.Id && m.Email == _Email && m.Status).FirstOrDefaultAsync();

            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Amount > 1)
                {
                    shoppingCartItem.Amount--;
                }
                else
                {
                    _context.ShoppingCartItems.Remove(shoppingCartItem);
                }
            }
            await _context.SaveChangesAsync();
        }

        public decimal GetShoppingCartTotal()
        {
            return _context.ShoppingCartItems.Where(n => n.Email == _Email && n.Status).Select(n => n.Movie.Price * n.Amount).Sum();
        }

        public async Task ClearShoppingCartAsync()
        {
            var items = await _context.ShoppingCartItems.Where(s => s.Email == _Email).ToListAsync();

            foreach (var item in items)
            {
                item.Status = false;
            }

            await _context.SaveChangesAsync();
        }

        public async Task<List<ShoppingCartItem>> GetAllShoppingCartItemsAsync()
        {
            return ShoppingCartItems ?? (ShoppingCartItems = await _context.ShoppingCartItems.Where(n => n.Email == _Email && n.Status).Include(n => n.Movie).ToListAsync());
        }

        public List<ShoppingCartItem> GetAllShoppingCartItems()
        {
            return ShoppingCartItems ?? (ShoppingCartItems = _context.ShoppingCartItems.Where(n => n.Email == _Email && n.Status).Include(n => n.Movie).ToList());
        }
    }
}
