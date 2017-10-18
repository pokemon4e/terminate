using MilenaSapunova.TerminateContracts.Services.Contracts;
using System.Linq;
using MilenaSapunova.TerminateContracts.Model;
using Bytes2you.Validation;
using MilenaSapunova.TerminateContracts.Data.Repositories;
using MilenaSapunova.TerminateContracts.Data.SaveContext;

namespace MilenaSapunova.TerminateContracts.Services
{
    public class CountryService : ICountryService
    {
        private readonly IEfRepository<Country> countryRepo;
        private readonly ISaveContext context;

        public CountryService(IEfRepository<Country> countryRepo, ISaveContext context)
        {
            Guard.WhenArgument(countryRepo, "countryRepo").IsNull().Throw();
            Guard.WhenArgument(context, "context").IsNull().Throw();
            this.context = context;
            this.countryRepo = countryRepo;
        }

        public IQueryable<Country> GetAll()
        {
            return this.countryRepo.All;
        }

        public void Update(Country country)
        {
            this.countryRepo.Update(country);
            this.context.Commit();
        }

    }
}
