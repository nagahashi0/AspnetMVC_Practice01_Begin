using System.Web.Mvc;
using AnyProvider.ViewModels;

namespace AnyProvider.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var model = new ViewModelBase();
            return View(model);
        }

        [Authorize]
        public ActionResult MembersOnly()
        {
            return View();
        }
    }
}
