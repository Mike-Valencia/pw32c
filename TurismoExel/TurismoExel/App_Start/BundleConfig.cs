using System.Web;
using System.Web.Optimization;

namespace TurismoExel.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/bundles/css").Include(
                                "~/Content/bootstrap.min.css",
                                "~/Content/bootstrap-theme.min.css",
                                "~/Content/bootstrap-datetimepicker.min.css",
                                "~/Content/style.css"
                            ));

            bundles.Add(new ScriptBundle("~/bundles/scriptsHead").Include(
                            "~/Scripts/bootstrap.min.js",
                            "~/Scripts/bootstrap-datetimepicker.min.js",
                            "~/Scripts/Calendario.js"
                            ));

            bundles.Add(new ScriptBundle("~/bundles/scriptsAjax").Include(
                "~/Scripts/AjaxReserva.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/scriptsFooter").Include(
                "~/Scripts/jquery-3.2.1.min.js",
                "~/Scripts/moment.js",
                "~/Scripts/bootstrap.min.js",
                "~/Scripts/bootstrap-datetimepicker.min.js",
                "~/Scripts/Calendario.js"
                ));
        }
    }
}