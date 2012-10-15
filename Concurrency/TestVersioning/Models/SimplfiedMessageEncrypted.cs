using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestVersioning.Models
{
	public class SimplifiedMessageEncrypted : SimplifiedMessage
	{
		public string EncryptedVersion { get; set; }
	};
}