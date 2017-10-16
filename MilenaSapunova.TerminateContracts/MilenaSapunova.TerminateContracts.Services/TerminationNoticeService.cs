using Bytes2you.Validation;
using MilenaSapunova.TerminateContracts.Data.Repositories;
using MilenaSapunova.TerminateContracts.Model;
using System.Linq;

namespace MilenaSapunova.TerminateContracts.Services
{
    public class TerminationNoticeService
    {
        private readonly IEfRepository<TerminationNotice> terminationNoticeRepo;

        public TerminationNoticeService(IEfRepository<TerminationNotice> terminationNoticeRepo)
        {
            Guard.WhenArgument(terminationNoticeRepo, "terminationNoticeRepo").IsNull().Throw();
            this.terminationNoticeRepo = terminationNoticeRepo;
        }

        public IQueryable<TerminationNotice> GetAll()
        {
            return this.terminationNoticeRepo.All;
        }
    }
}
