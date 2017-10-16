using Bytes2you.Validation;
using MilenaSapunova.TerminateContracts.Data.Repositories;
using MilenaSapunova.TerminateContracts.Model;
using MilenaSapunova.TerminateContracts.Services.Contracts;
using System.Linq;

namespace MilenaSapunova.TerminateContracts.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly IEfRepository<Company> companyRepo;

        public CompanyService(IEfRepository<Company> companyRepo)
        {
            Guard.WhenArgument(companyRepo, "companyRepo").IsNull().Throw();
            this.companyRepo = companyRepo;
        }

        public IQueryable<Company> GetAll()
        {
            return this.companyRepo.All;
        }
    }
}
