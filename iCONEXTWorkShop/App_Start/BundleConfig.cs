using System.Web;
using System.Web.Optimization;

namespace iCONEXTWorkShop
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*",
                        "~/Scripts/jquery.unobtrusive-ajax.min.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/jquery.bxslider.css"
                      ));

            bundles.Add(new ScriptBundle("~/bundles/bxslider").Include(
                       "~/Scripts/jquery.bxslider.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/pagination").Include(
                       "~/Scripts/jquery.twbsPagination.js"));

            bundles.Add(new StyleBundle("~/AwesomeFont").Include(
                      "~/Content/font-awesome.min.css"
                      ));

            bundles.Add(new StyleBundle("~/content/DataTable").Include(
                "~/Content/DataTable/jquery.dataTables.css"));

            bundles.Add(new ScriptBundle("~/bundles/DataTable").Include(
                "~/Scripts/DataTable/jquery.dataTables.js"));
            bundles.Add(new ScriptBundle("~/bundles/pace").Include(
                      "~/Scripts/pace.min.js"
                      ));

            bundles.Add(new ScriptBundle("~/bundles/pnotify").Include(
                      "~/Scripts/pnotify.custom.min.js"
                      ));

            bundles.Add(new StyleBundle("~/Content/pnotify").Include(
                      "~/Content/pnotify.custom.min.css"
                      ));
        }
    }
}
