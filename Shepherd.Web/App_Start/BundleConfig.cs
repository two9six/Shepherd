using System.Web;
using System.Web.Optimization;

namespace Shepherd.Web
{
	public class BundleConfig
	{
		// For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
		public static void RegisterBundles(BundleCollection bundles)
		{
			bundles.Add(new StyleBundle("~/css").Include(
				"~/content/bootstrap.min.css",
				"~/content/style.css",				
				"~/content/font-awesome/css/font-awesome.css",
				"~/content/data-grid.css",
				"~/content/site.css",
				"~/content/adapt-strap.css",
				"~/content/custom.css"
			));

			bundles.Add(new ScriptBundle("~/js").Include(
				"~/scripts/jquery-2.1.4.min.js",
				"~/scripts/jquery.validate*",
				"~/scripts/modernizr-*",
				"~/scripts/bootstrap.js",
				"~/scripts/respond.js",
                "~/scripts/angular.min.js",
                "~/scripts/angular-animate.min.js",
                "~/scripts/angular-route.min.js",
                "~/scripts/angular-resource.min.js",
				"~/scripts/angular-sanitize.min.js",
                "~/scripts/angular-ui/ui-bootstrap-tpls.js",
				"~/scripts/angular-ui-router.min.js",
				"~/scripts/lodash.min.js",
				"~/scripts/metisMenu/jquery.metisMenu.js",
				"~/app/enums/*.js",
				"~/app/app.js",
				"~/app/controllers/*.js",
				"~/app/controls/*.js",
				"~/app/controls/adapt-strap/*.js",
				"~/app/directives/*.js",				
				"~/app/helpers/*.js",
				"~/app/modals/*.js",
				"~/app/models/*.js",
				"~/app/parsers/*.js",
				"~/app/services/*.js"
			));

			BundleTable.EnableOptimizations = false;
		}
	}
}