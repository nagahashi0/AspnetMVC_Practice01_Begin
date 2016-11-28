using System.Web.Mvc;
using DataAnnotations.ViewModels;

namespace DataAnnotations.Controllers
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
