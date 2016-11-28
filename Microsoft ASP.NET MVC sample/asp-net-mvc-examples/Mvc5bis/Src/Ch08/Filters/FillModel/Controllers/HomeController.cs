using System;
using System.Web.Mvc;
using FillModel.Filters;
using FillModel.Filters.Fillers;
using FillModel.Services;

namespace FillModel.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICountryService _service;
        public HomeController()
            : this(new CountryService())
        {
        }
        public HomeController(ICountryService service)
        {
            _service = service;
        }

        public ActionResult Index()
        {
            var model = _service.GetHomePageViewModel();
            return View(model);
        }

        [HttpPost]
        [ActionName("details")]
        public ActionResult DetailsViaPost([Bind(Prefix = "countryList")] String country)
        {
            return RedirectToAction("details", new { id = country });
        }

        [HttpGet]
        [ActionName("details")]
        [ViewModelFiller(Type = typeof(CountryViewFiller))]
        public ActionResult DetailsViaGet(String id)
        {
            var model = _service.GetCountryViewModel(id);
            return View("details", model);
        }
    }
}
