using System;
using System.ServiceModel;
using System.ServiceProcess;
using System.Threading;
using HQF.Tutorial.WCF.Contract;

namespace HQF.Tutorial.WCF.Host.WinService
{
    public partial class DemoService : ServiceBase
    {
        private ServiceHost _host;

        public DemoService()
        {
            InitializeComponent();
        }

        private void StopListening()
        {
            try
            {
                ((IDisposable) _host).Dispose();
            }
            catch (CommunicationObjectFaultedException ex)
            {
                // TODO: add code to log
            }
        }

        #region override

        protected override void OnStart(string[] args)
        {
            ThreadPool.QueueUserWorkItem(StartListening, this);
        }

        private static void StartListening(object state)
        {
            var service = state as DemoService;
            if (service != null)
            {
                service._host = new ServiceHost(typeof (CalculatorService));
                service._host.Faulted +=
                    (s, e) =>
                    {
                        service.StopListening();
                        service._host = null;
                        StartListening(service);
                    };
            }
        }

        protected override void OnStop()
        {
            StopListening();
        }

        protected override void OnPause()
        {
            StopListening();
            base.OnPause();
        }

        protected override void OnContinue()
        {
            ThreadPool.QueueUserWorkItem(StartListening, this);
            base.OnContinue();
        }

        #endregion
    }
}