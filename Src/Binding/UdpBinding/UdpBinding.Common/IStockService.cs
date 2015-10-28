using System.ServiceModel;

namespace Binding.UdpBinding.Common
{
    [ServiceContract]
    public interface IStockService
    {
        [OperationContract(IsOneWay = true)]
        void SendStockDetail(Stock stock);
    }
}
