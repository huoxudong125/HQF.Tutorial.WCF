using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using Routing.Multicast.Common;

namespace Routing.Multicast.Server
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
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                host.Abort();
            }
        }

        static void PrintServiceInfo(ServiceHost host)
        {
            Console.WriteLine("\n{0} is up and running with following endpoint(s)-", host.Description.ServiceType);

            foreach (ServiceEndpoint endpoint in host.Description.Endpoints)
                Console.WriteLine("\nA-> {0}, B-> {1}, C-> {2}\n",
                    endpoint.Address,
                    endpoint.Binding.Name,
                    endpoint.Contract.Name);
        }
    }
}
