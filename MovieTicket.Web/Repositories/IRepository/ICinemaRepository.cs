using MovieTicket.Web.Models;
using MovieTicket.Web.Repositories.Base;

namespace MovieTicket.Web.Repositories.IRepository
{
    public interface ICinemaRepository : IBaseRepository<Cinema>
    {
        Task<Cinema> GetCinemaByMovieIdAsync(int movieId);
    }
}
