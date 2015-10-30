using System.ServiceModel;

namespace Contract.Duplex.Common
{
    // The callback interface is used to send messages from service back to client.
    // The Equals operation will return the current result after each operation.
    // The Equation opertion will return the complete equation after Clear() is called.
    public interface ICalculatorDuplexCallback
    {
        [OperationContract(IsOneWay = true)]
        void Equals(double result);

        [OperationContract(IsOneWay = true)]
        void Equation(string eqn);
    }
}