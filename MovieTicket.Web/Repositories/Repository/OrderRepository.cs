
using Microsoft.EntityFrameworkCore;
using MovieTicket.Web.Data;
using MovieTicket.Web.Data.Statics;
using MovieTicket.Web.Models;
using MovieTicket.Web.Repositories.Base;
using MovieTicket.Web.Repositories.IRepository;
using System.Runtime.InteropServices;

namespace MovieTicket.Web.Repositories.Repository
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        private readonly ApplicationDbContext _context;
        public OrderRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Order>> GetOrdersAsync(int userId, string userRole)
        {
            var orders = await _context.Orders.Include(n => n.OrderDetails).ThenInclude(m => m.Movie).Include(u => u.User).ToListAsync();

            if (userRole != UserRoles.Admin)
            {
                orders = orders.Where(u => u.UserId == userId).ToList();
            }

            return orders;
        }

        public async Task StoreOrderAsync(List<ShoppingCartItem> items, int userId, string EmailAddress)
        {
            var order = new Order()
            {
                UserId = userId,
                Email = EmailAddress,
            };

            await _context.Orders.AddAsync(order); //after adding will id be rendering from database.
            await _context.SaveChangesAsync();

            foreach (var item in items)
            {
                await _context.OrderDetails.AddAsync(new OrderDetails()
                {
                    Amount = item.Amount,
                    MovieId = item.MovieId,
                    OrderId = order.Id,
                    Price = item.Movie.Price,
                    IsActive = false
                });
            }

            await _context.SaveChangesAsync();
        }
    }
}
