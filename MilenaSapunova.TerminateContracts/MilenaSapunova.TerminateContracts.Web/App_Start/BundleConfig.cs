using System.Web.Optimization;

namespace MilenaSapunova.TerminateContracts.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            // Jquery validator & unobstrusive ajax  
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/Scripts/jquery.unobtrusive-ajax.js",
                "~/Scripts/jquery.unobtrusive-ajax.min.js",
                "~/Scripts/jquery.validate*",
                "~/Scripts/jquery.validate.unobtrusive.js",
                "~/Scripts/jquery.validate.unobtrusive.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/main/popper.min.js",
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/main").Include(
                        "~/Scripts/main/main.js"));

            bundles.Add(new ScriptBundle("~/bundles/datatable").Include(
                     "~/Scripts/gijgo/combined/gijgo.js",
                     "~/Scripts/datatable/table.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/main/fonts.css",
                      "~/Content/main/font-awesome.min.css",
                      "~/Content/main/main.css"));

            bundles.Add(new StyleBundle("~/Content/datatable").Include(
                           "~/Content/datatable/table.css",
                           "~/Content/gijgo/combined/gijgo.min.css"));

            bundles.Add(new StyleBundle("~/Content/document").Include(
                    "~/Content/document/main.css"));

        }
        //BundleTable.EnableOptimizations = true;
    }
}
