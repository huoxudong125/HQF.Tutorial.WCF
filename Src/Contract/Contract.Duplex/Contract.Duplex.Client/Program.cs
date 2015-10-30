using Contract.Duplex.Common;
using System;
using System.ServiceModel;

namespace Contract.Duplex.Client
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // Construct InstanceContext to handle messages on callback interface
            InstanceContext instanceContext = new InstanceContext(new CallbackHandler());

            // Create a client
            var cf = new DuplexChannelFactory<ICalculatorDuplex>(instanceContext,"WSDualHttpBinding_ICalculatorDuplex");
            var channel = cf.CreateChannel();

            double z1 = 4d;
            double z2 = 8d;

            Console.WriteLine("*** RoutingService with Message Filters ***\n");
            Console.WriteLine("Please hit any key to start: ");
            string command = Console.ReadLine();

            while (command != "exit")
            {
                ComplexNumberArithmetics(channel, z1, z2);

                Console.WriteLine("\nPlease hit any key to re-run OR enter 'exit' to exit.");
                command = Console.ReadLine();
            }

           ((IClientChannel)channel).Close();
        }

        private static void ComplexNumberArithmetics(ICalculatorDuplex channel, double z1, double z2)
        {
            try
            {
                Console.WriteLine("\n*** Contract.Duplex Testing ***\n");

                Console.WriteLine("AddTo:{0}",z2);
                channel.AddTo(z2);
                Console.WriteLine("SubtractFrom:{0}", z1);
                channel.SubtractFrom(z1);
                Console.WriteLine("SubtractFrom:{0}", z2);
                channel.MultiplyBy(4);
                Console.WriteLine("DivideBy:{0}", z2);
                channel.DivideBy(4);
            }
            catch (Exception fx)
            {
                Console.WriteLine(fx.Message);
            }
        }
    }
}