using System;
using System.Web.Mvc;
using CachingDemo.Framework;
using CachingDemo.ViewModels.Intrinsics;

namespace CachingDemo.Controllers
{
    public class IntrinsicsController : Controller
    {
        // Use this service-based approach if you only need caching from within controllers.
        // Use a global cache entry (i.e., via HttpApplication) to use it from anywhere (handlers, modules, filters).
        private readonly ICacheService _cacheService;

        public IntrinsicsController() : this(MvcApplication.CacheService)
        {            
        }
        public IntrinsicsController(ICacheService cacheService)
        {
            _cacheService = cacheService;
        }

        /// <summary>
        /// Read preferences set through session state and an app-specific cookie
        /// </summary>
        /// <returns>View</returns>
        [HttpGet]
        [ActionName("State")]
        public ActionResult GetState()
        {
            PreferenceManager.Load(HttpContext);
            var model = new StateViewModel {TextColor = PreferenceManager.TextColor};
            return View(model);
        }

        /// <summary>
        /// Save preferences to session state and/or an app-specific cookie
        /// </summary>
        /// <param name="viewModel">Form fields</param>
        /// <returns>View</returns>
        [HttpPost]
        [ActionName("State")]
        public ActionResult SetState(StateViewModel viewModel)
        {
            PreferenceManager.Save(HttpContext, viewModel.TextColor, viewModel.Persistent);
            var model = new StateViewModel { TextColor = PreferenceManager.TextColor };
            return View(model);
        }

        public ActionResult CacheTest()
        {
            ViewBag.StartTime = (DateTime)_cacheService["StartTime"];
            return View();
        }
    }
}
