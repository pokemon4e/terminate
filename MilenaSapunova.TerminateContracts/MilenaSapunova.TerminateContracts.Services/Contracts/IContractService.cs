using MilenaSapunova.TerminateContracts.Model;
using System.Linq;

namespace MilenaSapunova.TerminateContracts.Services.Contracts
{
    public interface IContractService
    {
        IQueryable<Contract> GetAll();

        void Update(Contract company);
    }
}
