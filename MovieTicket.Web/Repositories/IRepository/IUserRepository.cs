

using MovieTicket.Web.Models;

namespace MovieTicket.Web.Repositories.IRepository
{
    public interface IUserRepository
    {
        Task<List<ApplicationUser>> GetAll();
    }
}
