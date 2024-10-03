

using Microsoft.EntityFrameworkCore;
using MovieTicket.Web.Data;
using MovieTicket.Web.Models;
using MovieTicket.Web.Repositories.Base;
using MovieTicket.Web.Repositories.IRepository;

namespace MovieTicket.Web.Repositories.Repository
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Movie>> GetMoviesByCategoryId(int movieId)
        {
            var movies = await _context.MoviesCategories.Where(m => m.MovieId == movieId)
                .Select(m => m.Movie).ToListAsync();

            return movies;
        }
    }
}
