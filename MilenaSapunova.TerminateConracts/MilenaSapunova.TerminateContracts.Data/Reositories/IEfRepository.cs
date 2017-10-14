using System.Linq;

namespace MilenaSapunova.Terminate.Data.Reositories
{
    public interface IEfRepository<T> where T : class
    {
        IQueryable<T> All { get; }

        IQueryable<T> AllAndDeleted { get; }

        void Add(T entity);

        void Delete(T entity);

        void Update(T entity);
    }
}
