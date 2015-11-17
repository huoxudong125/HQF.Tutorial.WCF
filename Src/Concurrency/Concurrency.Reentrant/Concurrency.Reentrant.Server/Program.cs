using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Concurrency.Reentrant.Service;
using Concurrency.Reentrant.Service.Interface;

namespace Concurrency.Reentrant.Server
{
    class Program
    {
        private static void Main(string[] args)
        {
            EventMonitor.MonitoringNotificationSended += ReceiveMonitoringNotification;

            using (var _serviceHost = new ServiceHost(typeof(CalculatorService)))
            {
                _serviceHost.Open();
                _serviceHost.Opened += _serviceHost_Opened;

                Console.WriteLine("Press any key to exit.Server");
                var header = string.Format("{0, -13}{1, -22}{2}", "Client", "Time", "Event");

                Console.WriteLine(header);

                Console.ReadKey();

                EventMonitor.MonitoringNotificationSended -= ReceiveMonitoringNotification;

                _serviceHost.Close();
            }
        }

        private static void _serviceHost_Opened(object sender, EventArgs e)
        {
            Console.WriteLine("Host is Runing.");
        }

        public static void ReceiveMonitoringNotification(object sender, MonitorEventArgs args)
        {
            var message = string.Format("{0, -15}{1, -20}{2}", args.ClientId, args.EventTime.ToLongTimeString(),
                args.EventType);
            Console.WriteLine(message);
        }
    }
}
