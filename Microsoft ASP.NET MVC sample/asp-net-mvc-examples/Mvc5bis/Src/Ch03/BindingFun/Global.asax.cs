using System;
using System.Web.Mvc;
using System.Web.Routing;
using BindingFun.Common;
using BookSamples.Components.Binders;

namespace BindingFun
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            // Not invoked if another binder for the same type is defined on the method.
            ModelBinders.Binders[typeof(DateTime)] = new DateModelBinder();
        }
    }
}