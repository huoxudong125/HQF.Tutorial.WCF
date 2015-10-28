using System.ServiceModel;

namespace Routing.Bridge.Common
{
    [ServiceContract]
    public interface IBinaryOperation
    {
        [OperationContract]
        Complex Add(Complex x, Complex y);

        [OperationContract]
        Complex Subtract(Complex x, Complex y);

        [OperationContract]
        Complex Multiply(Complex x, Complex y);

        [OperationContract]
        Complex Divide(Complex x, Complex y);
    }
}
