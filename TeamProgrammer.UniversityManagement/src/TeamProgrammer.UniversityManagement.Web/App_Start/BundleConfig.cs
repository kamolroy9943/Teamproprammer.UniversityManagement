using System.Web.Optimization;

namespace IdentitySample
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));


            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/scripts/bootstrap.min.js",
                "~/js/jquery.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/datatable").Include(
                     "~/scripts/DataTables/jquery.dataTables.js",
                     "~/scripts/DataTables/dataTables.bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.min.css",
                      "~/Content/Site.css",
                       "~/Content/DataTables/dataTables.bootstrap.css"));
        }
    }
}
