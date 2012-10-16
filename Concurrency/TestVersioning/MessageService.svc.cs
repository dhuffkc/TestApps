namespace TestVersioning
{
    using System;
    using TestVersioning.Models;
    using System.ServiceModel;

    public class MessageService : IMessageService
    {
        public SimplifiedMessage GetMessage(int id)
        {
            var message = MessageRepository.GetMessage(id);
            return message;
        }

        public SimplifiedMessage UpdateMessage(SimplifiedMessage message)
        {
            try
            {
                MessageRepository.UpdateMessage(message);
                return message;
            }
            catch (ConcurrencyException)
            {
                var ex = new FaultException<ConcurrencyFault>(
                    new ConcurrencyFault(), "Concurrency exception.");
                throw ex;
            }
        }
    }
}
