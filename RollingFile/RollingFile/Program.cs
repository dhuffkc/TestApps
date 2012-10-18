namespace RollingFile
{
	using System;
	using System.Threading;

	using log4net;

	class Program
	{
		private static readonly ILog Logger = LogManager.GetLogger(typeof(Program));
		
		static void Main(string[] args)
		{
			Logger.Info("Starting...");

			while (true)
			{
				Logger.Debug("Jowl doner swine, ball tip short loin pork chuck frankfurter jerky beef ribs sirloin rump beef. Kielbasa pork spare ribs ham hock turducken tri-tip leberkas. Pastrami flank short loin spare ribs tail. Chicken venison pig leberkas. Chuck fatback short ribs, pork belly shoulder tail sausage salami short loin doner. at: " + DateTime.Now.ToLongTimeString());
				Thread.Sleep(5);
			}
		}
	}
}
