namespace ManagedLibrary
{
	using System;

	public class SimpleClass
	{
		public string DoSomething(string data)
		{
			return data + ": " + DateTime.Now.ToLongTimeString();
		}
	}
}
