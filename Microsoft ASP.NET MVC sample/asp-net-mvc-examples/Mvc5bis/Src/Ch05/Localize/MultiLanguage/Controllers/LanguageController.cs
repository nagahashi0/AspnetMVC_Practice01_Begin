using System;
using System.Web.Mvc;
using BookSamples.Components.Filters;

namespace MultiLanguage.Controllers
{
    public class LanguageController : Controller
    {
        public void Set(String lang)
        {
            // Set culture to use next | REQUIRES global filter attribute Culture (see Common/filterConfig)
            CultureAttribute.SavePreferredCulture(HttpContext.Response, lang);

            // Return to the calling URL (or go to the site’s home page)
            HttpContext.Response.Redirect(HttpContext.Request.UrlReferrer.AbsolutePath);
        }
    }
}
