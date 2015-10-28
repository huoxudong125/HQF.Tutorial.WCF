using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using Binding.UdpBinding.Common;

namespace Binding.UdpBinding.Server
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = new ServiceHost(typeof(StockService));
            try
            {
                host.Open();
                PrintServiceInfo(host);
                Console.ReadLine();
                host.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                host.Abort();
            }
        }

        static void PrintServiceInfo(ServiceHost host)
        {
            Console.WriteLine("{0} is up and running with following endpoint(s)-", host.Description.ServiceType);

            foreach (ServiceEndpoint endpoint in host.Description.Endpoints)
                Console.WriteLine(endpoint.Address);
            Console.WriteLine();
        }
    }
}
