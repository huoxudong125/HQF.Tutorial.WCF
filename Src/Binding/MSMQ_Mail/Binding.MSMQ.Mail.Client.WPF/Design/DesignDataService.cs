using System;
using Binding.MSMQ.Mail.Client.WPF.Model;
using Binding.MSMQ.Mail.Common;

namespace Binding.MSMQ.Mail.Client.WPF.Design
{
    public class DesignDataService : IDataService
    {
        public void GetData(Action<DataItem, Exception> callback)
        {
            // Use this to create design time data

            var item = new DataItem("Welcome to MVVM Light [design]");
            callback(item, null);
        }
        public void GetDefaultMailMessage(Action<MailMessage, Exception> callback)
        {
            var msg = new MailMessage();
            msg.ToAddress = "works4you@163.com";
            msg.FromAddress = "works4you@113.com";
            msg.Body = "Wow, is this going to work?";
            if (callback != null) callback(msg, null);
        }
    }
}