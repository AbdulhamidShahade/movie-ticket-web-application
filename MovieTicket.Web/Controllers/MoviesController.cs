using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MovieTicket.Web.Helpers;
using MovieTicket.Web.Models;
using MovieTicket.Web.Models.ViewModels.MovieVM;
using MovieTicket.Web.Repositories.IRepository;

namespace MovieTicketWebApplication.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;

        public MoviesController(IMovieRepository movieRepository, IMapper mapper)
        {
            _mapper = mapper;
            _movieRepository = movieRepository;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var moviesModel = await _movieRepository.GetAllAsync();

            var moviesViewModel = _mapper.Map<List<ReadMovieVM>>(moviesModel);

            return View(moviesViewModel);
        }


        [HttpGet]
        public async Task<IActionResult> GetMovieById(int id)
        {
            var movie = _movieRepository.GetAsync(null, c => c.Cinema,
                                                         ca => ca.MoviesCategories.Select(c => c.Category),
                                                         p => p.MoviesProducers.Select(p => p.Producer),
                                                         a => a.MoviesActors.Select(a => a.Actor));

            return View(movie);
        }


        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var movieDropdownLists = await _movieRepository.GetMovieDropDownLists();

            ViewBag.Cinemas = new SelectList(movieDropdownLists.Cinemas, "Id", "Name");
            ViewBag.Actors = new SelectList(movieDropdownLists.Actors.Select(t => new
            {
                t.Id,
                FullName = t.FirstName + " " + t.LastName
            }), "Id", "FullName");

            ViewBag.Producers = new SelectList(movieDropdownLists.Producers.Select(t => new
            {
                t.Id,
                FullName = $"{t.FirstName} {t.LastName}"
            }), "Id", "FullName");

            ViewBag.Categories = new SelectList(movieDropdownLists.Categories, "Id", "Name");

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateMovieVM viewModel)
        {
            var isCreated = await _movieRepository.CreateMovieAsync(viewModel);

            if (!isCreated)
            {
                NotificationHalper.SetNotification(this, "Failed", "Failed to create movie!");
                return View(ModelState);
            }

            NotificationHalper.SetNotification(this, "Success", "Movie created successfully");
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var movieModel = await _movieRepository.GetAsync(x => x.Id == id,
                                                                        c => c.Cinema,
                                                                        ma => ma.MoviesActors.Select(a => a.Actor),
                                                                        mc => mc.MoviesCategories.Select(c => c.Category),
                                                                        mp => mp.MoviesProducers.Select(p => p.Producer));

            var movieDropdownLists = await _movieRepository.GetMovieDropDownLists();

            ViewBag.Actors = new SelectList(movieDropdownLists.Actors.Select(t => new
            {
                t.Id,
                FullName = $"{t.FirstName} {t.LastName}"
            }), "Id", "FullName");

            ViewBag.Producers = new SelectList(movieDropdownLists.Producers.Select(t => new
            {
                t.Id,
                FullName = $"{t.FirstName} {t.LastName}"
            }), "Id", "FullName");

            ViewBag.Categories = new SelectList(movieDropdownLists.Categories, "Id", "Name");

            var movieViewModel = _mapper.Map<UpdateMovieVM>(movieModel);

            return View(movieViewModel);
        }


        [HttpPost]
        public async Task<IActionResult> Update([FromForm] UpdateMovieVM viewModel)
        {
            var isUpdated = await _movieRepository.UpdateMovieAsync(viewModel);

            if (!isUpdated)
            {
                NotificationHalper.SetNotification(this, "Failed", "Failed to updated movie!");
                return View(ModelState);
            }

            NotificationHalper.SetNotification(this, "Success", "Movie updated successfully");
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var movieModel = await _movieRepository.GetAsync(x => x.Id == id,
                                                                        c => c.Cinema,
                                                                        ma => ma.MoviesActors.Select(a => a.Actor),
                                                                        mc => mc.MoviesCategories.Select(c => c.Category),
                                                                        mp => mp.MoviesProducers.Select(p => p.Producer));


            var movieDropdownLists = await _movieRepository.GetMovieDropDownLists();

            ViewBag.Actors = new SelectList(movieDropdownLists.Actors.Select(t => new
            {
                t.Id,
                FullName = $"{t.FirstName} {t.LastName}"
            }), "Id", "FullName");

            ViewBag.Producers = new SelectList(movieDropdownLists.Producers.Select(t => new
            {
                t.Id,
                FullName = $"{t.FirstName} {t.LastName}"
            }), "Id", "FullName");

            ViewBag.Categories = new SelectList(movieDropdownLists.Categories, "Id", "Name");

            var movieViewModel = _mapper.Map<DeleteMovieVM>(movieModel);

            return View(movieViewModel);
        }


        [HttpPost]
        public async Task<IActionResult> Delete([FromForm] DeleteMovieVM viewModel)
        {
            var movieModel = _mapper.Map<Movie>(viewModel);

            var isDeleted = await _movieRepository.DeleteAsync(movieModel);

            if (!isDeleted)
            {
                NotificationHalper.SetNotification(this, "Failed", "Failed to delete movie!");
                return View(ModelState);
            }

            NotificationHalper.SetNotification(this, "Success", "Movie deleted successfully");
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> MoviesByActor(int actorId)
        {
            var moviesModel = await _movieRepository.GetMoviesByActorIdAsync(actorId);

            if (moviesModel == null)
            {
                return View("InternalServerError");
            }

            var moviesViewModel = _mapper.Map<List<ReadMovieVM>>(moviesModel);

            return View(moviesViewModel);
        }


        [HttpGet]
        public async Task<IActionResult> MoviesByCategory(int categoryId)
        {
            var moviesModel = await _movieRepository.GetMoviesByCategoryIdAsync(categoryId);

            if(moviesModel == null)
            {
                return View("InternalServerError");
            }

            var moviesViewModel = _mapper.Map<List<ReadMovieVM>>(moviesModel);

            return View(moviesViewModel);
        }


        [HttpGet]
        public async Task<IActionResult> MoviesByProducer(int producerId)
        {
            var moviesModel = await _movieRepository.GetMoviesByProducerIdAsync(producerId);

            if(moviesModel == null)
            {
                return View("InternalServerError");
            }

            var moviesViewModel = _mapper.Map<List<ReadMovieVM>>(moviesModel);

            return View(moviesViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> UserIndex()
        {
            var moviesModel = await _movieRepository.GetAllAsync();

            if(moviesModel != null)
            {
                return View("InternalServerError");
            }

            var moviesViewModel = _mapper.Map<List<ReadMovieVM>>(moviesModel);

            return View(moviesViewModel);
        }
    }
}