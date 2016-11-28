using System.Web.Mvc;
using Html5.ViewModels;

namespace Html5.Controllers
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
