using System;
using System.Web.Mvc;
using System.Web.Security;
using AnyProvider.Framework;
using AnyProvider.ViewModels.Auth;
using DotNetOpenAuth.Messaging;
using DotNetOpenAuth.OpenId.RelyingParty;

namespace AnyProvider.Controllers
{
    public class AuthController : OpenIdController
    {

        /// <summary>
        /// Displays the login view
        /// </summary>
        /// <returns>HTML view</returns>
        [HttpGet]
        public ActionResult LogOn()
        {
            return View();
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
        public ActionResult LogOn(LogOnViewModel model, String returnUrl, String defaultAction = "Index", String defaultController = "Home")
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
                else
                {
                    return RedirectToAction(defaultAction, defaultController);
                }
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
        public ActionResult LogOff(String defaultAction = "Index", String defaultController = "Home")
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

        /// <summary>
        /// Relies on Twitter to authenticate users.
        /// </summary>
        /// <returns>Redirect</returns>
        public ActionResult Authenticate(String returnUrl, [Bind(Prefix = "openid_identifier")]String url)
        {
            var isValidReturnUrl = IsValidReturnUrl(returnUrl);

            // First step: issuing the request and returning here  
            var response = RelyingParty.GetResponse();
            if (response == null)
            {
                if (!RelyingParty.IsValid(url))
                    return View("LogOn");

                try
                {
                    return RelyingParty.CreateRequest(url).RedirectingResponse.AsActionResult();
                }
                catch (ProtocolException ex)
                {
                    ModelState.AddModelError("openid_identifier", ex.Message);
                    return View("LogOn");
                }
            }

            // Second step: redirected here by the provider
            switch (response.Status)
            {
                case AuthenticationStatus.Authenticated:
                    var cookie = response.CreateAuthCookie(true, StopAtFirstToken);
                    Response.Cookies.Add(cookie);  // This is necessary because we're recreating the cookie
                    if (isValidReturnUrl)
                        return Redirect(returnUrl);
                    return RedirectToAction("Index", "Home");
                case AuthenticationStatus.Canceled:
                    ViewData["Message"] = "Canceled at provider";
                    return View("LogOn");
                case AuthenticationStatus.Failed:
                    ViewData["Message"] = response.Exception.Message;
                    return View("LogOn");
            }

            return new EmptyResult();
        }

        public String StopAtFirstToken(String name)
        {
            var tokens = name.Split('.');
            return tokens[0];
            //return name;
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
