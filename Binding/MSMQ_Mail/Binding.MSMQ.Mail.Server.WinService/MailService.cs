using System;
using System.Configuration;
using System.Diagnostics;
using System.Messaging;
using System.ServiceModel;
using System.ServiceProcess;
using Binding.MSMQ.Mail.Common;

namespace Binding.MSMQ.Mail.Server.WinService
{
    public partial class MailService : ServiceBase
    {
        ServiceHost _host = null;
        public MailService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            string queueName = ConfigurationManager.AppSettings["SendMailQueueName"];

            Trace.WriteLine("Starting Class-A E-mail Service...");

            if (!MessageQueue.Exists(queueName))
            {
                Trace.WriteLine("Creating queue : " + queueName);
                MessageQueue.Create(queueName, true);
            }

            _host = new ServiceHost(typeof(SendMailService));
            Trace.WriteLine("Try open  Class-A E-mail Service...");
            try
            {
                _host.Open();
            }
            catch (Exception ex)
            {

                Trace.WriteLine(string.Format("Start service error:{0}",ex.Message)); 
            }
            
        }

        protected override void OnStop()
        {
            Trace.WriteLine("Shutting down Class-A E-mail Service...");
            if (_host != null)
            {
                _host.Close();
                _host = null;
            }
        }
    }
}
