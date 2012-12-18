namespace DateTimeTests
{
	using System;
	using System.Diagnostics;

	class Program
	{
		static void Main(string[] args)
		{
			var d = new DateTime(1970, 1, 1);

			var unspecified = new DateTime(d.Ticks, DateTimeKind.Unspecified);
			var local = new DateTime(d.Ticks, DateTimeKind.Local);
			var localInUtc = DateTime.SpecifyKind(local, DateTimeKind.Utc);

			var utc = new DateTime(d.Ticks, DateTimeKind.Utc);

			Debug.WriteLine("un as local: " + unspecified.ToLocalTime().ToLongTimeString());
			Debug.WriteLine("lo as local: " + local.ToLocalTime().ToLongTimeString());
			Debug.WriteLine("ut as local: " + utc.ToLocalTime().ToLongTimeString());

			Debug.WriteLine("un as utc: " + unspecified.ToUniversalTime().ToLongTimeString());
			Debug.WriteLine("lo as utc: " + local.ToUniversalTime().ToLongTimeString());
			Debug.WriteLine("ut as utc: " + utc.ToUniversalTime().ToLongTimeString());

			TimeSpan ts = unspecified.Subtract(local);
			ts = unspecified.Subtract(utc);
			ts = local.Subtract(utc);

			local = DateTime.SpecifyKind(d, DateTimeKind.Local);
			utc = DateTime.SpecifyKind(d, DateTimeKind.Utc);

			var unspecifiedTicks = unspecified.Ticks;
			var localTicks = local.Ticks;
			var utcTicks = utc.Ticks;
		}
	}
}
