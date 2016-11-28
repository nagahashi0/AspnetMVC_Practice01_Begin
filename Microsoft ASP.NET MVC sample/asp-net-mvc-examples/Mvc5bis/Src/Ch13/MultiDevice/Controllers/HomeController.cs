using System.Web.Mvc;
using MultiView2.Services.Home;
using MultiView2.Services.Shared;

namespace MultiView2.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHomeOrchestrator _service;
        public HomeController() : this(new HomeOrchestrator())
        {
        }
        public HomeController(IHomeOrchestrator service)
        {
            _service = service;
        }

        public ActionResult Index()
        {
            // Basic info
            var model = _service.GetModelForIndex();

            // Add device specific logic
            model.GotoAppStoreLink = _service.GetAppStoreLink(Request.UserAgent);

            return View(model);
        }

    }
}
