using System.Web.Optimization;

namespace WeddingInvite.Web
{
	public class BundleConfig
	{
		// For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
		public static void RegisterBundles(BundleCollection bundles)
		{
			BundleTable.EnableOptimizations = true;
			bundles.UseCdn = true;

			var bulmaCdnPath = "https://cdnjs.cloudflare.com/ajax/libs/bulma/0.7.2/css/bulma.min.css";
			var font_awesomeCdnPath = "https://use.fontawesome.com/releases/v5.6.3/css/all.css";

			bundles.Add(new StyleBundle("~/bundles/bulma", bulmaCdnPath).IncludeFallback("~/Content/lib/bulma/css/bulma.min.css", "navbar.is-success", "background-color", "#23d160"));
			bundles.Add(new StyleBundle("~/bundles/font-awesome", font_awesomeCdnPath).IncludeFallback("~/Content/lib/font-awesome/css/all.min.css", "fa-inverse", "color", "#fff"));
			bundles.Add(new StyleBundle("~/bundles/css").Include("~/Content/css/main.css"));
			bundles.Add(new ScriptBundle("~/bundles/scripts").Include("~/Content/js/main.js", "~/Content/js/gmaps.js"));
		}
	}
}
