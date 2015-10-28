using System.Runtime.Serialization;

namespace Routing.Base.Common
{
    [DataContract]
    public class Complex
    {
        [DataMember]
        public double Real;

        [DataMember]
        public double Imaginary;
    }

}
