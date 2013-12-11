using System.Web.Mvc;
using Envoc.Mediator;

namespace Jobney.EF.Learning.Controllers
{
    public class BaseController:Controller
    {
        public IMediator Mediator { get; set; }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Mediator = DependencyResolver.Current.GetService<IMediator>();
        }
    }
}