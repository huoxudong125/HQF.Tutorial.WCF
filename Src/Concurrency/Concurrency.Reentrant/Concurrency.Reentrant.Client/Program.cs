using System;
using System.ServiceModel;
using System.Threading;
using Concurrency.Reentrant.Service.Interface;

namespace Concurrency.Reentrant.Client
{
    internal class Program
    {
        private static SynchronizationContext _syncContext;
        private static DuplexChannelFactory<ICalculator> _channelFactory;
        private static InstanceContext _callbackInstance;
        private static int _clientId = 0;

        private static void Main(string[] args)
        {
            string header = string.Format("{0, -13}{1, -22}{2}", "Client", "Time", "Event");
            Console.WriteLine(header);
            Console.WriteLine("Press any key to run clients");
            Console.ReadKey();

            _syncContext = SynchronizationContext.Current;
            _callbackInstance = new InstanceContext(new CalculatorCallbackService());

            //Create DuplexChannel 
            _channelFactory = new DuplexChannelFactory<ICalculator>(_callbackInstance, "calculatorservice");

            EventMonitor.MonitoringNotificationSended += ReceiveMonitoringNotification;

            for (int i = 0; i < 5; i++)
            {
                ThreadPool.QueueUserWorkItem(state =>
                {
                    int clientId = Interlocked.Increment(ref _clientId);
                    EventMonitor.Send(clientId, EventType.StartCall);
                    ICalculator proxy = _channelFactory.CreateChannel();
                    using (OperationContextScope contextScope = new OperationContextScope(proxy as IContextChannel))
                    {
                        MessageHeader<int> messageHeader = new MessageHeader<int>(clientId);
                        OperationContext.Current.OutgoingMessageHeaders.Add(messageHeader.GetUntypedHeader(EventMonitor.CientIdHeaderLocalName, EventMonitor.CientIdHeaderNamespace));
                        proxy.Add(1, 2);
                    }
                    EventMonitor.Send(clientId, EventType.EndCall);
                }, null);
            }

            Console.WriteLine("Press any key to exit.Client");

            header = string.Format("{0, -13}{1, -22}{2}", "Client", "Time", "Event");
            Console.WriteLine(header);

            Console.ReadKey();

            EventMonitor.MonitoringNotificationSended -= ReceiveMonitoringNotification;

            _channelFactory.Close();
        }

        public static void ReceiveMonitoringNotification(object sender, MonitorEventArgs args)
        {
            string message = string.Format("{0, -15}{1, -20}{2}", args.ClientId, args.EventTime.ToLongTimeString(),
                args.EventType);
            Console.WriteLine(message);
        }
    }
}