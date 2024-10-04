using Microsoft.EntityFrameworkCore;
using MovieTicket.Web.Data;
using MovieTicket.Web.Models;
using MovieTicket.Web.Repositories.Base;
using MovieTicket.Web.Repositories.IRepository;

namespace MovieTicket.Web.Repositories.Repository
{
    public class ProducerRepository : BaseRepository<Producer>, IProducerRepository
    {
        private readonly ApplicationDbContext _context;

        public ProducerRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Producer>> GetProducersByCountryIdAsync(int countryId)
        {
            var producers = await _context.Producers.Where(c => c.CountryId == countryId)
                .ToListAsync();

            return producers;
        }

        public async Task<List<Producer>> GetProducersByMovieIdAsync(int movieId)
        {
            var producers = await _context.MoviesProducers.Where(m => m.MovieId == movieId)
                .Select(p => p.Producer)
                .ToListAsync();

            return producers;
        }
    }
}
