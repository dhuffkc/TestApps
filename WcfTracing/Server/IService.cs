namespace Server
{
	using System;
	using System.Runtime.Serialization;
	using System.ServiceModel;


	[DataContract]
	public class Info
	{
		public string More { get; set; }
	}

	[ServiceContract]
	public interface IService
	{
		[OperationContract]
		DateTime DoWork(Info dt);
		//string DoWork();
	}
}
