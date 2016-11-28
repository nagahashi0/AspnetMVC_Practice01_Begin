using System.Web.Mvc;
using RpcStyle.ViewModels;

namespace RpcStyle.Controllers
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
