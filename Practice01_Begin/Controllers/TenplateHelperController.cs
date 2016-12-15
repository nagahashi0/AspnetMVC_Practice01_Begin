using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Practice01_Begin.Controllers
{
    public class TenplateHelperController : Controller
    {
        public ActionResult Index()
        {
            var mdl = new Models.TemplateHelperViewModel();
            return View(mdl);
        }

        public ActionResult DisplayForAction()
        {
            return View();
        }
    }
}