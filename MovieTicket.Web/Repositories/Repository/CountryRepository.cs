using Microsoft.EntityFrameworkCore;
using MovieTicket.Web.Data;
using MovieTicket.Web.Models;
using MovieTicket.Web.Repositories.Base;
using MovieTicket.Web.Repositories.IRepository;

namespace MovieTicket.Web.Repositories.Repository
{
    public class CountryRepository : BaseRepository<Country>, ICountryRepository
    {
        private readonly ApplicationDbContext _context;
        public CountryRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Country> GetCountryByActorIdAsync(int actorId)
        {
            var country = await _context.Actors.Where(a => a.Id == actorId)
                .Select(c => c.Country)
                .FirstOrDefaultAsync();

            return country;
        }

        public async Task<Country> GetCountryByProducerIdAsync(int producerId)
        {
            var country = await _context.Producers.Where(p => p.Id == producerId)
                .Select(c => c.Country)
                .FirstOrDefaultAsync();

            return country;
        }
    }

}
