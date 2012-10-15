using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestVersioning.Models
{
	public static class Extensions
	{
		public static string GetVersionString(this SimplifiedMessage message, byte[] version)
		{
			string versionStr = "";

			foreach(var by in version)
			{
				string byteDisplay = string.Format("[{0}] ", by);
				versionStr += byteDisplay;
			}

			return versionStr;
		}
	}
}