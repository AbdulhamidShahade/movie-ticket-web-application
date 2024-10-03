

using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using MovieTicket.Web.Models;
using MovieTicket.Web.Models.ViewModels.MovieVM;
using MovieTicket.Web.Repositories.Base;

namespace MovieTicket.Web.Repositories.IRepository
{
    public interface IMovieRepository : IBaseRepository<Movie>
    {
        Task<List<Actor>> GetActorsByMovieId(int movieId);
        Task<List<Category>> GetCategoriesByMovieId(int movieId);
        Task<List<Producer>> GetProducersByMovieId(int movieId);
        Task<Cinema> GetCinemaByMovieId(int id);
        Task<MovieDropdownListsVM> GetMovieDropDownLists();
        Task<bool> CreateMovieAsync(CreateMovieVM createMovieVM);
        Task<bool> UpdateMovieAsync(UpdateMovieVM updateMovieVM);

        List<Movie> GetMoviesByActorId(int actorId);


        Task<List<Movie>> GetMoviesByProducerIdAsync(int producerId);
        List<Movie> GetMoviesByProducerId(int producerId);

        int GetMoviesCountByActorId(int actorId);

        List<Movie> GetMoviesByCategoryId(int categoryId);

  


    }
}
