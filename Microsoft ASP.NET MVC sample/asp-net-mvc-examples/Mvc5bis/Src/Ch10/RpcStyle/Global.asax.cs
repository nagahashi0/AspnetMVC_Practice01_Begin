using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using RpcStyle.Common;

namespace RpcStyle
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            ApiConfig.Setup(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}