using System;
using System.Web.Mvc;

namespace SampleApp.Controllers
{
    public class ProductController : Controller
    {
        public ActionResult Find(String id)
        {
            ViewBag.ProductId = id;
            return View();
        }

        public ActionResult Code(String id)
        {
            ViewBag.ProductId = id;
            return View("Find");
        }
    }
}
