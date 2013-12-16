using System.Web;
using System.Web.Optimization;

namespace Jobney.EF.Learning
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/js-base").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/bootstrap.js",
                        "~/Scripts/lodash.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/ng-base").Include(
                        "~/Scripts/angular.js",
                        "~/Scripts/AngularUI/ui-router.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/ng-services")
                .Include("~/Scripts/App/Shared/Services/_module.js")
                .IncludeDirectory("~/Scripts/App/Shared/Services", "*.js"));

            bundles.Add(new ScriptBundle("~/bundles/ng-App1")
                .Include(
                    "~/Scripts/App/App1/_module.js",
                    "~/Scripts/App/App1/routes.js"
                )
                .IncludeDirectory("~/Scripts/App/App1", "*.js", true));
            
            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/app.css",
                "~/Content/bootstrap.css",
                "~/Content/font-awesome.css"
                ));
        }
    }
}