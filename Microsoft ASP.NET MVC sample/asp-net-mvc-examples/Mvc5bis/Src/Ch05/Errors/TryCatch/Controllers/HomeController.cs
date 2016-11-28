using System;
using System.Web.Mvc;
using BookSamples.Components.Extensions;
using TryCatch.ViewModels;

namespace TryCatch.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var model = new ViewModelBase();
            return View(model);
        }

        public ActionResult Error()
        {
            return View();
        }

        public ActionResult Binder(int someValue)
        {
            // If this method gets a param, and model binding can't resolve it, you're
            // going to get an exception that OnException wouldn't trap.

            return View();
        }

        public ActionResult Catch()
        {
            var currentTime = DateTime.Now;
            Process(currentTime);

            ViewBag.CurrentTime = currentTime.ToLongTimeString();
            return View();
        }

        public ActionResult Degrade()
        {
            var viewName = "catch";
            try
            {
                var currentTime = DateTime.Now;
                Process(currentTime);
                ViewBag.CurrentTime = currentTime.ToShortTimeString();
            }
            catch (InvalidOperationException)
            {
                viewName = "error";
            }

            return View(viewName);
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            if (filterContext.Exception is InvalidOperationException)
            {
                // Default view name is "error"
                filterContext.SwitchToErrorView();
            }
        }

        private static void Process(DateTime time)
        {
            var shouldThrow = (time.Second % 2 > 0);
            if (shouldThrow)
                throw new InvalidOperationException("This operation is not valid at this time.");
        }
    }
}
