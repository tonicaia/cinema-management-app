using System.Web;
using System.Web.Optimization;

namespace CineM8
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));
           

            bundles.Add(new ScriptBundle("~/bundles/bootstrap-table").Include(
                      "~/lib/bootstrap-table/bootstrap-table.js",
                      "~/lib/bootstrap-table/bootstrap-table.min.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/bundles/bootstrap-table").Include(
                     "~/lib/bootstrap-table/bootstrap-table.css",
                      "~/lib/bootstrap-table/bootstrap-table.min.css"));

            bundles.Add(new StyleBundle("~/bundles/twitter-bootstrap").Include(
                     "~/lib/twitter-bootstrap/css"));
        }
    }
}
