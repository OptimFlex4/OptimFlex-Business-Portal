using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.UI;

namespace OptimflexPortal
{
    public class BundleConfig
    {
        // For more information on Bundling, visit https://go.microsoft.com/fwlink/?LinkID=303951
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/scripts").Include(
                "~/js/plugin/devexpress/jquery.min.js",
                "~/js/plugin/devexpress/jquery.mCustomScrollbar.concat.min.js",
                "~/js/plugin/devexpress/jquery.qrcode.min.js",
                "~/js/plugin/devexpress/URI.js",
                "~/js/plugin/devexpress/highlight.pack.js",
                "~/js/plugin/devexpress/clipboard.min.js",
                "~/js/plugin/devexpress/popper.min.js",
                "~/js/plugin/devexpress/bootstrap.min.js",
                "~/js/plugin/devexpress/codemirror.js",
                "~/js/plugin/devexpress/javascript.js",
                "~/js/plugin/devexpress/placeholder.js",
                "~/js/plugin/devexpress/common.js",
                "~/js/plugin/devexpress/search.js",
                "~/js/plugin/devexpress/pages.js"
            ));
            bundles.Add(new StyleBundle("~/bundles/styles").Include(
                "~/css/devexpress/demo-icons.css",
                "~/css/devexpress/jquery.mCustomScrollbar.min.css",
                "~/css/devexpress/font-awesome.min.css",
                "~/css/devexpress/highlightjs.default.css",
                "~/css/devexpress/codemirror.css",
                "~/css/devexpress/lint.css",
                "~/css/devexpress/common.css",
                "~/css/devexpress/themes.css",
                "~/css/devexpress/pages.css",
                "~/css/devexpress/controls.css",
                "~/css/devexpress/iframe-viewer.css",
                "~/css/devexpress/demos.css",
                "~/css/Site.css"
            ));
            // Use the Development version of Modernizr to develop with and learn from. Then, when you’re
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                            "~/js/modernizr-*"));
        }
    }
}