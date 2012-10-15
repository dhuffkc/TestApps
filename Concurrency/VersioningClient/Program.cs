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

            var message = client.GetMessage(4);

            message.Number = DateTime.Now.Millisecond.ToString();

            try
            {
                client.UpdateMessage(message);
            }
            catch (FaultException<ConcurrencyFaultInformation> exception)
            {
                Console.Out.WriteLine("Bad mojo: " + exception.ToString());
                throw;
            }

            Console.Out.WriteLine("Successed!");
        }
    }
}
