
namespace JsonArrayPost.Controllers
{
	using System.Collections.Generic;
	using System.Web.Mvc;
	
	public class Item
	{
		public string Data { get; set; }
	}

	public class PostData
	{
		public IList<string> Test { get; set; }
	}

	public class HomeController : Controller
	{
		[HttpPost]
		public ActionResult PostTest(IList<string> stuff)
		{
			return this.Json("awesome!");
		}

		public ActionResult Index()
		{
			ViewBag.Message = "Welcome to ASP.NET MVC!";

			return View();
		}

		public ActionResult About()
		{
			return View();
		}
	}
}
