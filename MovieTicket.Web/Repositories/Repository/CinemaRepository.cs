using Microsoft.EntityFrameworkCore;
using MovieTicket.Web.Data;
using MovieTicket.Web.Models;
using MovieTicket.Web.Repositories.Base;
using MovieTicket.Web.Repositories.IRepository;

namespace MovieTicket.Web.Repositories.Repository
{
    public class CinemaRepository : BaseRepository<Cinema>, ICinemaRepository
    {
        private readonly ApplicationDbContext _context;

        public CinemaRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Cinema> GetCinemaByMovieIdAsync(int movieId)
        {
            var cinema = await _context.Movies.Where(m => m.Id == movieId)
                .Select(c => c.Cinema)
                .FirstOrDefaultAsync();

            return cinema;
        }
    }
}
