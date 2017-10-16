using MilenaSapunova.TerminateContracts.Model;
using System.Linq;

namespace MilenaSapunova.TerminateContracts.Services.Contracts
{
    public interface ICountryService
    {
        IQueryable<Country> GetAll();
    }
}
