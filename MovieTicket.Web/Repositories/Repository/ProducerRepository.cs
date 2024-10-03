
//using MovieTicket.Web.Data;
//using MovieTicket.Web.Models;
//using MovieTicket.Web.Repositories.Base;
//using MovieTicket.Web.Repositories.IRepository;

//namespace MovieTicket.Web.Repositories.Repository
//{
//    public class ProducerRepository : BaseRepository<Producer>, IProducerRepository
//    {
//        private readonly ApplicationDbContext _context;

//        public ProducerRepository(ApplicationDbContext context) : base(context)
//        {
//            _context = context;
//        }

//        public async Task<List<Movie>> GetMoviesByProducerId(int producerId)
//        {
//            var movies = await _context.MoviesProducers.Where(p => p.ProducerId == producerId).Select(m => m.Movie).ToListAsync();

//            return movies;
//        }
//    }
//}
