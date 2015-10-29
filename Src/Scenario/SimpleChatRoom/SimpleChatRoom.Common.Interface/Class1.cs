using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SimpleChatRoom.Common.Interface
{
    [DataContract]
    public class Message
    {
        [DataMember]
        public string Sender { get; set; }

        [DataMember]
        public DateTime Timestamp { get; set; }

        [DataMember]
        public string MessageText { get; set; }
    }

}
