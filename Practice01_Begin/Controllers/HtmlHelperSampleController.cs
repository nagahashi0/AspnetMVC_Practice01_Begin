using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Practice01_Begin.Controllers
{
    public class HtmlHelperSampleController : Controller
    {
       
        public ActionResult Edit(int id)
        {
            return Content(id.ToString());
        }
    }
}