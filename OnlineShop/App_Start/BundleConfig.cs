
using System.Web;
using System.Web.Optimization;

namespace OnlineShop.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/js").Include(
                        "~/Design/client/js/jquery-ui.js",
                        "~/Design/client/js/bootstrap.js",
                        "~/Design/client/js/bootstrap.min.js",
                        "~/Design/client/js/slides.min.jquery.js",
                        "~/Design/client/js/move-top.js",
                        "~/Design/client/js/easing.js",
                        "~/Design/client/js/startstop-slider.js",
                        "~/Design/client/js/easyResponsiveTabs.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/footerjs").Include(
                        "~/Design/client/js/controller/base.js"
                        ));

            bundles.Add(new StyleBundle("~/bundles/css").Include(
                      "~/Design/client/css/style.css",
                      "~/Design/client/css/slider.css",
                      "~/Design/client/css/easy-responsive-tabs.css",
                      "~/Design/client/css/global.css",
                      "~/Design/PagedList.css",
                      "~/Design/admin/vendor/fontawesome-free/css/all.min.css",
                      "~/Design/client/css/bootstrap.min.css",
                      "~/Design/client/css/bootstrap-social.css",
                      "~/Design/client/css/jquery-ui.css"));

            BundleTable.EnableOptimizations = true;
            
        }
    }
}