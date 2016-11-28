using System;
using System.Web.Mvc;
using BookSamples.Components.Data;
using Sep.Services.Home;

namespace Sep.Controllers
{
    public class HomeController : Controller
    {
        private readonly HomeService _service = new HomeService();

        public ActionResult Index()
        {
            var model = _service.GetModelForIndex();
            return View(model);
        }

        public ActionResult Edit([Bind(Prefix = "customerList")] String customerId)
        {
            var model = _service.GetModelForEdit(customerId);
            return View(model);
        }

        public ActionResult Update(SimpleCustomer customer)
        {
            var modelState = ViewData.ModelState;
            var model = _service.TryUpdateCustomer(modelState, customer);
            return View("edit", model);
        }
    }
}
