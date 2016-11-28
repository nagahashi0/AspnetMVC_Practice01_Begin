using System;
using System.Web.Mvc;
using System.Web.Routing;
using CachingDemo.Common;
using CachingDemo.Framework;

namespace CachingDemo
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            // Inject a global caching service
            RegisterCacheService(new AspNetCacheService());

            // Store app-wide data
            CacheService["StartTime"] = DateTime.Now;
        }

        #region Cache injection
        private static ICacheService _internalCacheObject;
        public void RegisterCacheService(ICacheService cacheService)
        {
            _internalCacheObject = cacheService;
        }

        public static ICacheService CacheService
        {
            get { return _internalCacheObject;  }
        }
        #endregion
    }
}