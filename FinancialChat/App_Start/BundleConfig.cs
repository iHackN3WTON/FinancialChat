using System.Web;
using System.Web.Optimization;

namespace FinancialChat
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include("~/Scripts/jquery-{version}.js"));
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include("~/Scripts/jquery.validate*"));
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include("~/Scripts/modernizr-*"));
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include("~/Scripts/bootstrap.js", "~/Scripts/bootbox.js"));
            bundles.Add(new ScriptBundle("~/bundles/chatangular").Include("~/Scripts/chatAngular/runtime*", "~/Scripts/chatAngular/polyfills*","~/Scripts/chatAngular/main*"));
            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/bootstrap.css", "~/Content/site.css"));
        }
    }
}
