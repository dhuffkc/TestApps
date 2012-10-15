namespace Concurrency.StandAlone
{
	class Program
	{
		static void Main(string[] args)
		{
			IItemRepository repository = new ItemRepository();
			var item = repository.GetItem(1);
			item.Value = "one";
			repository.Update(item);
		}
	}
}
