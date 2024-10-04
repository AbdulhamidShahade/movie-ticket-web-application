using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieTicket.Web.Helpers;
using MovieTicket.Web.Models;
using MovieTicket.Web.Models.ViewModels.CountryVM;
using MovieTicket.Web.Repositories.IRepository;

namespace MovieTicketWebApplication.Controllers
{
    public class CountriesController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ICountryRepository _countryRepository;

        public CountriesController(IMapper mapper, ICountryRepository countryRepository)
        {
            _mapper = mapper;
            _countryRepository = countryRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var countries = await _countryRepository.GetAllAsync();

            var countriesViewModel = _mapper.Map<List<ReadCountryVM>>(countries);

            return View(countriesViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var viewModel = _mapper.Map<ReadCountryVM>(await _countryRepository.GetAsync(i => i.Id == id));

            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View(new CreateCountryVM());
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCountryVM viewModel)
        {
            var model = _mapper.Map<Country>(viewModel);

            var toAdd = await _countryRepository.CreateAsync(model);

            if (!toAdd)
            {
                NotificationHalper.SetNotification(this, "Failed", "Failed to create country!");
                return RedirectToAction(nameof(Index));
            }

            NotificationHalper.SetNotification(this, "Success", "Country created successfully!");
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var model = await _countryRepository.GetAsync(i => i.Id == id);

            var viewModel = _mapper.Map<UpdateCountryVM>(model);

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateCountryVM viewModel)
        {
            var model = _mapper.Map<Country>(viewModel);

            var toUpdate = await _countryRepository.UpdateAsync(model);

            if (!toUpdate)
            {
                NotificationHalper.SetNotification(this, "Failed", "Failed to update country!");
                return RedirectToAction(nameof(Index));
            }

            NotificationHalper.SetNotification(this, "Success", "Country updated successfully!");
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {

            var viewModel = _mapper.Map<DeleteCountryVM>(await _countryRepository.GetAsync(i => i.Id == id));

            return View(viewModel);
        }


        [HttpPost]
        public async Task<IActionResult> Delete(DeleteCountryVM viewModel)
        {
            var model = _mapper.Map<Country>(viewModel);

            var toDelete = await _countryRepository.DeleteAsync(model);

            if (!toDelete)
            {
                NotificationHalper.SetNotification(this, "Failed", "Failed to delete country!");
                return RedirectToAction(nameof(Index));
            }

            NotificationHalper.SetNotification(this, "Success", "Country deleted successfully!");
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> UserIndex()
        {
            var countries = await _countryRepository.GetAllAsync();

            var countriesViewModel = _mapper.Map<List<ReadCountryVM>>(countries);

            return View(countriesViewModel);
        }


        [HttpGet]
        public async Task<IActionResult> CountryByActor(int actorId)
        {
            var countryModel = await _countryRepository.GetCountryByActorIdAsync(actorId);

            if(countryModel == null)
            {
                return View("InternalServerError");
            }

            var countryViewModel = _mapper.Map<ReadCountryVM>(countryModel);

            return View(countryViewModel);
        }


        [HttpGet]
        public async Task<IActionResult> CountryByProducer(int producerId)
        {
            var producerModel = await _countryRepository.GetCountryByProducerIdAsync(producerId);

            if(producerModel == null)
            {
                return View("InternalServerError");
            }

            var producerViewModel = _mapper.Map<ReadCountryVM>(producerModel);

            return View(producerViewModel);
        }
    }
}
