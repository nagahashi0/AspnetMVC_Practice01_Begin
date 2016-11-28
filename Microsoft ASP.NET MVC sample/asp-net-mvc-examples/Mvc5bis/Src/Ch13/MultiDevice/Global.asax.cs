using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.WebPages;
using MultiView2.Common.Config;

namespace MultiView2
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // Initialize WURFL
            WurflConfig.Initialize();

            // Added to make the site device-aware. (Disable this to get back to default behavior.)
            DisplayConfig.RegisterDisplayModes(DisplayModeProvider.Instance.Modes);
        }
    }
}