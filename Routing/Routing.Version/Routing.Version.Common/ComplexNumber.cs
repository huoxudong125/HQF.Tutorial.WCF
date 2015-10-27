using System.Runtime.Serialization;

namespace Routing.Version.Common
{
    [DataContract]
    public class ComplexNumber
    {
        [DataMember]
        public double Real;

        [DataMember]
        public double Imaginary;
    }
}
