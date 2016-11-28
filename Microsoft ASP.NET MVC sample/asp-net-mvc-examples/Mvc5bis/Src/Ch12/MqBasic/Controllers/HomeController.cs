using System.Web.Mvc;
using MqBasic.Services.Home;

namespace MqBasic.Controllers
{
    public class HomeController : Controller
    {
        private readonly HomeService _service;

        public HomeController()
        {
            _service = new HomeService();
        }

        public ActionResult Index()
        {
            var model = _service.GetModelForHome();
            return View(model);
        }
    }
}
