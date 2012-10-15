namespace Concurrency
{
	public interface IItemRepository
	{
		Item GetItem(int id);
		void Update(Item item);
	}
}
