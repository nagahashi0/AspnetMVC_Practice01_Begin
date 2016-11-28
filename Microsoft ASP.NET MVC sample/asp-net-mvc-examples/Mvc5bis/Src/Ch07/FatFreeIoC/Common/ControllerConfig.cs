using System.Web.Mvc;
using BookSamples.Components.Factories;

namespace FatFreeIoC.Common
{
    public class ControllerConfig
    {
        public static void RegisterFactory(ControllerBuilder builder)
        {
            var factory = new UnityControllerFactory();
            builder.SetControllerFactory(factory);
        }
    }
}