using System.Web.Mvc;
using FatFree.Resources;
using FatFree.Services.Abstractions;
using FatFree.Services.Home;
using FatFree.ViewModels.Home;

namespace FatFree.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHomeService _homeService;

        public HomeController() : this(new HomeService())
        {
        }
        public HomeController(IHomeService service)
        {
            _homeService = service;
        }

        public ActionResult Index()
        {
            var model = _homeService.GetIndexViewModel();
            return View(model);
        }

        public ActionResult About()
        {
            var model = new AboutViewModel
            {
                Title = Strings.HomeAboutTitle,
                ContactInfo = Strings.Contact
            };
            return View(model);
        }
    }
}
