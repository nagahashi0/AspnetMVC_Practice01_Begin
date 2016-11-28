using System.Web.Mvc;
using JsFun.ViewModels;

namespace JsFun.Controllers
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
