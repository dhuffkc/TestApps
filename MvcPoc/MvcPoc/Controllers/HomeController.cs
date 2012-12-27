using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcPoc.Controllers
{
	public class HomeController : Controller
	{
		public const string Controller = "Home";
		public const string JeffTimeAction = "JeffTime";

		public ActionResult Index()
		{
			ViewBag.Message = "Welcome to ASP.NET MVC!";

			ViewBag.JeffsData = DateTime.Now;

			return View();
		}

		public ActionResult JeffTime(int vacationHours)
		{
			return View("JeffTimeTyped", DateTime.Now.AddHours(vacationHours));
		}

		public ActionResult About()
		{
			return View();
		}
	}
}
