using MilenaSapunova.TerminateContracts.Model;
using System.Linq;

namespace MilenaSapunova.TerminateContracts.Services.Contracts
{
    public interface IUserService
    {
        IQueryable<User> GetAll();

        void Update(User company);
    }
}
