using System;

namespace Binding.MSMQ.Mail.Common
{
    public class SendMailService : ISendMail
    {
        public void SubmitMessage(MailMessage message)
        {
            Console.WriteLine("To: " + message.ToAddress);
            Console.WriteLine("From: " + message.FromAddress);
            Console.WriteLine("Subject: " + message.Subject);
            Console.WriteLine("Body: " + message.Body);
        }
    }
}