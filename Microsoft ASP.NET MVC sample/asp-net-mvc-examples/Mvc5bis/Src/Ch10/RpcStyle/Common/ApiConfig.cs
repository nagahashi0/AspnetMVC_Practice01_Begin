using System.Web.Http;
using RpcStyle.API.Formatters;

namespace RpcStyle.Common
{
    public class ApiConfig
    {
        public static void Setup(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "Rpc with extension",
                routeTemplate: "api/{controller}/{action}.{ext}/{id}",
                defaults: new { id = RouteParameter.Optional }
                ); 

            config.Routes.MapHttpRoute(
                name: "Rpc",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
                );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
                );

            var index = config.Formatters.IndexOf(config.Formatters.XmlFormatter);
            config.Formatters[index] = new ExtendedXmlFormatter();
        }
    }
}