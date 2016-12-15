using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Practice01_Begin
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            
            //Greetingルート
            routes.MapRoute(
                name: "Greeting",
                url: "Greeting/Show",
                defaults: new { controller = "Hello", action = "ShowHelloMessage" }
            );

            //HtmlHelperルート
            routes.MapRoute(
                name: "HtmlHelper",
                url: "helper/{controller}/{action}/{id}",
                defaults: new { controller = "HtmlHelper", action = "Index2", id = UrlParameter.Optional }
            );

            //HtmlHelperルート
            routes.MapRoute(
                name: "HtmlHelperSample",
                url: "helper/sample/{controller}/{action}/{id}",
                defaults: new { controller = "HtmlHelperSample", action = "Edit", id = UrlParameter.Optional }
            );
            //デフォルトルート
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

        }
    }
}
