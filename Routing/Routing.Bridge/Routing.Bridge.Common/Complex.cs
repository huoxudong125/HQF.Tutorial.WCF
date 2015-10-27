using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Routing.Bridge.Common
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
