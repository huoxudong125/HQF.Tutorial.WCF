using Concurrency.Single.Common.Interface;
using System;
using System.ServiceModel;
using System.Threading;

namespace Concurrency.Single.Client
{
    internal class Program
    {
        private static int clientIdIndex = 0;

        private static void Main(string[] args)
        {
            using (var _channelFactory = new ChannelFactory<ICalculator>("calculatorservice"))
            {
                Console.WriteLine("Press any key to run, Client.");
                Console.ReadKey();
                EventMonitor.MonitoringNotificationSended += ReceiveMonitoringNotification;

                for (int i = 1; i <= 5; i++)
                {
                    ThreadPool.QueueUserWorkItem(state =>
                    {
                        int clientId = Interlocked.Increment(ref clientIdIndex);
                        ICalculator proxy = _channelFactory.CreateChannel();
                        using (proxy as IDisposable)
                        {
                            EventMonitor.Send(clientId, EventType.StartCall);
                            using (OperationContextScope contextScope = new OperationContextScope(proxy as IContextChannel))
                            {
                                MessageHeader<int> messageHeader = new MessageHeader<int>(clientId);
                                OperationContext.Current.OutgoingMessageHeaders.Add(
                                    messageHeader.GetUntypedHeader(EventMonitor.CientIdHeaderLocalName,
                                        EventMonitor.CientIdHeaderNamespace));
                                proxy.Add(1, 2);
                            }
                            EventMonitor.Send(clientId, EventType.EndCall);
                        }
                    });
                }

                Console.WriteLine("Press any key to exit.Client");
                string header = string.Format("{0, -13}{1, -22}{2}", "Client", "Time", "Event");
                Console.WriteLine(header);

                Console.ReadKey();

                EventMonitor.MonitoringNotificationSended -= ReceiveMonitoringNotification;

                _channelFactory.Close();
            }
        }

        public static void ReceiveMonitoringNotification(object sender, MonitorEventArgs args)
        {
            string message = string.Format("{0, -15}{1, -20}{2}", args.ClientId, args.EventTime.ToLongTimeString(),
                args.EventType);
            Console.WriteLine(message);
        }
    }
}