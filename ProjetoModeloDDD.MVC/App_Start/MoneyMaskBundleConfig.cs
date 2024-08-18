using System.Web.Optimization;

[assembly: WebActivatorEx.PostApplicationStartMethod(typeof(ProjetoModeloDDD.MVC.App_Start.MoneyMaskBundleConfig), "RegisterBundles")]

namespace ProjetoModeloDDD.MVC.App_Start
{
	public class MoneyMaskBundleConfig
	{
		public static void RegisterBundles()
		{
			BundleTable.Bundles.Add(new ScriptBundle("~/bundles/moneymask").Include("~/Scripts/jquery.moneymask.js"));
		}
	}
}