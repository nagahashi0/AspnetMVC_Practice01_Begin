using System;
using System.Reflection;
using System.Web.Mvc;

namespace BookSamples.Components.Filters
{
    public class AjaxOnlyAttribute : ActionMethodSelectorAttribute
    {
        public override Boolean IsValidForRequest(ControllerContext controllerContext, MethodInfo methodInfo)
        {
            return controllerContext.HttpContext.Request.IsAjaxRequest();
        }
    }
}