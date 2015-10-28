using System.Runtime.Serialization;

namespace Routing.Multicast.Common
{
    [DataContract]
    public class Stock
    {
        [DataMember]
        public string Name;

        [DataMember]
        public string StockType;

        [DataMember]
        public double Price;
    }
}
