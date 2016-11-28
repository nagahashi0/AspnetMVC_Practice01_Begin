using System;
using System.Web.Mvc;
using BookSamples.Components.Data;
using Prg.Services.Home;

namespace Prg.Controllers
{
    public class HomeController : Controller
    {
        private readonly HomeService _service = new HomeService();

        public ActionResult Index()
        {
            var model = _service.GetModelForIndex();
            return View(model);
        }

        [HttpPost]
        [ActionName("edit")]
        public ActionResult EditViaPost([Bind(Prefix = "customerList")] String customerId)
        {
            // POST, now REDIRECT via GET to Edit
            return RedirectToAction("edit", new { id = customerId });
        }

        [HttpGet]
        [ActionName("edit")]
        public ActionResult EditViaGet(String id)
        {
            // Merge current ModelState with any being recovered from TempData
            LoadStateFromTempData();

            var model = _service.GetModelForEdit(id);
            return View("edit", model);
        }
        
        public ActionResult Update(SimpleCustomer customer)
        {
            var modelState = ViewData.ModelState;
            _service.TryUpdateCustomer(modelState, TempData, customer);
            return RedirectToAction("edit", new { id = customer.Id });
        }


        #region Internals
        private void LoadStateFromTempData()
        {
            var modelState = TempData["ModelState"] as ModelStateDictionary;
            if (modelState != null)
                ModelState.Merge(modelState);
        }
        #endregion
    }
}
