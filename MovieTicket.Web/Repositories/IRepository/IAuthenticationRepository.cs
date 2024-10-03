

using MovieTicket.Models.ViewModels.AuthenticationVM;

namespace MovieTicket.Web.Repositories.IRepository
{
    public interface IAuthenticationRepository
    {
        Task<bool> Register(RegisterVM registerVM);
        Task<bool> Login(LoginVM loginVM);
        Task LogoutAsync();
    }
}
