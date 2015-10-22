using System;
using Binding.MSMQ.Mail.Common;

namespace Binding.MSMQ.Mail.Clien.WPF.Model
{
    public class DataService : IDataService
    {
        public void GetData(Action<DataItem, Exception> callback)
        {
            // Use this to connect to the actual data service

            var item = new DataItem("Welcome to MVVM Light");
            if (callback != null) callback(item, null);
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