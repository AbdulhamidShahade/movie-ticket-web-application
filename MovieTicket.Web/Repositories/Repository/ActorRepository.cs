using Microsoft.EntityFrameworkCore;
using MovieTicket.Web.Data;
using MovieTicket.Web.Models;
using MovieTicket.Web.Repositories.Base;
using MovieTicket.Web.Repositories.IRepository;

namespace MovieTicket.Web.Repositories.Repository
{
    public class ActorRepository : BaseRepository<Actor>, IActorRepository
    {
        private readonly ApplicationDbContext _context;
        public ActorRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Actor>> GetActorsByCountryIdAsync(int countryId)
        {
            var actors = await _context.Actors.Where(c => c.CountryId == countryId).ToListAsync();

            return actors;
        }

        public async Task<List<Actor>> GetActorsByMovieIdAsync(int movieId)
        {
            var actors = await _context.MoviesActors.Where(m => m.MovieId == movieId)
                .Select(a => a.Actor)
                .ToListAsync();

            return actors;
        }
    }
}