using System;
using System.Globalization;
using System.Threading;
using System.Web.Mvc;
using AspectMix.Resources;
using AspectMix.ViewModels.Home;
using BookSamples.Components.Filters;
using BookSamples.Components.Filters.Axpect;

namespace AspectMix.Controllers
{
    public class HomeController : AxpectController //Controller
    {
        public ActionResult Index()
        {
            // Add a bit of delay for demo purposes ...
            AddDelay();

            var model = new IndexViewModel
            {
                Title = Strings.HomeIndexTitle,
                Message = String.Format(Strings.WelcomeMessageFormat, Strings.AppName)
            };
            return View(model);
        }

        [AddHeader(Name="Action", Value="About")]
        [ReportDuration(Name="despos-mvc4-duration")]
        [Compress]
        public ActionResult About()
        {
            // Add a bit of delay for demo purposes ...
            AddDelay();

            var model = new AboutViewModel
            {
                Title = Strings.HomeAboutTitle,
                ContactInfo = Strings.Contact
            };
            return View(model);
        }

        // Dynamically bound to action filters
        public ActionResult Test()
        {
            var model = new TestViewModel
            {
                Title = Strings.HomeIndexTitle
            };
            return View(model);
        }

        [BrowserSpecific]
        public ActionResult Multi()
        {
            return View();
        }


        #region Helpers
        private static void AddDelay()
        {
            var ms = new Random().Next(100, 500);
            Thread.Sleep(ms);
        }
        #endregion

        #region Embedded Filters
        protected DateTime StartTime;

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var action = filterContext.ActionDescriptor.ActionName;
            if (String.Equals(action, "index", StringComparison.CurrentCultureIgnoreCase))
            {
                var timeSpan = DateTime.Now - StartTime;
                filterContext.RequestContext.HttpContext.Response.AddHeader(
                    "despos-mvc4", 
                    timeSpan.Milliseconds.ToString(CultureInfo.InvariantCulture));
            }

            base.OnActionExecuted(filterContext);
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var action = filterContext.ActionDescriptor.ActionName;
            if (String.Equals(action, "index", StringComparison.CurrentCultureIgnoreCase))
            {
                StartTime = DateTime.Now;
            }

            base.OnActionExecuting(filterContext);
        }

        #endregion
    }
}
