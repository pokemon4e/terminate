using System.Linq;
using MilenaSapunova.TerminateContracts.Model;
using MilenaSapunova.TerminateContracts.Services.Contracts;
using MilenaSapunova.TerminateContracts.Data.Repositories;
using Bytes2you.Validation;

namespace MilenaSapunova.TerminateContracts.Services
{
    public class ContractService : IContractService
    {
        private readonly IEfRepository<Contract> contractRepo;

        public ContractService(IEfRepository<Contract> contractRepo)
        {
            Guard.WhenArgument(contractRepo, "contractRepo").IsNull().Throw();
            this.contractRepo = contractRepo;
        }

        public IQueryable<Contract> GetAll()
        {
            return this.contractRepo.All;
        }
    }
}
