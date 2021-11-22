using System.Web;
using System.Web.Optimization;

namespace studentmanager
{
    public class BundleConfig
    {
        // Pour plus d’informations sur le Bundling, accédez à l’adresse http://go.microsoft.com/fwlink/?LinkId=254725 (en anglais)
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            // Utilisez la version de développement de Modernizr pour développer et apprendre. Puis, lorsque vous êtes
            // prêt pour la production, utilisez l’outil de génération sur http://modernizr.com pour sélectionner uniquement les tests dont vous avez besoin.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                        "~/Content/themes/base/jquery.ui.core.css"));

            bundles.Add(new StyleBundle("~/Assets/css").Include(
                                        "~/Assets/css/stylemin.css",
                                        "~/Assets/css/404.css"));
            bundles.Add(new ScriptBundle("~/Assets/js").Include(
                                    "~/Assets/plugins/chart.min.js",
                                    "~/Assets/plugins/feather.min.js",
                                    "~/Assets/js/script.js"
                                    ));
        }
    }
}