﻿using System.Web;
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