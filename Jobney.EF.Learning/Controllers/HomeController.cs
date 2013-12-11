using System.Linq;
using System.Web.Mvc;
using Jobney.Core.Domain.Interfaces;
using Jobney.EF.Learning.Models;

namespace Jobney.EF.Learning.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork uow;
        //
        // GET: /Home/
        public HomeController(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public ActionResult Index()
        {
            var service = uow.GetRepository<Customer>();
            service.InsertOrUpdate(new Customer
            {
                FirstName = "Justin",
                LastName = "Obney",
                Email = "justinobney@gmail.com"
            });
            uow.SaveChanges();

            var vm = service.Query().First(x => x.Email.Contains("justin"));

            return View(vm);
        }
    }
}
