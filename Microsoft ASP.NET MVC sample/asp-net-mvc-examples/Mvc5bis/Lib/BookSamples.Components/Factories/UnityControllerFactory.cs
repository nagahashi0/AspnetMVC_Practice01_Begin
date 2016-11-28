using System;
using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;

namespace BookSamples.Components.Factories
{
    public class UnityControllerFactory : DefaultControllerFactory
    {
        public static IUnityContainer Container { get; private set; }

        public UnityControllerFactory()
        {
            Container = new UnityContainer();
            Container.LoadConfiguration();
        }

        //protected override Type GetControllerType(RequestContext requestContext, String controllerName)
        //{
        //    // Override this method if you just don't like the xxxController pattern
        //    var typeName = String.Format("IoCFatFree.Controllers.{0}Coordinator, IoCFatFree", controllerName);
        //    return Type.GetType(typeName);
        //}

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            if (controllerType == null)
                return null;
            return Container.Resolve(controllerType) as IController;
        }

        public override void ReleaseController(IController controller)
        {
            Container.Teardown(controller);
        }
    }
}