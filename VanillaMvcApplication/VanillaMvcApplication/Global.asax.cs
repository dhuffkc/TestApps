
namespace VanillaMvcApplication
{
	using System;
	using System.Web;
	using System.Web.Mvc;
	using System.Web.Routing;
	using log4net;

	// Note: For instructions on enabling IIS6 or IIS7 classic mode, 
	// visit http://go.microsoft.com/?LinkId=9394801

	public class MvcApplication : System.Web.HttpApplication
	{
		private static readonly ILog Logger = LogManager.GetLogger(typeof(MvcApplication));

		public static void RegisterGlobalFilters(GlobalFilterCollection filters)
		{
			filters.Add(new LogErrorAttribute());
		}

		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			routes.MapRoute(
				"Default", // Route name
				"{controller}/{action}/{id}", // URL with parameters
				new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
			);

		}

		protected void Application_Start()
		{
			Logger.Debug("Application Start");

			AreaRegistration.RegisterAllAreas();

			RegisterGlobalFilters(GlobalFilters.Filters);
			RegisterRoutes(RouteTable.Routes);
		}

		protected void Application_Error(object sender, EventArgs e)
		{
			var message = new
				{
					Location = "Application_Error",
					HttpContext = HttpContext.Current
				};

			var exception = Server.GetLastError();

			Logger.Error(message, exception);
		}
	}
}