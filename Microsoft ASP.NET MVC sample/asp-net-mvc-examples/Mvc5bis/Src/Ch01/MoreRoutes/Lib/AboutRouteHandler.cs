using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MoreRoutes.Lib
{
    public class AboutRouteHandler : IRouteHandler
    {
        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            // Analyzes the actual URL being mapped to the route. If so,
            // programmatically determines controller/action
            if (requestContext.HttpContext.Request.Url.AbsolutePath == "/aboutme")
            {
                requestContext.RouteData.Values["controller"] = "home";
                requestContext.RouteData.Values["action"] = "about";
            }
            return new MvcHandler(requestContext);
        }
    }
}