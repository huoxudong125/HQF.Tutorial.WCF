using System.Runtime.Serialization;

namespace Routing.LoadBalancing.Common
{
    [DataContract]
    public class Complex
    {
        [DataMember]
       public  double Real;

        [DataMember]
        public double Imaginary;
    }
}
