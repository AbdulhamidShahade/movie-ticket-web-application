using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieTicket.Models.ViewModels.AuthenticationVM;
using MovieTicket.Web.Helpers;
using MovieTicket.Web.Repositories.IRepository;

namespace MovieTicketWebApplication.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly IAuthenticationRepository _authenticationRepository;
        private readonly IMapper _mapper;

        public AuthenticationController(IAuthenticationRepository authenticationRepository, IMapper mapper)
        {
            _authenticationRepository = authenticationRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Login()
        {
            return View(new LoginVM());
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            var toLogin = await _authenticationRepository.Login(loginVM);

            if (!toLogin)
            {
                NotificationHalper.SetNotification(this, "Failed", "Failed to login!");
                return View(ModelState);
            }

            NotificationHalper.SetNotification(this, "Success", "Login successfully!");
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> Register()
        {
            return View(new RegisterVM());
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            var toRegister = await _authenticationRepository.Register(registerVM);

            if (!toRegister)
            {
                NotificationHalper.SetNotification(this, "Failed", "Failed to register!");
                return View(ModelState);
            }

            NotificationHalper.SetNotification(this, "Success", "Register successfully!");
            return RedirectToAction(nameof(Login));
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _authenticationRepository.LogoutAsync();
            NotificationHalper.SetNotification(this, "Success", "Logout successfully!");
            return RedirectToAction("Index", "Home");
        }
    }
}
