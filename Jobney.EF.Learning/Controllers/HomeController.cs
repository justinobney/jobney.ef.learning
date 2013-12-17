using System;
using System.Linq;
using System.Web.Mvc;
using Jobney.Core.Domain.Interfaces;
using Jobney.EF.Learning.Models;
using Jobney.EF.Learning.Security;
using Jobney.EF.Learning.ViewModels;
using WebMatrix.WebData;

namespace Jobney.EF.Learning.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IUnitOfWork _uow;

        public HomeController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public ActionResult Index()
        {
            var service = _uow.GetRepository<Customer>();
            var vm = service.GetAll().FirstOrDefault();

            return View(vm);
        }

        public ActionResult SinglePageApp()
        {
            return View();
        }

        public ActionResult ListOfProducts()
        {
            return Json(new {});
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel vm)
        {
            var customerService = _uow.GetRepository<Customer>();
            var tokenService = _uow.GetRepository<ApiToken>();

            var success = WebSecurity.Login(vm.EmailAddress, vm.Password);
            var user = new Customer();

            if (!success) return Json(user);

            var userId = WebSecurity.GetUserId(vm.EmailAddress);
            user = customerService.GetById(userId);
            var token = new ApiToken
            {
                Key = HashSecurity.GenerateAppSecret(),
                UserId = user.Id,
                Created = DateTime.Now,
                ValidUntil = DateTime.Now.AddDays(30),
                ExplicitExpirationDate = null
            };
            tokenService.InsertOrUpdate(token);
            _uow.SaveChanges();

            return Json(new {user, token});
        }
    }
}
