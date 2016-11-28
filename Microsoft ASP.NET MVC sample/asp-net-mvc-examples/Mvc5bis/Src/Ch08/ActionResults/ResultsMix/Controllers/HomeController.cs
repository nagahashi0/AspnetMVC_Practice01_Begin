using System;
using System.Collections.Generic;
using System.ServiceModel.Syndication;
using System.Web.Mvc;
using BookSamples.Components.ActionResults;
using ResultsMix.Framework;
using HttpNotFoundResult = System.Web.Mvc.HttpNotFoundResult;

namespace ResultsMix.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Forbidden()
        {
            return new HttpStatusCodeResult(403);
        }

        public ActionResult NotModified()
        {
            return new HttpStatusCodeResult(304);
        }

        public ActionResult NotFound()
        {
            return new HttpNotFoundResult();
        }

        public ActionResult Javascript()
        {
            var script = "function helloWorld() {alert('hello, world!');}";
            //return JavaScript(script);
            var result = new JavaScriptResult { Script = script };
            return result;
        }

        public ActionResult GetScript()
        {
            return File(Url.Content("~/content/scripts/app-script.js"), "text/javascript");
        }

        public ActionResult GetCountries(String area)
        {
            // Grab some data to return
            var countries = CountryRepository.GetAll(area);

            // Serialize to JSON and return
            return Json(countries, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetCountriesJsonp(String area)
        {
            var result = new JsonpResult
            {
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                Data = CountryRepository.GetAll(area)
            };
            return result;
        }

        public ActionResult Feed()
        {
            var items = new List<SyndicationItem>();
            items.Add(new SyndicationItem(
                "Controller descriptors",
                "This post shows how to customize controller descriptors",
                null));  // null has to be  the link to the post
            items.Add(new SyndicationItem(
                "Action filters",
                "Using a fluent API to define action filters",
                null));
            items.Add(new SyndicationItem(
                "Custom action results",
                "Create a custom action result for syndication data",
                null));

            var result = new SyndicationResult("Programming ASP.NET MVC",
                "Dino's latest book", Request.Url, items)
            {
                Type = FeedType.Atom
            };
            return result;
        }

        public ActionResult Img()
        {
            const String file = "stones.jpg";
            return File(Server.MapPath(String.Format("~/content/images/{0}", file)), "image/jpeg");
        }
    }
}
