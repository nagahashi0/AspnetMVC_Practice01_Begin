using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Practice01_Begin.Controllers
{
    public class RazorController : Controller
    {
        public ActionResult Show()
        {
            var mdl = new Models.RazorShowViewModel();
            mdl.Message = "Hello World";
            mdl.UserName = "yan";
            mdl.Price = 1000;
            return View(mdl);
        }

    }
}