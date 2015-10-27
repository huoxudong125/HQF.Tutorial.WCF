using System.ServiceModel;

namespace Routing.Version.CommonExtend
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

        [OperationContract]
        double Modulus(ComplexNumber x);

        [OperationContract]
        double Argument(ComplexNumber x);

        [OperationContract]
        ComplexNumber Conjugate(ComplexNumber x);

        [OperationContract]
        ComplexNumber Reciprocal(ComplexNumber x);
    }
}
