using System.Web.Http;
using Simplest.Services;

namespace Simplest
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new {id = RouteParameter.Optional}
                );

            // Replace the default JsonFormatter with a custom one
            var index = config.Formatters.IndexOf(config.Formatters.JsonFormatter);
            config.Formatters[index] = new JsonCamelCaseFormatter();

            // Insert NewsXmlFormatter before the default XML formatter
            var xmlIndex = config.Formatters.IndexOf(config.Formatters.XmlFormatter);
            config.Formatters.Insert(xmlIndex, new NewsXmlFormatter());
        }
    }
}
