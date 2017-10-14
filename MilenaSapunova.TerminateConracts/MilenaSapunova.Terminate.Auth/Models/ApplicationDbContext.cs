using Microsoft.AspNet.Identity.EntityFramework;
using MilenaSapunova.Terminate.Auth.Models;

namespace MilenaSapunova.TerminateConracts.Auth.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}