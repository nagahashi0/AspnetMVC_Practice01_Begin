using System;

namespace CachingDemo.Framework
{
    public interface ICacheService 
    {
        Object Get(String key);
        void Set(String key, Object data);
        Object this[String key] { get; set; }
    }
}