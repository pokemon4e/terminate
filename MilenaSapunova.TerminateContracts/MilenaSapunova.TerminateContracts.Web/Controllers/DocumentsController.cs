using MilenaSapunova.TerminateContracts.Services;
using MilenaSapunova.TerminateContracts.Web.Infrastructure;
using MilenaSapunova.TerminateContracts.Web.Models;
using System.Linq;
using System.Web.Mvc;

namespace MilenaSapunova.TerminateContracts.Web.Controllers
{
    public class DocumentsController : Controller
    {
        private readonly ITerminationNoticeService terminationNoticeService;

        public DocumentsController(ITerminationNoticeService terminationNoticeService)
        {
            this.terminationNoticeService = terminationNoticeService;
        }

        // GET: Document
        public ActionResult All()
        {
            var documents = this.terminationNoticeService
                .GetAll()
                .MapTo<TerminationNoticeViewModel>()
               .ToList();
            return View(documents);
        }
    }
}