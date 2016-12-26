using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Practice01_Begin.Controllers
{
    public class ModelBindController : Controller
    {

        public ActionResult Show()
        {
            return View();
        }

        public ActionResult SimpleBind(string stringvalue)
        {
            string value = $"「{stringvalue}」が入力されました。";
            return Content(value);
        }

        public ActionResult SimpleBind2(int? intvalue)
        {
            string value = $"「{intvalue}」が入力されました。";
            return Content(value);
        }

        public ActionResult BindSample()
        {
            return View();
        }
        public ActionResult BindSampleResult(Models.BindSampleViewModel mdl)
        {
            string value = "";
            if (mdl.ImportantValue != null)
            {
                value = "重要な処理をする";
            }
            else
            {
                value = $"「{mdl.StringValue},{mdl.IntValue}」が入力されました。";
            }
            return Content(value);
        }

    }
}