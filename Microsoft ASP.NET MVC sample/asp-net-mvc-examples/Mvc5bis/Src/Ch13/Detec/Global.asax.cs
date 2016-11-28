using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using WURFL;
using WURFL.Aspnet.Extensions.Config;

namespace Detec
{
    public class MyApp : HttpApplication
    {
        public static IWURFLManager WurflContainer;

        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        public static void RegisterWurfl()
        {
            WurflContainer = WURFLManagerBuilder.Build(new ApplicationConfigurer());
        }

        protected void Application_Start()
        {
            RegisterWurfl();
            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }
    }
}