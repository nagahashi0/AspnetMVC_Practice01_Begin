using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Practice01_Begin.Controllers
{
    public class HtmlHelperController : Controller
    {
        // GET: HtmlHelper
        public ActionResult Index()
        {


            Models.HtmlHelperViewModels mdl = new Models.HtmlHelperViewModels();
            mdl.LabelText = "LabelTextValue";
            mdl.TextBoxText = "TextBoxTextValue";
            mdl.TextAreaText = "TextAreaTextValue" + System.Environment.NewLine + "line2";
            mdl.PasswordText = "PasswordTextValue";
            mdl.HiddenValue = "HiddenValue";
            mdl.RadioValue = "RadioValueB";
            mdl.CheckBoxValueA = true;
            mdl.CheckBoxValueB = true;
            mdl.CheckBoxValueC = false;
            mdl.DropDownValue = "5";
            mdl.ListBoxValues = new string[] { "3", "6" };
            mdl.EnumValue = Models.WeekdayType.Thursday;

            return View(mdl);
            
        }
                

        public ActionResult Edit(int id)
        {
            return Content(id.ToString());
        }
    }
}