using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieTicket.Web.Helpers;
using MovieTicket.Web.Models;
using MovieTicket.Web.Models.ViewModels.CategoryVM;
using MovieTicket.Web.Repositories.IRepository;
namespace MovieTicketWebApplication.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var categories = await _categoryRepository.GetAllAsync();

            if(categories == null)
            {
                return View("InternalServerError");
            }

            var categoriesViewModel = _mapper.Map<List<ReadCategoryVM>>(categories);

            return View(categoriesViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var category = await _categoryRepository.GetAsync(x => x.Id == id);

            if (category == null)
            {
                return View("InternalServerError");
            }

            var categoryViewModel = _mapper.Map<ReadCategoryVM>(category);

            return View(categoryViewModel);
        }

        

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View(new CreateCategoryVM());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateCategoryVM viewModel)
        {
            var categoryModel = _mapper.Map<Category>(viewModel);

            var isCreated = await _categoryRepository.CreateAsync(categoryModel);

            if (!isCreated)
            {
                NotificationHalper.SetNotification(this, "Failed", "Failed to create category!");
                return View(ModelState);
            }

            NotificationHalper.SetNotification(this, "Success", "Category created successfully");
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var categoryModel = await _categoryRepository.GetAsync(x => x.Id == id);

            if (categoryModel == null)
            {
                return View("InternalServerError");
            }

            var categoryViewModel = _mapper.Map<UpdateCategoryVM>(categoryModel);

            return View(categoryViewModel);
        }


        [HttpPost]
        public async Task<IActionResult> Update([FromForm] UpdateCategoryVM viewModel)
        {
            var categoryModel = _mapper.Map<Category>(viewModel);

            var isUpdated = await _categoryRepository.UpdateAsync(categoryModel);

            if (!isUpdated)
            {
                NotificationHalper.SetNotification(this, "Failed", "Failed to update category!");
                return View(ModelState);
            }

            NotificationHalper.SetNotification(this, "Success", "Category updated successfully");
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var categoryModel = await _categoryRepository.GetAsync(x => x.Id == id);

            if (categoryModel == null)
            {
                return View("InternalServerError");
            }

            var categoryViewModel = _mapper.Map<DeleteCategoryVM>(categoryModel);

            return View(categoryViewModel);

        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromForm] DeleteCategoryVM viewModel)
        {
            var categoryModel = _mapper.Map<Category>(viewModel);

            var isDeleted = await _categoryRepository.DeleteAsync(categoryModel);

            if (!isDeleted)
            {
                NotificationHalper.SetNotification(this, "Failed", "Failed to delete category!");
                return View(ModelState);
            }

            NotificationHalper.SetNotification(this, "Success", "Category deleted successfully");
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> CategoriesByMovie(int movieId)
        {
            var categoriesModel = await _categoryRepository.GetCategoriesByMovieIdAsync(movieId);

            if(categoriesModel == null)
            {
                return View("InternalServerError");
            }

            var categoriesViewModel = _mapper.Map<List<ReadCategoryVM>>(categoriesModel);

            return View(categoriesViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> UserIndex()
        {
            var categoriesModels = await _categoryRepository.GetAllAsync();

            if(categoriesModels == null)
            {
                return View("InternalServerError");
            }

            var categoriesViewModel = _mapper.Map<List<ReadCategoryVM>>(categoriesModels);

            return View(categoriesViewModel);
        }
    }
}
