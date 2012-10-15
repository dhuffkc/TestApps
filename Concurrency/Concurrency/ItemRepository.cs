namespace Concurrency
{
	using System.Data;
	using System.Data.Entity.Infrastructure;
	using System.Linq;

	public class ItemRepository : IItemRepository
	{
		public Item GetItem(int id)
		{
			using (var context = new ConcurrencyEntities())
			{
				var result = context.Items.Single(item => item.Id == id);
				return result;
			}
		}

		public void Update(Item item)
		{
			using (var context = new ConcurrencyEntities())
			{
				context.Items.Attach(item);
				context.Entry(item).State = EntityState.Modified;

				try
				{
					context.SaveChanges();
				}
				catch (DbUpdateConcurrencyException updateConcurrencyException)
				{
					var ex = new ConcurrencyException("Update failed.", updateConcurrencyException);
					throw ex;
				}
			}
		}
	}
}
