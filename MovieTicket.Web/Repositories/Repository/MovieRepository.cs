using Microsoft.EntityFrameworkCore;
using MovieTicket.Web.Data;
using MovieTicket.Web.Models;
using MovieTicket.Web.Models.ViewModels.MovieVM;
using MovieTicket.Web.Repositories.Base;
using MovieTicket.Web.Repositories.IRepository;

namespace MovieTicket.Web.Repositories.Repository
{
    public class MovieRepository : BaseRepository<Movie>, IMovieRepository
    {
        private readonly ApplicationDbContext _context;

        public MovieRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<MovieDropdownListsVM> GetMovieDropDownLists()
        {
            return new MovieDropdownListsVM
            {
                Actors = await _context.Actors.OrderBy(f => f.FirstName).ToListAsync(),
                Producers = await _context.Producers.OrderBy(f => f.FirstName).ToListAsync(),
                Cinemas = await _context.Cinemas.OrderBy(n => n.Name).ToListAsync(),
                Categories = await _context.Categories.OrderBy(n => n.Name).ToListAsync(),
            };
        }

        public async Task<bool> CreateMovieAsync(CreateMovieVM createMovieVM)
        {
            Movie movieToCreate = new()
            {
                Name = createMovieVM.Name,
                Description = createMovieVM.Description,
                Price = createMovieVM.Price,
                PictureUrl = createMovieVM.PictureUrl,
                StartDate = Convert.ToDateTime(createMovieVM.StartDate),
                EndDate = Convert.ToDateTime(createMovieVM.EndDate),
                CinemaId = createMovieVM.CinemaId,
                Rating = createMovieVM.Rating,
                Length = createMovieVM.Length,
                PublishYear = createMovieVM.PublishYear,
                CreatedAt = DateTime.UtcNow,
            };

            await _context.Movies.AddAsync(movieToCreate);
            await _context.SaveChangesAsync();

            int movieId = await _context.Movies.Where(n => n.Name == createMovieVM.Name).Select(i => i.Id).FirstOrDefaultAsync();

            foreach(int actorId in createMovieVM.ActorIds)
            {
                await _context.MoviesActors.AddAsync(new MovieActor
                {
                    ActorId = actorId,
                    MovieId = movieId,
                    CreatedAt = DateTime.UtcNow
                });
            }

            foreach(int categoryId in createMovieVM.CategoryIds)
            {
                await _context.MoviesCategories.AddAsync(new MovieCategory
                {
                    CategoryId = categoryId,
                    MovieId = movieId,
                    CreatedAt = DateTime.UtcNow
                });
            }

            foreach(int producerId in createMovieVM.ProducerIds)
            {
                await _context.MoviesProducers.AddAsync(new MovieProducer
                {
                    ProducerId = producerId,
                    MovieId = movieId,
                    CreatedAt = DateTime.UtcNow
                });
            }

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateMovieAsync(UpdateMovieVM vm)
        {
            var movie = await _context.Movies.AsNoTracking().Where(x => x.Id == vm.Id).FirstOrDefaultAsync();

            Movie movieToUpdate = new()
            {
                Id = vm.Id,
                Name = vm.Name,
                Description = vm.Description,
                Price = vm.Price,
                PictureUrl = vm.PictureUrl,
                StartDate = Convert.ToDateTime(vm.StartDate),
                EndDate = Convert.ToDateTime(vm.EndDate),
                UpdatedAt = DateTime.UtcNow,
                Length = vm.Length,
                PublishYear = vm.PublishYear,
                Rating = vm.Rating,
                CreatedAt = vm.CreatedAt,
                CinemaId = vm.CinemaId,
            };
            
            _context.Movies.Update(movieToUpdate);
            await _context.SaveChangesAsync();

            var actorsToRemove = await _context.MoviesActors.Where(m => m.MovieId == vm.Id).ToListAsync();
            _context.MoviesActors.RemoveRange(actorsToRemove);

            foreach(int actorId in vm.ActorIds)
            {
                _context.MoviesActors.Update(new MovieActor
                {
                    ActorId = actorId,
                    MovieId = vm.Id,
                    CreatedAt = DateTime.UtcNow
                });
            }

            var categoriesToRemove = await _context.MoviesCategories.Where(m => m.MovieId == vm.Id)
                .ToListAsync();
            _context.MoviesCategories.RemoveRange(categoriesToRemove);

            foreach(int categoryId in vm.CategoryIds)
            {
                _context.MoviesCategories.Update(new MovieCategory
                {
                    MovieId = vm.Id,
                    CategoryId = categoryId,
                    CreatedAt = DateTime.UtcNow
                });
            }


            var producersToRemove = await _context.MoviesProducers.Where(m => m.MovieId == vm.Id)
                .ToListAsync();
            _context.MoviesProducers.RemoveRange(producersToRemove);

            foreach(int producerId in vm.ProducerIds)
            {
                _context.MoviesProducers.Update(new MovieProducer
                {
                    ProducerId = producerId,
                    MovieId = vm.Id,
                    CreatedAt = DateTime.UtcNow
                });
            }

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<List<Movie>> GetMoviesByActorIdAsync(int actorId)
        {
            var movies = await _context.MoviesActors.Where(a => a.ActorId == actorId)
                .Select(m => m.Movie)
                .ToListAsync();

            return movies;
        }

        public List<Movie> GetMoviesByActorId(int actorId)
        {
            var movies = _context.MoviesActors.Where(a => a.ActorId == actorId)
                .Select(m => m.Movie)
                .ToList();

            return movies;
        }

        public async Task<List<Movie>> GetMoviesByCategoryIdAsync(int categoryId)
        {
            var movies = await _context.MoviesCategories.Where(c => c.CategoryId == categoryId)
                .Select(m => m.Movie)
                .ToListAsync();

            return movies;
        }

        public List<Movie> GetMoviesByCategoryId(int categoryId)
        {
            var movies = _context.MoviesCategories.Where(c => c.CategoryId == categoryId)
                .Select(m => m.Movie)
                .ToList();

            return movies;
        }

        public async Task<List<Movie>> GetMoviesByProducerIdAsync(int producerId)
        {
            var movies = await _context.MoviesProducers.Where(p => p.ProducerId == producerId)
                .Select(m => m.Movie)
                .ToListAsync();

            return movies;
        }

        public List<Movie> GetMoviesByProducerId(int producerId)
        {
            var movies = _context.MoviesProducers.Where(p => p.ProducerId == producerId)
                .Select(m => m.Movie)
                .ToList();

            return movies;
        }

        public int GetMoviesCountByActorId(int actorId)
        {
            var moviesCount = _context.MoviesActors.Where(a => a.ActorId == actorId)
                .Count();

            return moviesCount;
        }

        public async Task<int> GetMoviesCountByActorIdAsync(int actorId)
        {
            var moviesCount = await _context.MoviesActors.Where(a => a.ActorId == actorId)
                .CountAsync();

            return moviesCount;
        }

        public int GetMoviesCountByProducerId(int producerId)
        {
            var moviesCount = _context.MoviesProducers.Where(p => p.ProducerId == producerId)
                .Count();

            return moviesCount;
        }

        public async Task<int> GetMoviesCountByProducerIdAsync(int producerId)
        {
            var moviesCount = await _context.MoviesProducers.Where(p => p.ProducerId == producerId)
                .CountAsync();

            return moviesCount; 
        }

        public Task<List<Movie>> GetMoviesAsync()
        {
            var movies = _context.Movies
                .Include(mc => mc.MoviesCategories)
                .ThenInclude(c => c.Category)
                .Include(mp => mp.MoviesProducers)
                .ThenInclude(p => p.Producer)
                .Include(ma => ma.MoviesActors)
                .ThenInclude(a => a.Actor)
                .Include(c => c.Cinema)
                .ToListAsync();

            return movies;
        }

        public Task<Movie> GetMovieByIdAsync(int id)
        {
            var movie = _context.Movies.Where(i => i.Id == id)
                .Include(mc => mc.MoviesCategories)
                .ThenInclude(c => c.Category)
                .Include(mp => mp.MoviesProducers)
                .ThenInclude(p => p.Producer)
                .Include(ma => ma.MoviesActors)
                .ThenInclude(a => a.Actor)
                .Include(c => c.Cinema)
                .FirstOrDefaultAsync();

            return movie;
        }
    }
}
