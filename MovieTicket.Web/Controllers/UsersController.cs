using Microsoft.AspNetCore.Mvc;
using MovieTicket.Web.Repositories.IRepository;

namespace MovieTicketWebApplication.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IActionResult> Index()
        {
            var users = await _userRepository.GetAll();

            return View(users);
        }
    }
}
