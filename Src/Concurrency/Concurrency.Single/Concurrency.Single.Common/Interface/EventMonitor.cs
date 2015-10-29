using System;
using System.ServiceModel;

namespace Concurrency.Single.Common.Interface
{
    public static class EventMonitor
    {
        public const string CientIdHeaderNamespace = "http://hqfz.cnblogs.com/";
        public const string CientIdHeaderLocalName = "ClientId";
        public static EventHandler<MonitorEventArgs> MonitoringNotificationSended;

        public static void Send(EventType eventType)
        {
            if (null != MonitoringNotificationSended)
            {
                int clientId = OperationContext.Current.IncomingMessageHeaders.GetHeader<int>(CientIdHeaderLocalName, CientIdHeaderNamespace);
                MonitoringNotificationSended(null, new MonitorEventArgs(clientId, eventType, DateTime.Now));
            }
        }

        public static void Send(int clientId, EventType eventType)
        {
            if (null != MonitoringNotificationSended)
            {
                MonitoringNotificationSended(null, new MonitorEventArgs(clientId, eventType, DateTime.Now));
            }
        }
    }
}