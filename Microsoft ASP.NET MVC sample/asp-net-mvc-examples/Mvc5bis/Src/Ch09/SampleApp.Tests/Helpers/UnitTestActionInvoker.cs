using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web.Mvc;

namespace SampleApp.Tests.Framework
{
    public class UnitTestActionInvoker : ControllerActionInvoker
    {
        public override bool InvokeAction(ControllerContext controllerContext, string actionName)
        {
            if (controllerContext == null)
            {
                throw new ArgumentNullException("controllerContext");
            }
            if (string.IsNullOrEmpty(actionName))
            {
                throw new ArgumentException("actionName");
            }
            var controllerDescriptor = GetControllerDescriptor(controllerContext);
            var actionDescriptor = FindAction(controllerContext, controllerDescriptor, actionName);
            if (actionDescriptor == null)
            {
                return false;
            }
            var filters = GetFilters(controllerContext, actionDescriptor);
            try
            {
                var context = InvokeAuthorizationFilters(controllerContext, filters.AuthorizationFilters, actionDescriptor);
                if (context.Result != null)
                {
                    InvokeActionResult(controllerContext, context.Result);
                }
                else
                {
                    if (controllerContext.Controller.ValidateRequest)
                    {
                        //ValidateRequest(controllerContext);
                    }
                    var parameterValues = GetParameterValues(controllerContext, actionDescriptor);
                    var context2 = InvokeActionMethodWithFilters(controllerContext, filters.ActionFilters, actionDescriptor, parameterValues);
                    InvokeActionResultWithFilters(controllerContext, filters.ResultFilters, context2.Result);
                }
            }
            catch (ThreadAbortException)
            {
                throw;
            }
            catch (Exception exception)
            {
                var context3 = InvokeExceptionFilters(controllerContext, filters.ExceptionFilters, exception);
                if (!context3.ExceptionHandled)
                {
                    throw;
                }
                InvokeActionResult(controllerContext, context3.Result);
            }
            return true;
        }

        protected override ResultExecutedContext InvokeActionResultWithFilters(ControllerContext controllerContext, IList<IResultFilter> filters, ActionResult actionResult)
        {
            var preContext = new ResultExecutingContext(controllerContext, actionResult);
            Func<ResultExecutedContext> seed = delegate
            {
                //this.InvokeActionResult(controllerContext, actionResult);
                return new ResultExecutedContext(controllerContext, actionResult, false, null);
            };
            return filters.Reverse().Aggregate(seed, (next, filter) => () => InvokeActionResultFilter(filter, preContext, next))();
        }


        internal static ResultExecutedContext InvokeActionResultFilter(IResultFilter filter, ResultExecutingContext preContext, Func<ResultExecutedContext> continuation)
        {
            filter.OnResultExecuting(preContext);
            if (preContext.Cancel)
            {
                return new ResultExecutedContext(preContext, preContext.Result, true, null);
            }
            bool flag = false;
            ResultExecutedContext filterContext = null;
            try
            {
                filterContext = continuation();
            }
            catch (ThreadAbortException)
            {
                filterContext = new ResultExecutedContext(preContext, preContext.Result, false, null);
                filter.OnResultExecuted(filterContext);
                throw;
            }
            catch (Exception exception)
            {
                flag = true;
                filterContext = new ResultExecutedContext(preContext, preContext.Result, false, exception);
                filter.OnResultExecuted(filterContext);
                if (!filterContext.ExceptionHandled)
                {
                    throw;
                }
            }
            if (!flag)
            {
                filter.OnResultExecuted(filterContext);
            }
            return filterContext;
        }



 

    }
}