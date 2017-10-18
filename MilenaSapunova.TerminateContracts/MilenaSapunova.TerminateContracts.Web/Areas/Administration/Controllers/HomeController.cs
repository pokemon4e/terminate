using MilenaSapunova.TerminateContracts.Web.Areas.Administration.Models;
using MilenaSapunova.TerminateContracts.Web.Infrastructure;
using System.Web.Mvc;
using MilenaSapunova.TerminateContracts.Data.SaveContext;
using MilenaSapunova.TerminateContracts.Services.Contracts;
using System.Linq;
using Bytes2you.Validation;

namespace MilenaSapunova.TerminateContracts.Web.Areas.Administration.Controllers
{
    [Authorize(Roles = "Admin")]
    public class HomeController : Controller
    {
        private readonly IUserService userService;
        private readonly ISaveContext saveContext;

        public HomeController(IUserService userService, ISaveContext saveContext)
        {
            Guard.WhenArgument(userService, "userService").IsNull().Throw();
            Guard.WhenArgument(saveContext, "saveContext").IsNull().Throw();

            this.userService = userService;
            this.saveContext = saveContext;
        }

        public ActionResult Index()
        {
            return View();
        }

        [AjaxOnly]
        public JsonResult GetUsers(int? page, int? limit, string sortBy, string direction)
        {
            var users = this.userService.GetAll().OrderBy(u => u.UserName);
            if (!string.IsNullOrEmpty(sortBy) && !string.IsNullOrEmpty(direction))
            {
                if (direction.Trim().ToLower() == "asc")
                {
                    switch (sortBy.Trim().ToLower())
                    {
                        case "firstname":
                            users = users.OrderBy(u => u.FirstName);
                            break;
                        case "lastname":
                            users = users.OrderBy(u => u.LastName);
                            break;
                        case "email":
                            users = users.OrderBy(u => u.Email);
                            break;
                        case "createdon":
                            users = users.OrderBy(u => u.CreatedOn);
                            break;
                    }
                }
                else
                {
                    switch (sortBy.Trim().ToLower())
                    {
                        case "username":
                            users = users.OrderByDescending(u => u.UserName);
                            break;
                        case "firstname":
                            users = users.OrderByDescending(u => u.FirstName);
                            break;
                        case "lastname":
                            users = users.OrderByDescending(u => u.LastName);
                            break;
                        case "email":
                            users = users.OrderByDescending(u => u.Email);
                            break;
                        case "createdon":
                            users = users.OrderByDescending(u => u.CreatedOn);
                            break;
                    }
                }
            }

            var total = users.Count();
            if (page.HasValue && limit.HasValue)
            {
                var start = (page.Value - 1) * limit.Value;
                users = users.Skip(start).Take(limit.Value).OrderBy(x => 1);
            }

            var records = users.MapTo<UserViewModel>().ToList();
            return this.Json(new { records, total }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [AjaxOnly]
        public JsonResult UserSave(UserViewModel record)
        {
            var user = userService.GetAll().Where(x => x.UserName == record.UserName).FirstOrDefault();
            if (user != null)
            {
                user.FirstName = record.FirstName;
                user.LastName = record.LastName;
                user.Email = record.Email;
                user.CreatedOn = record.CreatedOn;
                this.userService.Update(user);
                this.saveContext.Commit();
                return Json(new { result = true });
            }

            return Json(new { result = false });
        }

        [HttpPost]
        public JsonResult UserDelete(string id)
        {
            var user = userService.GetAll().Where(x => x.UserName == id).FirstOrDefault();

            if (user != null)
            {
                user.IsDeleted = true;
                this.saveContext.Commit();
                return Json(new { result = true });
            }

            return Json(new { result = false });
        }

        [AjaxOnly]
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public JsonResult IsUserExists(string UserName)
        {
            //check if any of the UserName matches the UserName specified in the Parameter
            return Json(!userService.GetAll().Any(x => x.UserName == UserName), JsonRequestBehavior.AllowGet);
        }
    }
}
