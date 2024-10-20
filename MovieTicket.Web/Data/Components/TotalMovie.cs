using Microsoft.AspNetCore.Mvc;
using MovieTicket.Web.Repositories.IRepository;

namespace MovieTicket.Web.Data.Components
{
    public class TotalMovie : ViewComponent
    {
        private readonly IMovieRepository _movieRepository;

        public TotalMovie(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public IViewComponentResult Invoke(int categoryId)
        {
            var moviesCount = _movieRepository.GetMoviesByCategoryId(categoryId);

            return View(moviesCount.Count());
        }
    }
}