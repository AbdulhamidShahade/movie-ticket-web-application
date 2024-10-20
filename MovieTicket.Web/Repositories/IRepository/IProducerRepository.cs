

using MovieTicket.Web.Models;
using MovieTicket.Web.Repositories.Base;

namespace MovieTicket.Web.Repositories.IRepository
{
    public interface IProducerRepository : IBaseRepository<Producer>
    {
        Task<List<Producer>> GetProducersByCountryIdAsync(int countryId);
        Task<List<Producer>> GetProducersByMovieIdAsync(int movieId);
    }
}