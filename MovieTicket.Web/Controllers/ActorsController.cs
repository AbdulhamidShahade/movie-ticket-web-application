using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieTicket.Web.Helpers;
using MovieTicket.Web.Models;
using MovieTicket.Web.Models.ViewModels.ActorVM;
using MovieTicket.Web.Repositories.IRepository;

namespace MovieTicketWebApplication.Controllers
{
    public class ActorsController : Controller
    {
        private readonly IActorRepository _actorRepository;
        private readonly IMapper _mapper;

        public ActorsController(IActorRepository actorRepository, IMapper mapper)
        {
            _mapper = mapper;
            _actorRepository = actorRepository;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var actors = await _actorRepository.GetAllAsync();

            if (actors == null)
            {
                return View("InternalServerError");
            }

            var actorsViewModel = _mapper.Map<List<ReadActorVM>>(actors);

            return View(actorsViewModel);
        }


        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var actor = await _actorRepository.GetAsync(x => x.Id == id);

            if (actor == null)
            {
                return View("InternalServerError");
            }

            var actorViewModel = _mapper.Map<ReadActorVM>(actor);

            return View(actorViewModel);
        }


        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View(new CreateActorVM());
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateActorVM viewModel)
        {
            var actorModel = _mapper.Map<Actor>(viewModel);

            var isCreated = await _actorRepository.CreateAsync(actorModel);

            if (!isCreated)
            {
                NotificationHalper.SetNotification(this, "Failed", "Failed to create actor!");
                return View(ModelState);
            }

            NotificationHalper.SetNotification(this, "Success", "Actor created successfully.");
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var actor = await _actorRepository.GetAsync(x => x.Id == id);

            if(actor == null)
            {
                return View("InternalServerError");
            }

            var viewModel = _mapper.Map<UpdateActorVM>(actor);

            return View(viewModel);
        }


        [HttpPost]
        public async Task<IActionResult> Update([FromForm] UpdateActorVM viewModel)
        {
            var actorModel = _mapper.Map<Actor>(viewModel);

            var isUpdated = await _actorRepository.UpdateAsync(actorModel);

            if (!isUpdated)
            {
                NotificationHalper.SetNotification(this, "Failed", "Failed to update actor!");
                return View(ModelState);
            }

            NotificationHalper.SetNotification(this, "Success", "Actor updated successfully!");
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var actorModel = await _actorRepository.GetAsync(x => x.Id == id);

            if(actorModel == null)
            {
                return View("InternalServerError");
            }

            var viewModel = _mapper.Map<ReadActorVM>(actorModel);

            return View(viewModel);
        }


        [HttpPost]
        public async Task<IActionResult> Delete([FromForm] DeleteActorVM viewModel)
        {
            var actorModel = _mapper.Map<Actor>(viewModel);

            var isDeleted = await _actorRepository.DeleteAsync(actorModel);

            if (!isDeleted)
            {
                NotificationHalper.SetNotification(this, "Failed", "Failed to delete actor!");
                return View(ModelState);
            }

            NotificationHalper.SetNotification(this, "Success", "Actor deleted successfully");
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> UserIndex()
        {
            var actors = await _actorRepository.GetAllAsync();

            if(actors == null)
            {
                return View("InternalServerError");
            }

            var viewModel = _mapper.Map<List<ReadActorVM>>(actors);

            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> ActorsByCountry(int countryId)
        {
            var actors = await _actorRepository.GetActorsByCountryIdAsync(countryId);

            if(actors == null)
            {
                return View("InternalServerError");
            }

            var actorsViewModel = _mapper.Map<List<ReadActorVM>>(actors);

            return View(actorsViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> ActorsByMovie(int movieId)
        {
            var actors = await _actorRepository.GetActorsByMovieIdAsync(movieId);

            if(actors == null)
            {
                return View("InternalServerError");
            }

            var actorsViewModel = _mapper.Map<List<ReadActorVM>>(actors);

            return View(actorsViewModel); 
        }
    }
}