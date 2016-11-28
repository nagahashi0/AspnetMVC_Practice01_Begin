using System;
using System.Web.Mvc;
using DataAnnotations.ViewModels.Memo;

namespace DataAnnotations.Controllers
{
    public class MemoController : Controller
    {
        public ActionResult Edit()
        {
            var memo = new MemoDocument();
            return View(memo);
        }

        [HttpPost]
        public ActionResult Edit(MemoDocument memo)
        {
            // Model binding edits ModelState when binding posted values
            // to Memo. If you have ValidationMessage helpers in the view
            // error messages show up automatically.
            if (!ModelState.IsValid)
            {
                var newModelState = new ModelStateDictionary();
                newModelState.AddModelError("Text", "Error message for Text");
                ModelState.Merge(newModelState);
            }

            //if (Request.IsAjaxRequest())
            //    return PartialView("edit_ajax", memo);
            return View(memo);
        }

        public ActionResult CheckCustomer(String relatedCustomer, Int32 magicnumber)
        {
            if (relatedCustomer.Contains("d"))
                return Json(true, JsonRequestBehavior.AllowGet);
            return Json(false, JsonRequestBehavior.AllowGet);
        }
    }
}
