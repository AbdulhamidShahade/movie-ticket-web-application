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
            var moviesModel = await _movieRepository.GetMoviesAsync();

            var moviesViewModel = _mapper.Map<List<ReadMovieVM>>(moviesModel);

            return View(moviesViewModel);
        }


        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var movie = await _movieRepository.GetMovieByIdAsync(id);

            var movieViewModel = _mapper.Map<ReadMovieVM>(movie);

            return View(movieViewModel);
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
            var movieModel = await _movieRepository.GetMovieByIdAsync(id);

            var response = new UpdateMovieVM
            {
                Id = movieModel.Id,
                Name = movieModel.Name,
                Description = movieModel.Description,
                Price = movieModel.Price,
                PictureUrl = movieModel.PictureUrl,
                Length = movieModel.Length,
                PublishYear = movieModel.PublishYear,
                Rating = movieModel.Rating,
                StartDate = movieModel.StartDate,
                EndDate = movieModel.EndDate,
                CinemaId = movieModel.CinemaId,
                ActorIds = movieModel.MoviesActors.Where(m => m.MovieId == movieModel.Id).Select(ai => ai.ActorId).ToList(),
                CategoryIds = movieModel.MoviesCategories.Where(m => m.MovieId == movieModel.Id).Select(ci => ci.CategoryId).ToList(),
                ProducerIds = movieModel.MoviesProducers.Where(m => m.MovieId == movieModel.Id).Select(pi => pi.ProducerId).ToList(),
                CreatedAt = movieModel.CreatedAt,
            };

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

            ViewBag.Cinemas = new SelectList(movieDropdownLists.Cinemas, "Id", "Name");

            return View(response);
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
            var movieModel = await _movieRepository.GetMovieByIdAsync(id);

            var response = new DeleteMovieVM
            {
                Id = movieModel.Id,
                Name = movieModel.Name,
                Description = movieModel.Description,
                Price = movieModel.Price,
                PictureUrl = movieModel.PictureUrl,
                Length = movieModel.Length,
                PublishYear = movieModel.PublishYear,
                Rating = movieModel.Rating,
                StartDate = movieModel.StartDate,
                EndDate = movieModel.EndDate,
                CinemaId = movieModel.CinemaId,
                ActorIds = movieModel.MoviesActors.Where(m => m.MovieId == movieModel.Id).Select(ai => ai.ActorId).ToList(),
                CategoryIds = movieModel.MoviesCategories.Where(m => m.MovieId == movieModel.Id).Select(ci => ci.CategoryId).ToList(),
                ProducerIds = movieModel.MoviesProducers.Where(m => m.MovieId == movieModel.Id).Select(pi => pi.ProducerId).ToList(),
                CreatedAt = movieModel.CreatedAt
            };


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

            ViewBag.Cinemas = new SelectList(movieDropdownLists.Cinemas, "Id", "Name");

            return View(response);
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
        public async Task<IActionResult> MoviesByActor(int id)
        {
            var moviesModel = await _movieRepository.GetMoviesByActorIdAsync(id);

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
        public async Task<IActionResult> MoviesByProducer(int id)
        {
            var moviesModel = await _movieRepository.GetMoviesByProducerIdAsync(id);

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

            if(moviesModel == null)
            {
                return View("InternalServerError");
            }

            var moviesViewModel = _mapper.Map<List<ReadMovieVM>>(moviesModel);

            return View(moviesViewModel);
        }


        public async Task<IActionResult> Filter(string searchString)
        {
            var allMovies = await _movieRepository.GetAllAsync();

            if (!string.IsNullOrEmpty(searchString))
            {
                var filteredResultNew = allMovies.Where(n => string.Equals(n.Name, searchString, StringComparison.CurrentCultureIgnoreCase) || string.Equals(n.Description, searchString, StringComparison.CurrentCultureIgnoreCase)).ToList();

                return View("UserIndex", _mapper.Map<List<ReadMovieVM>>(filteredResultNew));
            }

            return RedirectToAction(nameof(UserIndex));
        }
    }
}