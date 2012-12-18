namespace Client
{
	using System;

	class Program
	{
		static void Main(string[] args)
		{
			while (true)
			{
				Console.Out.WriteLine("1 - Make reqest.\nAnything else - Quit.");
				var keyInfo = Console.ReadKey(true);
				
				if (keyInfo.KeyChar != '1')
				{
					return;
				}

				Console.Out.WriteLine("Requesting...");

				using (var client = new OriginalService.ServiceClient())
				{
					var response = client.DoWork(99);
					Console.Out.WriteLine("Received response: " + response);

					client.Close();
				}
			}
		}
	}
}
