using System;
using System.Reflection;
using System.Web.Mvc;

namespace FillModel.Filters
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class ViewModelFillerAttribute : ActionFilterAttribute
    {
        public Type Type { get; set; }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var model = filterContext.Controller.ViewData.Model;
            InvokeFiller(Type, model);
        }

        private static void InvokeFiller(Type fillerType, Object model)
        {
            var instance = Activator.CreateInstance(fillerType);

            // Prepare for invoking via reflection
            var fill = GetFillMethodInfo(instance);
            if (fill == null)
                return;

            fill.Invoke(instance, new[] { model });
        }

        private static MethodInfo GetFillMethodInfo(Object instance)
        {
            // Check the instance implements IModelFiller<T> and return information for method Fill
            const String methodFill = "Fill";
            var instanceType = instance.GetType();
            var interfaceName = typeof (IViewModelFiller<>).FullName;
            var interfaceType = instanceType.GetInterface(interfaceName);
            return interfaceType == null ? null : interfaceType.GetMethod(methodFill);
        }
    }
}