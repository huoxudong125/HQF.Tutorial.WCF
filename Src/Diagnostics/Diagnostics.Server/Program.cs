using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using HQF.Tutorial.WCF.Contract;

namespace Diagnostics.Server
{
    class Program
    {
        private static void Main(string[] args)
        {
            using (var host = new ServiceHost(typeof(CalculatorService)))
            {
                try
                {
                    Console.WriteLine("Press any key to exit");
                    host.Opened += (o, e) => { Console.WriteLine("Host is running..."); };
                    host.Open();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error:{0}", ex.Message);
                }

                Console.ReadKey();
                host.Close();
            }
        }
    }
}
