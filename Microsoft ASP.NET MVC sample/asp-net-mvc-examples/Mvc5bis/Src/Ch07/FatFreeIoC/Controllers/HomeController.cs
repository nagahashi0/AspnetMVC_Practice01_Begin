using System.Web.Mvc;
using FatFreeIoC.Resources;
using FatFreeIoC.Services.Abstractions;
using FatFreeIoC.ViewModels.Home;

namespace FatFreeIoC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHomeService _homeService;

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
