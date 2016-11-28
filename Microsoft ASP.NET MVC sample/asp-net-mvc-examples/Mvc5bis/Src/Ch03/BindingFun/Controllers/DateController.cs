using System;
using System.Web.Mvc;
using BindingFun.ViewModels.Date;
using BookSamples.Components.Binders;

namespace BindingFun.Controllers
{
    public class DateController : Controller
    {
        [HttpGet]
        [ActionName("Editor")]
        public ActionResult EditorForGet()
        {
            var model = new EditorViewModel();
            return View(model);
        }

        [HttpPost]
        [ActionName("Editor")]
        public ActionResult EditorForPost(
            [ModelBinder(typeof(DateModelBinder))]DateTime theDate)
        {
            // Local model-binder takes precedence over other matching binders 
            // defined in global.asax.
            var model = new EditorViewModel();
            if (theDate != default(DateTime))
            {
                model.DefaultDate = theDate;
                model.TimeToToday = DateTime.Today.AddMonths(4).Subtract(theDate);
            }
            return View(model);
        }
    }
}
