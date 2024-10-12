using Microsoft.AspNetCore.Identity;
using MovieTicket.Models.ViewModels.AuthenticationVM;
using MovieTicket.Web.Data.Statics;
using MovieTicket.Web.Models;
using MovieTicket.Web.Repositories.IRepository;

namespace MovieTicketWebApplication.Repositories.Repository
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AuthenticationRepository(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        public async Task<bool> Login(LoginVM loginVM)
        {
            var user = await _userManager.FindByEmailAsync(loginVM.EmailAddress);

            if(user != null)
            {
                var passwordCheck = await _userManager.CheckPasswordAsync(user, loginVM.Pasword);

                if (passwordCheck)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, loginVM.Pasword, false, false);

                    return result.Succeeded;
                }
            }

            return false;
        }

        public async Task<bool> Register(RegisterVM registerVM)
        {
            var user = await _userManager.FindByEmailAsync(registerVM.EmailAddress);

            if(user == null)
            {
                var newUser = new ApplicationUser()
                {
                    UserName = registerVM.UserName,
                    Email = registerVM.EmailAddress,
                };

                var newUserResponse = await _userManager.CreateAsync(newUser, registerVM.Password);

                if(newUserResponse.Succeeded)
                {
                    if(!await _roleManager.RoleExistsAsync("Admin"))
                    {
                        await _roleManager.CreateAsync(new ApplicationRole("Admin"));
                        await _userManager.AddToRoleAsync(newUser, UserRoles.Admin);
                    }
                    if(!await _roleManager.RoleExistsAsync("User"))
                    {
                        await _roleManager.CreateAsync(new ApplicationRole("User"));
                    }

                    await _userManager.AddToRoleAsync(newUser, UserRoles.User);

                    return true;
                }
            }

            return false;
        }

        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
