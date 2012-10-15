namespace Concurrency.Service
{
	using System.ServiceModel;

	[ServiceContract]
	public interface IItemService
	{
		[OperationContract]
		Item GetData(int id);

		[OperationContract]
		void Update(Item item);
	}
}
