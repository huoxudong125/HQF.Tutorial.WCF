using System.ServiceModel;

namespace Contract.Duplex.Common
{
    // Define a duplex service contract.
    // A duplex contract consists of two interfaces.
    // The primary interface is used to send messages from client to service.
    // The callback interface is used to send messages from service back to client.
    // ICalculatorDuplex allows one to perform multiple operations on a running result.
    // The result is sent back after each operation on the ICalculatorCallback interface.
    [ServiceContract(Namespace = "http://Microsoft.ServiceModel.Samples"
        , SessionMode = SessionMode.Required,
        CallbackContract = typeof (ICalculatorDuplexCallback))]
    public interface ICalculatorDuplex
    {
        [OperationContract(IsOneWay = true)]
        void Clear();

        [OperationContract(IsOneWay = true)]
        void AddTo(double n);

        [OperationContract(IsOneWay = true)]
        void SubtractFrom(double n);

        [OperationContract(IsOneWay = true)]
        void MultiplyBy(double n);

        [OperationContract(IsOneWay = true)]
        void DivideBy(double n);
    }
}