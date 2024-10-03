

using MovieTicket.Web.Models;
using MovieTicket.Web.Repositories.Base;

namespace MovieTicket.Web.Repositories.IRepository
{
    public interface IActorRepository : IBaseRepository<Actor>
    {
        Task<List<Movie>> GetMoviesByActorId(int actorId);
        Task<List<Actor>> GetActorsByCountryIdAsync(int countryId);
    }
}
