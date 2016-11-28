using System.Web.Mvc;
using ImageMan.ViewModels;

namespace ImageMan.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var model = new ViewModelBase();
            return View(model);
        }
    }
}
