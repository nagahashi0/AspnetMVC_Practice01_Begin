using System.Web.Mvc;
using AutoLanguage.ViewModels;

namespace AutoLanguage.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var model = new ViewModelBase();
            return View(model);
        }

        public ActionResult About()
        {
            var model = new ViewModelBase();
            return View(model);
        }
    }
}
