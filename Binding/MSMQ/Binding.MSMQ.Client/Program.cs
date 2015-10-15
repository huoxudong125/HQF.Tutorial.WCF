using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Binding.MSMQ.Client.Services;

namespace Binding.MSMQ.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var client = new QueueCalculatorClient())
            {
                client.Add(1,1);
                client.Subtract(2, 1);
                client.Multiply(2,2);
                client.Divide(4,2);
                Console.WriteLine("Press any key to exit.");
                Console.ReadKey();
                client.Close();
            }
        }
    }
}
