using System.ServiceModel;

namespace Routing.Bridge.Common
{
    [ServiceContract]
    public interface IUnaryOperation
    {
        [OperationContract]
        double Modulus(Complex x);

        [OperationContract]
        double Argument(Complex x);

        [OperationContract]
        Complex Conjugate(Complex x);

        [OperationContract]
        Complex Reciprocal(Complex x);
    }
}
