using System.Web.Optimization;

namespace MultiView2.Common.Config
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            // Virtual path REQUIRED in the definition of Script/StyleBundle because that would be URL 
            // used in emitted markup.
            bundles.Add(new ScriptBundle("~/all-scripts").Include("~/Content/Scripts/*.js"));
            bundles.Add(new StyleBundle("~/all-styles").Include("~/Content/Styles/*.css"));

            // Unbelievably necessary for testing purposes; when released, it suffices 
            // you drop debug=true in <compilation> and better off commenting this out.
            // EnableOptimizations overrides debug attribute... 
            BundleTable.EnableOptimizations = true;
        }
    }
}