using System.Runtime.Serialization;

namespace Binding.UdpBinding.Common
{
    [DataContract]
    public class Stock
    {
        [DataMember]
        public string Name;

        [DataMember]
        public double Price;
    }
}
