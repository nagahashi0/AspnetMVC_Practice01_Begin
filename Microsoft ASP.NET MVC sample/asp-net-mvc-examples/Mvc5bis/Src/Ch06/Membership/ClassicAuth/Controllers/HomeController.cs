using System;
using System.Web.Mvc;
using BookSamples.Components.Security;
using ClassicAuth.ViewModels;

namespace ClassicAuth.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var model = new ViewModelBase();
            return View(model);
        }

        [AuthorizedOnly(Users = "dino")]
        public ActionResult About()
        {
            var model = new ViewModelBase();
            return View(model);
        }

        [AuthorizedOnly]
        public ActionResult Now()
        {
            var model = new ViewModelBase();
            ViewBag.Now = DateTime.Now.ToString("hh:mm:ss");
            if (Request.IsAjaxRequest())
                return PartialView("aNow");

            return View(model);
        }

        [Authorize]
        public String Test()
        {
            return "TEST";
        }
    }
}
