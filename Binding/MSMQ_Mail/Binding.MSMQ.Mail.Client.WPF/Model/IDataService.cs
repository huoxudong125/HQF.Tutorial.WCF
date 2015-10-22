using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Binding.MSMQ.Mail.Common;

namespace Binding.MSMQ.Mail.Clien.WPF.Model
{
    public interface IDataService
    {
        void GetData(Action<DataItem, Exception> callback);
       void GetDefaultMailMessage(Action<MailMessage, Exception> callback);
    }
}
