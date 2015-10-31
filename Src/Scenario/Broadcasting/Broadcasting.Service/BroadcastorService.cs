using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Broadcasting.Service.Interface;

namespace Broadcasting.Service
{
    //Here we have specified the InstanceContextMode to be InstanceContextMode.Single, which means this service will be a singleton service. All clients will connect to the same instance of the service, so the client list, which will be defined soon, will be shared by all clients. This makes it possible for the service to broadcast to all clients when an event occurs.

   // We have also specified ConcurrencyMode to be ConcurrencyMode.Multiple, which means the service will be multi-threaded.This will increase the scalability of the service, but at same time we have to take care of the data sharing among multiple threads.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class BroadcastorService : IBroadcastorService
    {
        private static Dictionary<string, IBroadcastorCallBack> clients =
new Dictionary<string, IBroadcastorCallBack>();
        private static object locker = new object();

        public void RegisterClient(string clientName)
        {
            if (!string.IsNullOrEmpty(clientName))
            {
                try
                {
                    IBroadcastorCallBack callback =
        OperationContext.Current.GetCallbackChannel<IBroadcastorCallBack>();
                    lock (locker)
                    {
                        //remove the old client
                        if (clients.Keys.Contains(clientName))
                            clients.Remove(clientName);
                        clients.Add(clientName, callback);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error:{0}",ex.Message);
                }
            }
        }

        public void NotifyServer(EventDataType eventData)
        {
            lock (locker)
            {
                var inactiveClients = new List<string>();
                foreach (var client in clients)
                {
                    if (client.Key != eventData.ClientName)
                    {
                        try
                        {
                            client.Value.BroadcastToClient(eventData);
                        }
                        catch (Exception ex)
                        {
                            inactiveClients.Add(client.Key);
                        }
                    }
                }

                if (inactiveClients.Count > 0)
                {
                    foreach (var client in inactiveClients)
                    {
                        clients.Remove(client);
                    }
                }
            }
        }
    }
}
