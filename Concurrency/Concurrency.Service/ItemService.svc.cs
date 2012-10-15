
namespace Concurrency.Service
{
	public class ItemService : IItemService
	{
		public Item GetData(int id)
		{
			IItemRepository repository = new ItemRepository();
			var result = repository.GetItem(id);
			return result;
		}

		public void Update(Item item)
		{
			IItemRepository repository = new ItemRepository();
			repository.Update(item);
		}
	}
}
