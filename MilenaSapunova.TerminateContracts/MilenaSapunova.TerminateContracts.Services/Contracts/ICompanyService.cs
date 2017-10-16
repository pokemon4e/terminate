using MilenaSapunova.TerminateContracts.Model;
using System.Linq;

namespace MilenaSapunova.TerminateContracts.Services.Contracts
{
    public interface ICompanyService
    {
        IQueryable<Company> GetAll();

        void Update(Company company);
    }
}
