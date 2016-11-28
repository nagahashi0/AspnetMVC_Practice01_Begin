using System.Web.Mvc;
using System.Web.Routing;
using MoreRoutes.Lib;

namespace MoreRoutes.Common
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // Add a route based on a custom handler (specify controller/action as optional)
            var optionals = new RouteValueDictionary { { "controller", UrlParameter.Optional }, { "action", UrlParameter.Optional } };

            // Nicely enough, if you set optionals to null then you break the markup returned by ActionLink. 
            // You should be using RouteLink to keep things working as expected.
            routes.Add("AboutRoute",
                       new Route("aboutme",
                                 optionals,
                                 new AboutRouteHandler()));

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}