using System.Linq;
using System.Web.Mvc;
using Jobney.Core.Domain.Interfaces;
using Jobney.EF.Learning.Models;
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
            var service = _uow.GetRepository<Customer>();
            var success = WebSecurity.Login(vm.EmailAddress, vm.Password);
            var user = new Customer();

            if (!success) return Json(user);

            var userId = WebSecurity.GetUserId(vm.EmailAddress);
            user = service.GetById(userId);
            return Json(user);
        }
    }

    public class LoginViewModel
    {
        public string EmailAddress { get; set; }
        public string Password { get; set; }
    }
}
