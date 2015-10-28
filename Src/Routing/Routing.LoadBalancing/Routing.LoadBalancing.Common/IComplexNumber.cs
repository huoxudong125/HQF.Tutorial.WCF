using System.ServiceModel;

namespace Routing.LoadBalancing.Common
{
    [ServiceContract]
    public interface IComplexNumber : IBinaryOperation, IUnaryOperation
    {       
    }
}
