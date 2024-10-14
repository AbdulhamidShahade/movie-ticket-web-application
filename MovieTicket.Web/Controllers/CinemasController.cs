using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieTicket.Web.Helpers;
using MovieTicket.Web.Models;
using MovieTicket.Web.Models.ViewModels.CinemaVM;
using MovieTicket.Web.Repositories.IRepository;

namespace MovieTicketWebApplication.Controllers
{
    public class CinemasController : Controller
    {
        private readonly ICinemaRepository _cinemaRepository;
        private readonly IMapper _mapper;

        public CinemasController(ICinemaRepository cinemaRepository, IMapper mapper)
        {
            _mapper = mapper;
            _cinemaRepository = cinemaRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var cinemasModel = await _cinemaRepository.GetAllAsync();

            if (cinemasModel == null)
            {
                return View("InternalServerError");
            }

            List<ReadCinemaVM> cinemasViewModel = _mapper.Map<List<ReadCinemaVM>>(cinemasModel);

            return View(cinemasViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var cinemaModel = await _cinemaRepository.GetAsync(x => x.Id == id);

            if (cinemaModel == null)
            {
                return View("InternalServerError");
            }

            var cinemaViewModel = _mapper.Map<ReadCinemaVM>(cinemaModel);

            return View(cinemaViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View(new CreateCinemaVM());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateCinemaVM viewModel)
        {
            var cinemaModel = _mapper.Map<Cinema>(viewModel);

            var isCreated = await _cinemaRepository.CreateAsync(cinemaModel);

            if (!isCreated)
            {
                NotificationHalper.SetNotification(this, "Failed", "Failed to create cinema!");
                return View(ModelState);
            }

            NotificationHalper.SetNotification(this, "Success", "Cinema created successfully");
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var cinemaModel = await _cinemaRepository.GetAsync(x => x.Id == id);

            if (cinemaModel == null)
            {
                return View("InternalServerError");
            }

            var cinemaViewModel = _mapper.Map<UpdateCinemaVM>(cinemaModel);

            return View(cinemaViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update([FromForm] UpdateCinemaVM viewModel)
        {
            var cinemaModel = _mapper.Map<Cinema>(viewModel);

            var isUpdated = await _cinemaRepository.UpdateAsync(cinemaModel);

            if (!isUpdated)
            {
                NotificationHalper.SetNotification(this, "Failed", "Failed to update cinema!");
                return View(ModelState);
            }

            NotificationHalper.SetNotification(this, "Success", "Cinema updated successfully");
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var cinemaModel = await _cinemaRepository.GetAsync(x => x.Id == id);

            if (cinemaModel == null)
            {
                return View("InternalServerError");
            }

            var cinemaViewModel = _mapper.Map<DeleteCinemaVM>(cinemaModel);

            return View(cinemaViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(DeleteCinemaVM viewModel)
        {
            var cinemaModel = _mapper.Map<Cinema>(viewModel);

            var isDeleted = await _cinemaRepository.DeleteAsync(cinemaModel);

            if (!isDeleted)
            {
                NotificationHalper.SetNotification(this, "Failed", "Failed to delete cinema!");
                return View(ModelState);
            }

            NotificationHalper.SetNotification(this, "Success", "Cinema deleted successfully");
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> CinemaByMovie(int movieId)
        {
            var cinemaModel = await _cinemaRepository.GetCinemaByMovieIdAsync(movieId);

            if(cinemaModel == null)
            {
                return View("InternalServerError");
            }

            var cinemaViewModel = _mapper.Map<ReadCinemaVM>(cinemaModel);

            return View(cinemaViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> UserIndex()
        {
            var cinemasModel = await _cinemaRepository.GetAllAsync();

            if(cinemasModel == null)
            {
                return View("InternalServerError");
            }

            var cinemasViewModel = _mapper.Map<List<ReadCinemaVM>>(cinemasModel);

            return View(cinemasViewModel);
        }
    }
}
