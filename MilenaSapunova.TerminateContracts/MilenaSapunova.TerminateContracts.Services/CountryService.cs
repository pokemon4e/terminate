using MilenaSapunova.TerminateContracts.Services.Contracts;
using System.Linq;
using MilenaSapunova.TerminateContracts.Model;
using Bytes2you.Validation;
using MilenaSapunova.TerminateContracts.Data.Repositories;

namespace MilenaSapunova.TerminateContracts.Services
{
    public class CountryService : ICountryService
    {
        private readonly IEfRepository<Country> countryRepo;

        public CountryService(IEfRepository<Country> countryRepo)
        {
            Guard.WhenArgument(countryRepo, "countryRepo").IsNull().Throw();
            this.countryRepo = countryRepo;
        }

        public IQueryable<Country> GetAll()
        {
            return this.countryRepo.All;
        }

    }
}
