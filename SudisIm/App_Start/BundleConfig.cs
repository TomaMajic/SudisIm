using System.Web;
using System.Web.Optimization;

namespace SudisIm
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            #region Plugins
            #region DataTable
            bundles.Add(new StyleBundle("~/bundles/css/datatables").Include(
                "~/Plugins/DataTables/css/dataTables.bootstrap.min.css"));

            bundles.Add(new ScriptBundle("~/bundles/js/datatables").Include(
                "~/Plugins/DataTables/js/jquery.dataTables.min.js",
                "~/Plugins/DataTables/js/dataTables.bootstrap.min.js"));

            #endregion /DataTable

            #endregion /Plugins
        }
    }
}
