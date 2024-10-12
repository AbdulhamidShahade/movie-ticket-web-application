using Microsoft.AspNetCore.Identity;

namespace MovieTicket.Web.Models
{
    public class ApplicationRole : IdentityRole<int>
    {
        public ApplicationRole() { }
        public ApplicationRole(string newRole)
        {
            this.Name = newRole;
        }
    }
}
