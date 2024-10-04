using MovieTicket.Web.Models;
using MovieTicket.Web.Repositories.Base;

namespace MovieTicket.Web.Repositories.IRepository
{
    public interface ICategoryRepository : IBaseRepository<Category>
    {
        Task<List<Category>> GetCategoriesByMovieIdAsync(int categoryId);
    }
}
