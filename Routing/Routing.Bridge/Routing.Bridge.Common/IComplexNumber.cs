using System.ServiceModel;

namespace Routing.Bridge.Common
{
    [ServiceContract]
    public interface IComplexNumber : IBinaryOperation, IUnaryOperation
    {       
    }
}
