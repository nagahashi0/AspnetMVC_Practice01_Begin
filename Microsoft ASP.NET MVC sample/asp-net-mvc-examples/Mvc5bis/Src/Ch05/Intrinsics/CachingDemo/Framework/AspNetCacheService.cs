using System;
using System.Web;
using System.Web.Caching;

namespace CachingDemo.Framework
{
    /// <summary>
    /// Implement generic caching services for the application using the 
    /// ASP.NET native Cache object.
    /// </summary>
    public class AspNetCacheService : ICacheService
    {
        private readonly Cache _aspnetCache;
        public AspNetCacheService()
        {
            if (HttpContext.Current != null)
                _aspnetCache = HttpContext.Current.Cache;
        }

        public Object Get(String key)
        {
            return _aspnetCache[key];
        }

        public void Set(String key, Object data)
        {
            _aspnetCache[key] = data;
        }

        public Object this[String key]
        {
            get { return _aspnetCache[key]; }
            set { _aspnetCache[key] = value; }
        }
    }
}