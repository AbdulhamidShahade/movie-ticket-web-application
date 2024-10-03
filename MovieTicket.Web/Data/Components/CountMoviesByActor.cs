using Microsoft.AspNetCore.Mvc;
using MovieTicket.Web.Repositories.IRepository;

namespace MovieTicket.Web.Data.Components
{
    public class CountMoviesByActor : ViewComponent
    {
        private readonly IMovieRepository _movieRepository;

        public CountMoviesByActor(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public IViewComponentResult Invoke(int actorId)
        {
            var count = _movieRepository.GetMoviesCountByActorId(actorId);

            return View(count);
        }
    }
}
