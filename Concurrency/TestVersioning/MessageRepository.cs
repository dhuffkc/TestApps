namespace TestVersioning
{
    using System.Data;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using TestVersioning.Models;

    public static class MessageRepository
    {
        public static SimplifiedMessage GetMessage(int id)
        {
            using (var context = new versioningEntities())
            {
                var result = context.SimplifiedMessages.Single(m => m.Id == id);
                return result;
            }
        }

        public static void UpdateMessage(SimplifiedMessage message)
        {
            using (var context = new versioningEntities())
            {
                context.SimplifiedMessages.Attach(message);
                context.Entry(message).State = EntityState.Modified;

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