using System.Web.Mvc;
using CachingDemo.ViewModels;

namespace CachingDemo.Controllers
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
