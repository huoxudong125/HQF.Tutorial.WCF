using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using Routing.Base.Common;

namespace Routing.Base.Server
{

    class Program
    {
        static void Main(string[] args)
        {
            var host = new ServiceHost(typeof(ComplexNumberCalculator));

            try
            {
                host.Open();
                PrintServiceInfo(host);
                Console.ReadKey();
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
            Console.WriteLine("{0} is up and running with following endpoint(s)-", host.Description.ServiceType);

            foreach (ServiceEndpoint endpoint in host.Description.Endpoints)
                Console.WriteLine("{0} A-> {1},{0} B-> {2},{0} C-> {3}{0}",
                    Environment.NewLine,
                    endpoint.Address,
                    endpoint.Binding.Name,
                    endpoint.Contract.Name);
        }
    }
}

