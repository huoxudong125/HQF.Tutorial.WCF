using System.Collections.Generic;
using System.ServiceModel;

namespace SimpleChatRoom.Common.Interface
{
    [ServiceContract(Namespace = "http://hqfz.cnlbogs.com/", SessionMode = SessionMode.Required,
        CallbackContract = typeof (IMessageCallback))]
    public interface IChatService
    {
        [OperationContract]
        bool Connect(string nickname);

        [OperationContract]
        bool Disconnect(string nickname);

        [OperationContract]
        IEnumerable<Message> GetChatHistory();

        [OperationContract]
        bool SendMessage(string sender, string messageText);
    }
}