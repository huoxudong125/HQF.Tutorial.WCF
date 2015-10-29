using SimpleChatRoom.Common.Interface;
using SimpleChatRoom.Common.Interface.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Threading.Tasks;

namespace SimpleChatRoom.Common.Implement
{
    public class ChatService : IChatService
    {
        private Dictionary<string, Sessions> _userToSessionMap;

        private ChatAppDB _db;

        private readonly List<IMessageCallback> _receiverCallbacks = new List<IMessageCallback>();

        public bool Connect(string nickname)
        {
            try
            {
                var callback = OperationContext.Current.GetCallbackChannel<IMessageCallback>();
                if (!this._receiverCallbacks.Contains(callback))
                {
                    this._receiverCallbacks.Add(callback);

                    this.InitSession(nickname);
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Disconnect(string nickname)
        {
            try
            {
                var callback = OperationContext.Current.GetCallbackChannel<IMessageCallback>();
                if (this._receiverCallbacks.Contains(callback))
                {
                    this._receiverCallbacks.Remove(callback);
                }

                this.CloseSession(nickname);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public IEnumerable<Message> GetChatHistory()
        {
            foreach (var dbMessage in this._db.Messages)
            {
                yield return this.ConvertMessage(dbMessage);
            }

            //return this.db.Messages.Select(x => this.ConvertMessage(x));
        }

        public bool SendMessage(string sender, string messageText)
        {
            var message = new Message()
            {
                Sender = sender,
                MessageText = messageText,
                Timestamp = DateTime.Now
            };

            try
            {
                foreach (var callback in this._receiverCallbacks)
                {
                    callback.OnMessageAdded(message);
                }

                this.LogMessage(message);

                return true;
            }
            catch
            {
                return false;
            }
        }

        private void InitSession(string nickname)
        {
            this.Init();

            try
            {
                var user = this._db.Users.FirstOrDefault(x => x.Nickname == nickname);
                if (user == null)
                {
                    user = new Users() { Nickname = nickname };
                    user.Id = this._db.Users.Count() + 1;
                    this._db.Users.Add(user);
                }

                var session = new Sessions()
                {
                    Id = this._db.Sessions.Count() + 1,
                    Id_User = user.Id,
                    Connect_Time = DateTime.Now
                };

                this._userToSessionMap.Add(nickname, session);

                this._db.Sessions.Add(session);
                this._db.SaveChanges();
            }
            catch { }
        }

        private void Init()
        {
            if (this._db == null)
            {
                this._db = new ChatAppDB();
            }

            if (this._userToSessionMap == null)
            {
                this._userToSessionMap = new Dictionary<string, Sessions>();
            }
        }

        private void CloseSession(string nickname)
        {
            try
            {
                var session = this._userToSessionMap[nickname];
                session.Disconnect_Time = DateTime.Now;

                this._db.SaveChanges();
            }
            catch { }
        }

        private async Task LogMessage(Message message)
        {
            try
            {
                var user = this._db.Users.First(x => x.Nickname == message.Sender);

                var dbMessage = new Messages()
                {
                    Id = this._db.Messages.Count() + 1,
                    Id_Sender = user.Id,
                    Timestamp = message.Timestamp,
                    MessageText = message.MessageText
                };

                this._db.Messages.Add(dbMessage);
                await this._db.SaveChangesAsync();
            }
            catch { }
        }

        private Message ConvertMessage(Messages dbMessage)
        {
            var user = this._db.Users.FirstOrDefault(x => x.Id == dbMessage.Id_Sender);
            var sender = (user != null) ? user.Nickname : string.Empty;

            return new Message()
            {
                Sender = sender,
                Timestamp = dbMessage.Timestamp.GetValueOrDefault(),
                MessageText = dbMessage.MessageText
            };
        }
    }
}