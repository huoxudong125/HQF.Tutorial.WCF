using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleChatRoom.Client.Model
{
   public static class MessageExtend
    {
       public static string AsString(this SimpleChatRoom.Common.Interface.Message message)
       { 
           return string.Format("{0}:  {1} - {2}", message.Timestamp, message.Sender, message.MessageText);
       }
    }
}
