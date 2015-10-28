using System;
using System.Windows;
using Binding.MSMQ.Mail.Client.WPF.Model;
using Binding.MSMQ.Mail.Client.WPF.Service;
using Binding.MSMQ.Mail.Common;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace Binding.MSMQ.Mail.Client.WPF.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// See http://www.mvvmlight.net
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private readonly IDataService _dataService;

        /// <summary>
        /// The <see cref="WelcomeTitle" /> property's name.
        /// </summary>
        public const string WelcomeTitlePropertyName = "WelcomeTitle";

        private string _welcomeTitle = string.Empty;
        private MailMessage _mainMailMessage;

        /// <summary>
        /// Gets the WelcomeTitle property.
        /// Changes to that property's value raise the PropertyChanged event.
        /// </summary>
        public string WelcomeTitle
        {
            get
            {
                return _welcomeTitle;
            }
            set
            {
                Set(ref _welcomeTitle, value);
            }
        }

        public RelayCommand SendMainCommand { get; private set; }

        public RelayCommand AboutMeCommand { get; private set; }

        public MailMessage MainMailMessage
        {
            get { return _mainMailMessage; }
            set { Set(ref _mainMailMessage, value); }
        }

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
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

            _dataService.GetDefaultMailMessage(
                (item, error) =>
                {
                    if (error != null)
                    {
                        // Report error here
                        return;
                    }

                    MainMailMessage = item;
                });

            SendMainCommand = new RelayCommand(OnSendMail);
            AboutMeCommand = new RelayCommand(OnAboutMe);
        }

        private void OnAboutMe()
        {
            MessageBox.Show("Test SendMail Using WCF with MSMQ Binding");
        }

        private void OnSendMail()
        {
            try
            {
                using (var client = new SendMailClient())
                {
                    client.SubmitMessage(MainMailMessage);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        ////public override void Cleanup()
        ////{
        ////    // Clean up if needed

        ////    base.Cleanup();
        ////}
    }
}