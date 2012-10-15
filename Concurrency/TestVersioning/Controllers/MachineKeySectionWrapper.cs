namespace TestVersioning.Controllers
{
	using System;
	using System.Reflection;
	using System.Web.Configuration;

	public static class MachineKeySectionWrapper
	{
		private static readonly MethodInfo ByteArrayToHexStringMethod;
		private static readonly MethodInfo EncryptOrDecryptDataMethod;
		private static readonly MethodInfo HexStringToByteArrayMethod;

		static MachineKeySectionWrapper()
		{
			var machineKeyType = typeof(MachineKeySection);

			const BindingFlags NonPublicAndStatic = BindingFlags.NonPublic | BindingFlags.Static;

			var typeArray = new[]
				{
					typeof(bool),
					typeof(byte[]),
					typeof(byte[]),
					typeof(int),
					typeof(int)
				};

			EncryptOrDecryptDataMethod = machineKeyType.GetMethod("EncryptOrDecryptData", NonPublicAndStatic, null, typeArray, null);
			HexStringToByteArrayMethod = machineKeyType.GetMethod("HexStringToByteArray", NonPublicAndStatic);
			ByteArrayToHexStringMethod = machineKeyType.GetMethod("ByteArrayToHexString", NonPublicAndStatic);

			if (EncryptOrDecryptDataMethod == null || HexStringToByteArrayMethod == null || ByteArrayToHexStringMethod == null)
			{
				throw new InvalidOperationException("Unable to get the methods to invoke.");
			}
		}

		public static string ByteArrayToHexString(byte[] array)
		{
			return (string)ByteArrayToHexStringMethod.Invoke(null, new object[] { array, array.Length });
		}

		public static byte[] Decrypt(byte[] cipherBytes)
		{
			return EncryptOrDecryptData(false, cipherBytes, null, 0, cipherBytes.Length);
		}

		public static byte[] Encrypt(byte[] plainBytes)
		{
			return EncryptOrDecryptData(true, plainBytes, null, 0, plainBytes.Length);
		}

		public static byte[] EncryptOrDecryptData(bool encrypting, byte[] data, byte[] mod, int index, int length)
		{
			return (byte[])EncryptOrDecryptDataMethod.Invoke(null, new object[] { encrypting, data, mod, index, length });
		}

		public static byte[] HexStringToByteArray(string str)
		{
			return (byte[])HexStringToByteArrayMethod.Invoke(null, new object[] { str });
		}
	}
}