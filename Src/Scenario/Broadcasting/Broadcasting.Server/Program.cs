using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Broadcasting.Server
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var host=new ServiceHost(typeof(Broadcasting.Service.BroadcastorService)))
            {
               
                host.Opened += (o,e) => {Console.WriteLine("Host is running."); };
                host.Open();
                Console.WriteLine("Press any key to exit.");
                Console.ReadKey();
            }
        }
    }
}
