using MovieTicket.Web.Models;
using MovieTicket.Web.Models.ViewModels.MovieVM;
using MovieTicket.Web.Repositories.Base;

namespace MovieTicket.Web.Repositories.IRepository
{
    public interface IMovieRepository : IBaseRepository<Movie>
    {
        Task<MovieDropdownListsVM> GetMovieDropDownLists();
        Task<bool> CreateMovieAsync(CreateMovieVM createMovieVM);
        Task<bool> UpdateMovieAsync(UpdateMovieVM updateMovieVM);
        
        Task<List<Movie>> GetMoviesByActorIdAsync(int actorId);
        List<Movie> GetMoviesByActorId(int actorId);

        Task<List<Movie>> GetMoviesByCategoryIdAsync(int categoryId);
        List<Movie> GetMoviesByCategoryId(int categoryId);

        Task<List<Movie>> GetMoviesByProducerIdAsync(int producerId);
        List<Movie> GetMoviesByProducerId(int producerId);

        int GetMoviesCountByActorId(int actorId);
        Task<int> GetMoviesCountByActorIdAsync(int actorId);

        int GetMoviesCountByProducerId(int producerId);
        Task<int> GetMoviesCountByProducerIdAsync(int producerId);
    }
}
