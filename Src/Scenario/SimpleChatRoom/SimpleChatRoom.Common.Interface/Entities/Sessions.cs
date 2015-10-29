using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleChatRoom.Common.Interface
{
    public partial class Sessions
    {
        public int Id { get; set; }
        public int Id_User { get; set; }
        public Nullable<System.DateTime> Connect_Time { get; set; }
        public Nullable<System.DateTime> Disconnect_Time { get; set; }

        public virtual Users Users { get; set; }
    }

}
