namespace Server
{
	using System;

	public class Service : IService
	{
		public DateTime DoWork(Info dt)
			//public string DoWork()
		//public DateTime DoWork()
		{
			throw new InvalidOperationException("Bad mojo!!");
			//var response = "Working: " + DateTime.Now.ToLongTimeString();
			//Console.Out.WriteLine("Received request: " + response);
			return DateTime.Now;
		}
	}
}
