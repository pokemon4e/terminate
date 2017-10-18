using Bytes2you.Validation;
using MilenaSapunova.TerminateContracts.Data.Models;

namespace MilenaSapunova.TerminateContracts.Data.SaveContext
{
    public class SaveContext : ISaveContext
    {
        private readonly MsSqlDbContext context;

        public SaveContext(MsSqlDbContext context)
        {
            Guard.WhenArgument(context, "context").IsNull().Throw();
            this.context = context;
        }

        public void Commit()
        {
            this.context.SaveChanges();
        }
    }
}
