using System.Web.Mvc;

namespace MoreRoutes.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post | HttpVerbs.Get)]
        public ActionResult About()
        {
            return View();
        }
    }
}
