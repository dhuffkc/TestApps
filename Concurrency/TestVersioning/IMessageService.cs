namespace TestVersioning
{
    using System.Net.Security;
    using System.ServiceModel;
    using TestVersioning.Models;

    [ServiceContract]
    public interface IMessageService
    {
        [OperationContract]
        SimplifiedMessage GetMessage(int id);

        [OperationContract]
        //[FaultContract(typeof(ConcurrencyFault))]
        SimplifiedMessage UpdateMessage(SimplifiedMessage message);
    }
}
