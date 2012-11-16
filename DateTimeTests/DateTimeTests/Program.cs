namespace DateTimeTests
{
	using System;

	class Program
	{
		static void Main(string[] args)
		{
			var d = new DateTime(1970, 1, 1);

			var unspecified = new DateTime(d.Ticks, DateTimeKind.Unspecified);
			var local = new DateTime(d.Ticks, DateTimeKind.Local);
			var utc = new DateTime(d.Ticks, DateTimeKind.Utc);
		}
	}
}
