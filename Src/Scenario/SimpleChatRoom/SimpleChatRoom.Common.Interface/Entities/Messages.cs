using System;
using System.Runtime.Serialization;

namespace SimpleChatRoom.Common.Interface.Entities
{
    [DataContract]

    public partial class Messages
    {
        public int Id { get; set; }
        public int Id_Sender { get; set; }
        public Nullable<System.DateTime> Timestamp { get; set; }
        public string MessageText { get; set; }

        public virtual Users Users { get; set; }
    }

}
