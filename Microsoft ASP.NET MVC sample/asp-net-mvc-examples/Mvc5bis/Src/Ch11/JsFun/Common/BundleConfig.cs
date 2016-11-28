using System.Web.Optimization;

namespace JsFun.Common
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            // Register bundles first
            bundles.Add(new Bundle("~/mycss").Include(
                   "~/content/styles/site.css",
                   "~/content/styles/sprite.css"));

            BundleTable.EnableOptimizations = true;
        }
    }
}