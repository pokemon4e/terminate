using System.Linq;
using MilenaSapunova.TerminateContracts.Model;
using MilenaSapunova.TerminateContracts.Services.Contracts;
using MilenaSapunova.TerminateContracts.Data.Repositories;
using Bytes2you.Validation;
using MilenaSapunova.TerminateContracts.Data.SaveContext;

namespace MilenaSapunova.TerminateContracts.Services
{
    public class ContractService : IContractService
    {
        private readonly IEfRepository<Contract> contractRepo;
        private readonly ISaveContext context;

        public ContractService(IEfRepository<Contract> contractRepo, ISaveContext context)
        {
            Guard.WhenArgument(contractRepo, "contractRepo").IsNull().Throw();
            Guard.WhenArgument(context, "context").IsNull().Throw();
            this.context = context;
            this.contractRepo = contractRepo;
        }

        public IQueryable<Contract> GetAll()
        {
            return this.contractRepo.All;
        }

        public void Update(Contract contract)
        {
            this.contractRepo.Update(contract);
            this.context.Commit();
        }
    }
}
