

using MovieTicket.Web.Models;
using MovieTicket.Web.Repositories.Base;

namespace MovieTicket.Web.Repositories.IRepository
{
    public interface ICategoryRepository : IBaseRepository<Category>
    {
        Task<List<Movie>> GetMoviesByCategoryId(int movieId);
    }
}
