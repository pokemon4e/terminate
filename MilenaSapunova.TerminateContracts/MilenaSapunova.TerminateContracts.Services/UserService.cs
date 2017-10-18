using System.Linq;
using MilenaSapunova.TerminateContracts.Model;
using MilenaSapunova.TerminateContracts.Services.Contracts;
using MilenaSapunova.TerminateContracts.Data.Repositories;
using MilenaSapunova.TerminateContracts.Data.SaveContext;
using Bytes2you.Validation;

namespace MilenaSapunova.TerminateContracts.Services
{
    public class UserService : IUserService
    {
        private readonly IEfRepository<User> userRepo;
        private readonly ISaveContext context;

        public UserService(IEfRepository<User> userRepo, ISaveContext context)
        {
            Guard.WhenArgument(userRepo, "userRepo").IsNull().Throw();
            Guard.WhenArgument(context, "context").IsNull().Throw();
            this.userRepo = userRepo;
            this.context = context;
        }

        public IQueryable<User> GetAll()
        {
            return this.userRepo.All;
        }

        public void Update(User user)
        {
            this.userRepo.Update(user);
            this.context.Commit();
        }
    }
}
