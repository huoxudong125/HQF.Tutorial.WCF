using System.ServiceModel;

namespace Binding.MSMQ.Mail.Common
{
    [ServiceContract(Namespace = "http://schemas.class-a.nl/msmq/example01/2008/02/",
        SessionMode = SessionMode.NotAllowed)]
    public interface ISendMail
    {
        [OperationContract(Name = "SubmitMessage", IsOneWay = true)]
        void SubmitMessage(MailMessage message);
    }
}