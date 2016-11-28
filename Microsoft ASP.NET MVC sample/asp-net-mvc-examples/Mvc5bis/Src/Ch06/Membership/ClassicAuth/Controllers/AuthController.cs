using System;
using System.Web.Mvc;
using System.Web.Security;
using ClassicAuth.ViewModels;
using ClassicAuth.ViewModels.Auth;

namespace ClassicAuth.Controllers
{
    public class AuthController : Controller
    {
        /// <summary>
        /// Displays the login view
        /// </summary>
        /// <returns>HTML view</returns>
        [HttpGet]
        public ActionResult LogOn()
        {
            return View(new LogonViewModel());
        }

        /// <summary>
        /// Gets posted credentials and performs actual validation.
        /// </summary>
        /// <param name="model">Credentials and related information</param>
        /// <param name="returnUrl">Originally requested URL</param>
        /// <param name="defaultAction">Action to default when no return URL is specified</param>
        /// <param name="defaultController">Controller to default when no return URL is specified</param>
        /// <returns>Error view or requested redirect</returns>
        [HttpPost]
        public ActionResult Logon(LogonViewModel model, String returnUrl, String defaultAction = "Index", String defaultController = "Home")
        {
            var isValidReturnUrl = IsValidReturnUrl(returnUrl);

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "The user name or password provided is incorrect.");
                return View(model);
            }

            // Validate and proceed
            if (Membership.ValidateUser(model.UserName, model.Password))
            {
                FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);
                if (isValidReturnUrl)
                {
                    return Redirect(returnUrl);
                }
                return RedirectToAction(defaultAction, defaultController);
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        /// <summary>
        /// Logs off and redirects to the specified view.
        /// </summary>
        /// <param name="defaultAction">Action to redirect</param>
        /// <param name="defaultController">Controller to redirect</param>
        /// <returns>Redirect</returns>
        public ActionResult Logoff(String defaultAction = "Index", String defaultController = "Home")
        {
            FormsAuthentication.SignOut();
            return RedirectToAction(defaultAction, defaultController);
        }

        /// <summary>
        /// Logs off and redirects to the specified route.
        /// </summary>
        /// <param name="defaultRoute">Route to redirect</param>
        /// <returns>Redirect</returns>
        public ActionResult LogOffToRoute(String defaultRoute)
        {
            FormsAuthentication.SignOut();
            return RedirectToRoute(defaultRoute);
        }

        #region Helpers
        /// <summary>
        /// Verify that the provided return URL is valid
        /// </summary>
        /// <param name="returnUrl">URL to check</param>
        /// <returns>Boolean</returns>
        private Boolean IsValidReturnUrl(String returnUrl)
        {
            return Url.IsLocalUrl(returnUrl) &&
                returnUrl.Length > 1 &&
                returnUrl.StartsWith("/") &&
                !returnUrl.StartsWith("//") &&
                !returnUrl.StartsWith("/\\");
        }
        #endregion
    }
}
