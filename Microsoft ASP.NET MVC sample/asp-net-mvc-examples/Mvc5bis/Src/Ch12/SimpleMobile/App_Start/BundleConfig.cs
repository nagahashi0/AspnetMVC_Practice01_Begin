using System.Web;
using System.Web.Optimization;

namespace SimpleMobile
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/content/script").Include("~/content/scripts/*.js"));
            bundles.Add(new StyleBundle("~/content/css").Include("~/content/styles/*.css"));
        }
    }
}