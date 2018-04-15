using System.Web;
using System.Web.Optimization;

namespace uksl
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery-ui.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/tournamentDrawer").Include(
                        "~/script/TournamentDrawer/lib/createjs.min.js",
                        "~/script/TournamentDrawer/lib/easeljs-{version}.min.js",
                        "~/script/TournamentDrawer/scripts/match.js",
                        "~/script/TournamentDrawer/scripts/round.js",
                        "~/script/TournamentDrawer/scripts/drawer.js",
                        "~/script/tournaments.js"));

            bundles.Add(new ScriptBundle("~/bundles/fa").Include(
                        "~/Content/fa/js/fontawesome-all.min.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/jquery-ui*"));
        }
    }
}
