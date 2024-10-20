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

        public async Task<List<Category>> GetCategoriesByMovieIdAsync(int movieId)
        {
            var categories = await _context.MoviesCategories.Where(c => c.MovieId == movieId)
                .Select(c => c.Category)
                .ToListAsync();

            return categories;
        }
    }
}