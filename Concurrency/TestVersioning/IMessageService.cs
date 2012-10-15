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
        [FaultContract(typeof(ConcurrencyFaultInformation))]
        SimplifiedMessage UpdateMessage(SimplifiedMessage message);
    }
}
