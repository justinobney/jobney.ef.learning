using System.Web.Mvc;
using Jobney.EF.Learning.Commands;

namespace Jobney.EF.Learning.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            var newPerson = Mediator.Send(new CreateUserCommand
            {
                FirstName = "Justin",
                LastName = "Obney",
                Email = "justinobney@gmail.com"
            });


            return View(newPerson);
        }
    }
}
