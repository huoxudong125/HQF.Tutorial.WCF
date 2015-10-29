using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using SimpleChatRoom.Client.Model;
using SimpleChatRoom.Common.Interface;
using System.ServiceModel;

namespace SimpleChatRoom.Client.ViewModel
{
    /// <summary>
    ///     This class contains properties that the main View can data bind to.
    ///     <para>
    ///         See http://www.mvvmlight.net
    ///     </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        ///     The <see cref="WelcomeTitle" /> property's name.
        /// </summary>
        public const string WelcomeTitlePropertyName = "WelcomeTitle";

        private readonly IDataService _dataService;
        private readonly IChannel proxy;

        private string _welcomeTitle = string.Empty;

        private ObservableCollection<string> chatMessages;

        private bool isConnected;

        private string messageText;

        private string nickname;

        private IChatService _chatService;

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

            ConnectCommand = new RelayCommand(OnConnect);
            SendCommand = new RelayCommand(OnSend);
            var channel = new DuplexChannelFactory<IChatService>("chartService");
            _chatService = channel.CreateChannel();
        }

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
            set { Set(ref nickname, value); }
        }

        public string MessageText
        {
            get { return messageText; }
            set { Set(ref messageText, value); }
        }

        public IEnumerable<string> ChatMessages
        {
            get { return chatMessages; }
        }

        public ICommand ConnectCommand { get; private set; }
        public ICommand SendCommand { get; private set; }

        private void OnSend()
        {
            if (!this.isConnected)
                return;

            try
            {
               _chatService.SendMessage(this.Nickname, this.MessageText);
            }
            catch { }

            this.MessageText = string.Empty;

        }

        private void OnConnect()
        {
            if (this.isConnected)
                return;

            try
            {
                this.isConnected = _chatService.Connect(this.Nickname);

                if (this.isConnected)
                {
                    var chatHistory = _chatService.GetChatHistory();

                    var chatHistoryStrings = chatHistory.Select(x => x.ToString());
                    this.chatMessages = new ObservableCollection<string>(chatHistoryStrings);
                    RaisePropertyChanged(() => ChatMessages);
                }
            }
            catch
            {
                
            }

        }

        ////}

        ////    base.Cleanup();
        ////    // Clean up if needed
        ////{

        ////public override void Cleanup()
    }
}