using Microsoft.AspNetCore.Mvc;
using MovieTicket.Web.Models;
using MovieTicket.Web.Repositories.IRepository;


namespace MovieTicket.Web.Data.Components
{
    public class CountMoviesByProducer : ViewComponent
    {
        private readonly IMovieRepository _movieRepository;

        public CountMoviesByProducer(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }
        public IViewComponentResult Invoke(int producerId)
        {
            List<Movie> movies = _movieRepository.GetMoviesByProducerId(producerId);

            return View(movies.Count());
        }
    }
}
