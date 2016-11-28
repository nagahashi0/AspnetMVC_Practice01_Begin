using System.Web.Mvc;
using System.Web.Routing;

namespace BindingFun.Common
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                "Test",
                "{controller}/{action}/test/{number}",
                new { controller = "Binding", action = "RepeatWithPrecedence", number = 5 }
                );

        }
    }
}