using System.Web.Mvc;

namespace MilenaSapunova.TerminateContracts.Web.Areas.Administration.Controllers
{
    [Authorize(Roles ="Admin")]
    public class HomeController : Controller
    {
        public ActionResult Index() 
        {
            return View();
        }
    }
}