using System;
using System.Web.Mvc;
using BookSamples.Components.Filters;
using SampleApp.Services;

namespace SampleApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHomeService _service;

        public HomeController()
            : this(new HomeService())
        {
        }
        public HomeController(IHomeService service)
        {
            _service = service;
        }

        public ActionResult Index()
        {
            _service.GetIndexViewModel(ViewBag);
            return View();
        }

        [AddHeader(Name = "Author", Value = "Dino")]
        public ActionResult About()
        {
            return View();
        }

        public ActionResult Output()
        {
            HttpContext.Response.Write("Hello");
            return View("index");
        }

        public ActionResult SetColor()
        {
            var color = GetFavoriteColor();
            Session["PreferredColor"] = color;
            return View("index");
        }

        public ActionResult GetColor()
        {
            var o = Session["PreferredColor"];
            if (o == null)
                ViewData["Color"] = "No preferred color";
            else
                ViewData["Color"] = o as String;

            return View("index");
        }

        [NonAction]
        public String GetFavoriteColor()
        {
            return "green";
        }

    }
}
