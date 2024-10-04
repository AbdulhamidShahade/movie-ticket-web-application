using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieTicket.Web.Helpers;
using MovieTicket.Web.Models;
using MovieTicket.Web.Models.ViewModels.ProducerVM;
using MovieTicket.Web.Repositories.IRepository;

namespace MovieTicketWebApplication.Controllers
{
    public class ProducersController : Controller
    {
        private readonly IProducerRepository _producerRepository;
        private readonly IMapper _mapper;

        public ProducersController(IProducerRepository producerRepository, IMapper mapper)
        {
            _mapper = mapper;
            _producerRepository = producerRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var producersModel = await _producerRepository.GetAllAsync();

            if(producersModel == null)
            {
                return View("InternalServerError");
            }

            List<ReadProducerVM> producersViewModel = _mapper.Map<List<ReadProducerVM>>(producersModel);

            return View(producersViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var producerModel = await _producerRepository.GetAsync(x => x.Id == id);

            if(producerModel == null)
            {
                return View("InternalServerError");
            }

            ReadProducerVM producerViewModel = _mapper.Map<ReadProducerVM>(producerModel);

            return View(producerViewModel);
        }


        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View(new CreateProducerVM());
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateProducerVM viewModel)
        {
            var producerModel = _mapper.Map<Producer>(viewModel);

            var isCreated = await _producerRepository.CreateAsync(producerModel);

            if (!isCreated)
            {
                NotificationHalper.SetNotification(this, "Failed", "Failed to create producer!");
                return View(ModelState);
            }

            NotificationHalper.SetNotification(this, "Success", "Producer created successfully");
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var producerModel = await _producerRepository.GetAsync(x => x.Id == id);

            if (producerModel != null)
            {
                return View("InternalServerError");
            }

            UpdateProducerVM producerViewModel = _mapper.Map<UpdateProducerVM>(producerModel);

            return View(producerViewModel);
        }


        [HttpPost]
        public async Task<IActionResult> Update([FromForm] UpdateProducerVM viewModel)
        {
            var producerModel = _mapper.Map<Producer>(viewModel);

            var isUpdated = await _producerRepository.UpdateAsync(producerModel);

            if (!isUpdated)
            {
                NotificationHalper.SetNotification(this, "Failed", "Failed to update producer!");
                return View(ModelState);
            }

            NotificationHalper.SetNotification(this, "Success", "Producer updated successfully");
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> Delete (int id)
        {
            var producerModel = await _producerRepository.GetAsync(x => x.Id == id);

            if(producerModel == null)
            {
                return View("InternalServerError");
            }

            var producerViewModel = _mapper.Map<DeleteProducerVM>(producerModel);

            return View(producerViewModel);
        }


        [HttpPost]
        public async Task<IActionResult> Delete([FromForm] DeleteProducerVM viewModel)
        {
            var producerModel = _mapper.Map<Producer>(viewModel);

            var isDeleted = await _producerRepository.DeleteAsync(producerModel);

            if (!isDeleted)
            {
                NotificationHalper.SetNotification(this, "Failed", "Failed to delete producer!");
                return View(ModelState);
            }

            NotificationHalper.SetNotification(this, "Success", "Producer deleted successfully");
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> ProducersByCountry(int countryId)
        {
            var producersModel = await _producerRepository.GetProducersByCountryIdAsync(countryId);

            if(producersModel == null)
            {
                return View("InternalServerError");
            }

            var producersViewModel = _mapper.Map<List<ReadProducerVM>>(producersModel);

            return View(producersViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> ProducersByMovie(int movieId)
        {
            var producersModel = await _producerRepository.GetProducersByMovieIdAsync(movieId);

            if(producersModel == null)
            {
                return View("InternalServerError");
            }

            var producersViewModel = _mapper.Map<List<ReadProducerVM>>(producersModel);

            return View(producersViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> UserIndex()
        {
            var producersModel = await _producerRepository.GetAllAsync();

            if(producersModel == null)
            {
                return View("InternalServerError");
            }

            var producersViewModel = _mapper.Map<List<ReadProducerVM>>(producersModel);

            return View(producersViewModel);
        }
    }
}
