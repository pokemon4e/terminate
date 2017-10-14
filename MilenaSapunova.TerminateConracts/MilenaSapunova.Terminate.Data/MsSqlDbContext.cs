using Microsoft.AspNet.Identity.EntityFramework;
using MilenaSapunova.Terminate.Data.Models;

namespace MilenaSapunova.TerminateConracts.Data.Models
{
    public class MsSqlDbContext : IdentityDbContext<User>
    {
        public MsSqlDbContext() : base("DbConnection", throwIfV1Schema: false)
        {
        }


        public static MsSqlDbContext Create()
        {
            return new MsSqlDbContext();
        }
    }
}