using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.ServiceModel;
using System.Threading.Tasks;
using System.Windows;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using SimpleChatRoom.Client.Model;
using SimpleChatRoom.Common.Interface;

namespace SimpleChatRoom.Client.ViewModel
{
    /// <summary>
    ///     This class contains properties that the main View can data bind to.
    ///     <para>
    ///         See http://www.mvvmlight.net
    ///     </para>
    /// </summary>
    public class MainViewModel : ViewModelBase, IMessageCallback
    {
        /// <summary>
        ///     The <see cref="WelcomeTitle" /> property's name.
        /// </summary>
        public const string WelcomeTitlePropertyName = "WelcomeTitle";

        private readonly IChatService _chatService;

        private readonly IDataService _dataService;
        private readonly IChannel proxy;

        private string _welcomeTitle = string.Empty;

        private ObservableCollection<string> chatMessages;

        private bool isConnected;

        private string messageText;

        private string nickname;

        #region .octor

        /// <summary>
        ///     Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(IDataService dataService)
        {
            _dataService = dataService;
            _dataService.GetData(
                (item, error) =>
                {
                    if (error != null)
                    {
                        // Report error here
                        return;
                    }

                    WelcomeTitle = item.Title;
                });
            ConnectCommand = new RelayCommand(OnConnect, IsNeedConnect);
            SendCommand = new RelayCommand(OnSend, CanSendMessage);
            DisConnectCommand = new RelayCommand(OnDisConnect, IsNeedDisConnect);
            var instanceContext = new InstanceContext(this);
            var channel = new DuplexChannelFactory<IChatService>(instanceContext, "chartService");
            _chatService = channel.CreateChannel();
            Nickname = "frank";
            MessageText = "Hello!";

            RaiseCommandChanged();
        }

        #endregion

        public void OnMessageAdded(Message message)
        {
            Console.WriteLine("Add message begin...");
            chatMessages.Add(message.AsString());
            Console.WriteLine("Add message finish");
        }

        private void OnSend()
        {
            if (!isConnected)
                return;

            try
            {
                Task.Run(() => _chatService.SendMessage(Nickname, MessageText))
                    .ConfigureAwait(false);
            }
            catch
            {
            }

            MessageText = string.Empty;
        }

        private void OnConnect()
        {
            if (isConnected)
            {
                MessageBox.Show("you need to connect first");
                return;
            }

            try
            {
                isConnected = _chatService.Connect(Nickname);

                if (isConnected)
                {
                    var chatHistory = _chatService.GetChatHistory();

                    var chatHistoryStrings = chatHistory.Select(x => x.AsString());
                    chatMessages = new ObservableCollection<string>(chatHistoryStrings);
                    RaisePropertyChanged(() => ChatMessages);
                }
                RaiseCommandChanged();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #region Properties

        /// <summary>
        ///     Gets the WelcomeTitle property.
        ///     Changes to that property's value raise the PropertyChanged event.
        /// </summary>
        public string WelcomeTitle
        {
            get { return _welcomeTitle; }
            set { Set(ref _welcomeTitle, value); }
        }

        public string Nickname
        {
            get { return nickname; }
            set
            {
                Set(ref nickname, value);
                RaiseCommandChanged();
            }
        }

        public string MessageText
        {
            get { return messageText; }
            set
            {
                Set(ref messageText, value);
                RaiseCommandChanged();
            }
        }

        public IEnumerable<string> ChatMessages
        {
            get { return chatMessages; }
        }

        #endregion

        //public override void Cleanup()
        //{
        ////Clean up if needed
        //    base.Cleanup();
        //}

        #region Command

        public RelayCommand ConnectCommand { get; }

        public RelayCommand SendCommand { get; }

        public RelayCommand DisConnectCommand { get; }

        #endregion

        #region private functions

        private void RaiseCommandChanged()
        {
            ConnectCommand.RaiseCanExecuteChanged();
            SendCommand.RaiseCanExecuteChanged();
            DisConnectCommand.RaiseCanExecuteChanged();
        }

        private void OnDisConnect()
        {
            isConnected = _chatService.Connect(Nickname);
            RaiseCommandChanged();
        }

        private bool IsNeedDisConnect()
        {
            return isConnected;
        }

        private bool CanSendMessage()
        {
            return !string.IsNullOrEmpty(MessageText) && !string.IsNullOrEmpty(nickname) && isConnected;
        }

        private bool IsNeedConnect()
        {
            return !isConnected;
        }

        #endregion
    }
}