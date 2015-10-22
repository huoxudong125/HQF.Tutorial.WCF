using System;
using System.Diagnostics;

namespace Binding.MSMQ.Mail.Common
{
    public class SendMailService : ISendMail
    {
        public void SubmitMessage(MailMessage message)
        {
            var msgStr = string.Format("{0}A mew EMail: {0}To: {1}{0} From:{2}{0} Subject:{3}{0} Body:{4}",
                Environment.NewLine, message.ToAddress, message.FromAddress, message.Subject, message.Body);

            Console.WriteLine(msgStr);
            Trace.WriteLine(msgStr);
        }
    }
}