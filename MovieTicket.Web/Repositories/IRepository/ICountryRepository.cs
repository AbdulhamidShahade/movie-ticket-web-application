using MovieTicket.Web.Models;
using MovieTicket.Web.Repositories.Base;

namespace MovieTicket.Web.Repositories.IRepository
{
    public interface ICountryRepository : IBaseRepository<Country>
    {
        Task<Country> GetCountryByActorIdAsync(int actorId);
        Task<Country> GetCountryByProducerIdAsync(int producerId);
    }
}
