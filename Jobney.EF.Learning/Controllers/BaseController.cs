using System.Text;
using System.Web.Mvc;

namespace Jobney.EF.Learning.Controllers
{
    public class BaseController:Controller
    {
        protected internal new JsonResult Json(object data)
        {
            return Json(data, null, null, JsonRequestBehavior.AllowGet);
        }

        protected internal new JsonResult Json(object data, string contentType)
        {
            return Json(data, contentType, null, JsonRequestBehavior.AllowGet);
        }

        protected internal new virtual JsonResult Json(object data, string contentType, Encoding contentEncoding)
        {
            return Json(data, contentType, contentEncoding, JsonRequestBehavior.AllowGet);
        }
    }
}