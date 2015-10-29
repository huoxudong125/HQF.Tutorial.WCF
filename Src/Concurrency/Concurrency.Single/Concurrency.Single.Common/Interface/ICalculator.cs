using System.ServiceModel;

namespace Concurrency.Single.Common.Interface
{
    [ServiceContract(Namespace = "http://hqfz.cnblogs.com/")]
    public interface ICalculator
    {
        [OperationContract]
        double Add(double x, double y);
    }
}