using System.Linq;
using System.Web.Mvc;
using Jobney.Core.Domain.Interfaces;
using Jobney.EF.Learning.Models;

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
    }
}
