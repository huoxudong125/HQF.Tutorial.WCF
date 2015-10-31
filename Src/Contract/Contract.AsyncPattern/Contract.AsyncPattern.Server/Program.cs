using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Contract.AsyncPattern.Common;

namespace Contract.AsyncPattern.Server
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(FileReaderService)))
            {
                host.Open();
                Console.Read();
            }
        }
    }
}
