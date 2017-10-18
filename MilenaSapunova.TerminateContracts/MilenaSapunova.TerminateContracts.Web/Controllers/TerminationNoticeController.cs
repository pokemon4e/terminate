using MilenaSapunova.TerminateContracts.Data.SaveContext;
using MilenaSapunova.TerminateContracts.Services;
using System.Web.Mvc;
using System;
using MilenaSapunova.TerminateContracts.Web.Models;
using System.Linq;
using MilenaSapunova.TerminateContracts.Model;
using MilenaSapunova.TerminateContracts.Web.Infrastructure;
using Microsoft.AspNet.Identity;
using MilenaSapunova.TerminateContracts.Services.Contracts;

namespace MilenaSapunova.TerminateContracts.Web.Controllers
{
    public class TerminationNoticeController : Controller
    {
        private readonly ITerminationNoticeService terminationNoticeService;
        private readonly ISaveContext saveContext;
        private readonly IUserService userService;

        public TerminationNoticeController(ITerminationNoticeService terminationNoticeService, IUserService userService, ISaveContext saveContext)
        {
            this.terminationNoticeService = terminationNoticeService;
            this.saveContext = saveContext;
            this.userService = userService;
        }

        [HttpGet]
        public ActionResult Add(Guid? guid)
        {
            TerminationNoticeViewModel template;

            if (guid != null)
            {
                template = this.terminationNoticeService
                    .GetAll()
                    .Where(t => t.Id == guid)
                    .MapTo<TerminationNoticeViewModel>()
                    .FirstOrDefault();
            }
            else
            {
                template = this.terminationNoticeService
                    .GetAll()
                    .Where(t => t.IsTemplate == true)
                    .MapTo<TerminationNoticeViewModel>()
                    .FirstOrDefault();
            }

            return View(template);
        }

        [HttpPost]
        public ActionResult Add(TerminationNoticeViewModel termination)
        {
            var notice = new TerminationNotice();

            var username = User.Identity.GetUserName();
            notice.Owner = this.userService.GetAll().Where(x => x.UserName == username).FirstOrDefault();
            notice.Content = termination.Content;
            notice.Company = new Company
            {
                Name = termination.Company.Name,
                PhoneNumber = termination.Company.PhoneNumber,
                Email = termination.Company.Email,
                Address = new Address
                {
                    Name = termination.Company.Address,
                    Town = new Town
                    {
                        Name = termination.Company.Town,
                        PostalCode = termination.Company.PostalCode,
                        Country = new Country { Name = termination.Company.Country }
                    }
                }
            };

            this.terminationNoticeService.Add(notice);
            this.saveContext.Commit();

            return View(termination);
        }
    }
}