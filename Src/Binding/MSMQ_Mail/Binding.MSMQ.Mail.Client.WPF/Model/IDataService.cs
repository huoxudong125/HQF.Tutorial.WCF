using System;
using Binding.MSMQ.Mail.Common;

namespace Binding.MSMQ.Mail.Client.WPF.Model
{
    public interface IDataService
    {
        void GetData(Action<DataItem, Exception> callback);
       void GetDefaultMailMessage(Action<MailMessage, Exception> callback);
    }
}
