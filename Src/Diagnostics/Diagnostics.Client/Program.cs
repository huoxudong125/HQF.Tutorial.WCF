using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using HQF.Tutorial.WCF.Contract.Interface;

namespace Diagnostics.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Press any key to Run the client");
                Console.ReadKey();


                using (var client = new ChannelFactory<ICalculator>("basicHttpBinding_ICalculator"))
                {
                    var channel = client.CreateChannel();
                    int x = 1, y = 2;
                    var z = channel.Add(x, y);
                    Console.WriteLine("{0}+{1}={2}", x, y, z);


                    Console.WriteLine("Press any key to exit the client.");
                    Console.ReadKey();

                    ((IClientChannel)channel).Close();

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }



        }
    }
}
