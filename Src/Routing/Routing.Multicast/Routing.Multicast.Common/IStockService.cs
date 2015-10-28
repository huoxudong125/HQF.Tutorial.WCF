using System.ServiceModel;

namespace Routing.Multicast.Common
{
    [ServiceContract]
    public interface IStockService
    {
        [OperationContract(IsOneWay = true)]
        void SendStockDetail(Stock stock);
    }
}
