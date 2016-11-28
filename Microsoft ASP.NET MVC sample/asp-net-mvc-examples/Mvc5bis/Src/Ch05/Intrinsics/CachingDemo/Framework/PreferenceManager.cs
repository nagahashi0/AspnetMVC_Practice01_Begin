using System;
using System.Web;

namespace CachingDemo.Framework
{
    public class PreferenceManager
    {
        public static Boolean Load(HttpContextBase context)
        {
            if (context == null)
                throw new ArgumentNullException("context");
            
            // Attempt to read from session
            var color = context.Session[StateEntries.PreferredTextColor] as String;
            if (color != null)
            {
                TextColor = color;
                return true;
            }

            // Attempt to read from the application's cookie
            var cookie = context.Request.Cookies[StateEntries.CookieName];
            if (cookie == null)
                return Initialize(context);

            return InitializeFromCookie(context, cookie);
        }

        public static Boolean Save(HttpContextBase context, String color, Boolean persistent = false)
        {
            if (context == null)
                throw new ArgumentNullException("context");
            TextColor = color;

            context.Session[StateEntries.PreferredTextColor] = TextColor;

            if (persistent)
            {
                var cookie = new HttpCookie(StateEntries.CookieName);
                cookie.Expires = DateTime.Now.AddHours(1);
                cookie["TextColor"] = TextColor;
                context.Response.Cookies.Add(cookie);
            }
            return true;
        }

        protected static Boolean Initialize(HttpContextBase context)
        {
            if (context == null)
                throw new ArgumentNullException("context");

            return Save(context, "#000000");
        }

        protected static Boolean InitializeFromCookie(HttpContextBase context, HttpCookie cookie)
        {
            if (context == null)
                throw new ArgumentNullException("context");

            TextColor = cookie["TextColor"];
            context.Session[StateEntries.PreferredTextColor] = TextColor;
            return true;
        }
        
        public static String TextColor { get; private set; }
    }
}