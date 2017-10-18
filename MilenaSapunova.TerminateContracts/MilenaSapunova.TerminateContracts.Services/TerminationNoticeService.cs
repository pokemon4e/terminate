using Bytes2you.Validation;
using MilenaSapunova.TerminateContracts.Data.Repositories;
using MilenaSapunova.TerminateContracts.Data.SaveContext;
using MilenaSapunova.TerminateContracts.Model;
using System.Linq;

namespace MilenaSapunova.TerminateContracts.Services
{
    public class TerminationNoticeService : ITerminationNoticeService
    {
        private readonly IEfRepository<TerminationNotice> terminationNoticeRepo;
        private readonly ISaveContext context;

        public TerminationNoticeService(IEfRepository<TerminationNotice> terminationNoticeRepo, ISaveContext context)
        {
            Guard.WhenArgument(terminationNoticeRepo, "terminationNoticeRepo").IsNull().Throw();
            Guard.WhenArgument(context, "context").IsNull().Throw();
            this.terminationNoticeRepo = terminationNoticeRepo;
            this.context = context;
        }

        public IQueryable<TerminationNotice> GetAll()
        {
            return this.terminationNoticeRepo.All;
        }

        public void Update(TerminationNotice terminationNotice)
        {
            this.terminationNoticeRepo.Update(terminationNotice);
            this.context.Commit();
        }

        public void Add(TerminationNotice terminationNotice)
        {
            this.terminationNoticeRepo.Add(terminationNotice);
            this.context.Commit();
        }
    }
}

