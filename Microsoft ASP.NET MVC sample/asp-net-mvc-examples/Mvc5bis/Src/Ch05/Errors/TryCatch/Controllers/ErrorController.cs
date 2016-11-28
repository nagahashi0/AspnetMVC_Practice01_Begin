using System.Web.Mvc;

namespace TryCatch.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult Missing()
        {
            ViewBag.Url = Request.Url;
            return View();
        }
    }
}
