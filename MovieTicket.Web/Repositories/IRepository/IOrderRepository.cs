

using MovieTicket.Web.Models;

namespace MovieTicket.Web.Repositories.IRepository
{
    public interface IOrderRepository
    {
        Task StoreOrderAsync(List<ShoppingCartItem> items, int userId, string EmailAddress);
        Task<List<Order>> GetOrdersAsync(int userId, string userRole);
    }
}
