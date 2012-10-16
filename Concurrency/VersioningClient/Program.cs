using System;

namespace VersioningClient
{
    using VersioningClient.MessageService;
    using System.ServiceModel;

    class Program
    {
        static void Main(string[] args)
        {
            var client = new MessageServiceClient();

            SimplifiedMessage message;

            try
            {
                message = client.GetMessage(4);
            }
            catch (Exception)
            {
                client.Abort();
                throw;
            }

            message.Number = DateTime.Now.Millisecond.ToString();

            Console.Out.WriteLine("Retrieved current message.  Hit enter to update...");
            Console.In.ReadLine();

            try
            {
                client.UpdateMessage(message);
                client.Close();

                Console.Out.WriteLine("Successed!");
            }
            catch (FaultException<ConcurrencyFault>)
            {
                client.Abort();
                Console.Out.WriteLine("Update failed due to a concurrency conflict.");
            }
            catch (Exception)
            {
                client.Abort();
                throw;
            }
        }
    }
}
