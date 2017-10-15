using MilenaSapunova.TerminateContracts.Data.Repositories;
using MilenaSapunova.TerminateContracts.Model;
using System.Linq;

namespace MilenaSapunova.TerminateConracts.Services
{
    public class TerminationNoticeService
    {
        private readonly IEfRepository<TerminationNotice> terminationNoticeRepo;

        public TerminationNoticeService(IEfRepository<TerminationNotice> terminationNoticeRepo)
        {
            this.terminationNoticeRepo = terminationNoticeRepo;
        }

        public IQueryable<TerminationNotice> GetAll()
        {
            return this.terminationNoticeRepo.All;
        }
    }
}
