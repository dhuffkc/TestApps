namespace Server
{
	using System;
	using System.ServiceModel;

	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Starting...");
			
			using (ServiceHost host = new ServiceHost(typeof(Service)))
			{
				host.Open();

				Console.WriteLine("The service is ready.");
				Console.WriteLine("Press <Enter> to stop the service.");
				Console.ReadLine();

				Console.WriteLine("Stopping...");

				host.Close();
			}
		}
	}
}
