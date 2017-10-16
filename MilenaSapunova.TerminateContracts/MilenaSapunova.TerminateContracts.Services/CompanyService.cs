using Bytes2you.Validation;
using MilenaSapunova.TerminateContracts.Data.Repositories;
using MilenaSapunova.TerminateContracts.Data.SaveContext;
using MilenaSapunova.TerminateContracts.Model;
using MilenaSapunova.TerminateContracts.Services.Contracts;
using System.Linq;

namespace MilenaSapunova.TerminateContracts.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly IEfRepository<Company> companyRepo;
        private readonly ISaveContext context;

        public CompanyService(IEfRepository<Company> companyRepo, ISaveContext context)
        {
            Guard.WhenArgument(companyRepo, "companyRepo").IsNull().Throw();
            Guard.WhenArgument(context, "context").IsNull().Throw();
            this.context = context;
            this.companyRepo = companyRepo;
        }

        public IQueryable<Company> GetAll()
        {
            return this.companyRepo.All;
        }

        public void Update(Company company)
        {
            this.companyRepo.Update(company);
            this.context.Commit();
        }
    }
}
