using System.Runtime.Serialization;

namespace Routing.Version.CommonExtend
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
