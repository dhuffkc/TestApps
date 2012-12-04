
namespace VanillaMvcApplication
{
	using System.Web.Mvc;

	using log4net;

	public class LogErrorAttribute : HandleErrorAttribute
	{
		private static readonly ILog Logger = LogManager.GetLogger(typeof(LogErrorAttribute));

		public override void OnException(ExceptionContext filterContext)
		{
			Logger.Error("Unhandled exception", filterContext.Exception);
			base.OnException(filterContext);
		}
	}
}