using MilenaSapunova.TerminateContracts.Model;
using System.Linq;

namespace MilenaSapunova.TerminateConracts.Services
{
    public interface ITerminationNoticeService
    {
        IQueryable<TerminationNotice> GetAll();
    }
}
