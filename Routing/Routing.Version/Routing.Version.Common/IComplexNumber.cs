using System.ServiceModel;

namespace Routing.Version.Common
{
    [ServiceContract]
    public interface IComplexNumber
    {
        [OperationContract]
        ComplexNumber Add(ComplexNumber x, ComplexNumber y);

        [OperationContract]
        ComplexNumber Subtract(ComplexNumber x, ComplexNumber y);

        [OperationContract]
        ComplexNumber Multiply(ComplexNumber x, ComplexNumber y);

        [OperationContract]
        ComplexNumber Divide(ComplexNumber x, ComplexNumber y);
    }
}
