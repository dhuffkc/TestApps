namespace AntiForgery.Controllers
{
	using System.Text;
	using System.Web.Mvc;

	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			ViewBag.Message = "Welcome to ASP.NET MVC!";

			return this.Encrypt("Plain Text");
		}

		public ActionResult Decrypt(string cipherText)
		{
			ViewBag.CipherText = cipherText;

			var cipherBytes = MachineKeySectionWrapper.HexStringToByteArray(cipherText);
			var plainBytes = MachineKeySectionWrapper.Decrypt(cipherBytes);
			this.ViewBag.PlainText = Encoding.UTF8.GetString(plainBytes);

			return this.View("Index");
		}

		public ActionResult Encrypt(string plainText)
		{
			ViewBag.PlainText = plainText;

			var plainBytes = Encoding.UTF8.GetBytes(plainText);
			var cipherBytes = MachineKeySectionWrapper.Encrypt(plainBytes);
			ViewBag.CipherText = MachineKeySectionWrapper.ByteArrayToHexString(cipherBytes);

			return this.View("Index");
		}

		public ActionResult Verify(string versionToken)
		{
			var cipherBytes = MachineKeySectionWrapper.HexStringToByteArray(versionToken);
			var plainBytes = MachineKeySectionWrapper.Decrypt(cipherBytes);
			var plainText = Encoding.UTF8.GetString(plainBytes);

			ViewBag.Version = plainText;

			return this.Encrypt(plainText);
		}

		[HttpPost]
		public ActionResult ReadVersionToken(string versionToken)
		{
			var cipherBytes = MachineKeySectionWrapper.HexStringToByteArray(versionToken);
			var plainBytes = MachineKeySectionWrapper.Decrypt(cipherBytes);
			var version = Encoding.UTF8.GetString(plainBytes);
			return this.Json(new { version = version });
		}

		public ActionResult About()
		{
			return this.View();
		}
	}
}
