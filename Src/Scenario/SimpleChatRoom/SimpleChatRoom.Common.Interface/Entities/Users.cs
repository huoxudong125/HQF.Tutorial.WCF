using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleChatRoom.Common.Interface.Entities;

namespace SimpleChatRoom.Common.Interface
{
    public partial class Users
    {
        public Users()
        {
            this.Messages = new HashSet<Messages>();
            this.Sessions = new HashSet<Sessions>();
        }

        public int Id { get; set; }
        public string Nickname { get; set; }

        public virtual ICollection<Messages> Messages { get; set; }
        public virtual ICollection<Sessions> Sessions { get; set; }
    }

}
