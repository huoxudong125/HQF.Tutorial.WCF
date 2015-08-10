using System.ServiceModel;

namespace HQF.Tutorial.WCF.Contract.Interface
{
    [ServiceContract(Name = "CalculatorService", Namespace = "http://www.itelite.com/")]
    public interface ICalculator
    {
        [OperationContract]
        double Add(double x, double y);

        [OperationContract]
        double Subtract(double x, double y);

        [OperationContract]
        double Multiply(double x, double y);

        [OperationContract]
        double Divide(double x, double y);
    }
}