using System.Web.Mvc;
using SimplyMobile.ViewModels;

namespace SimplyMobile.Controllers
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
