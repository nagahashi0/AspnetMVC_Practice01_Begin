using System.Web.Mvc;
using BookSamples.Components.Filters;

namespace MultiLanguage.Common
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new CultureAttribute());
        }
    }
}