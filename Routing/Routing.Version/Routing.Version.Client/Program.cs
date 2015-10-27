using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using Routing.Version.Common;

namespace Routing.Version.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var cfV1 = new ChannelFactory<IComplexNumber>("firstVersionEndUsers");
            var channelV1 = cfV1.CreateChannel();

            var z1 = new ComplexNumber();
            var z2 = new ComplexNumber();

            z1.Real = 3D;
            z1.Imaginary = 4D;

            z2.Real = 4D;
            z2.Imaginary = 3D;

            Console.WriteLine("*** Service Versioning: : end-users of the first version ***\n");
            Console.WriteLine("\nPlease hit any key to run OR enter 'exit' to terminate.");
            string command = Console.ReadLine();

            while (command != "exit")
            {
                Console.WriteLine("Please hit any key to simulate firstVersionEndUsers: ");
                Console.ReadLine();

                using (new OperationContextScope((IContextChannel)channelV1))
                {
                    OperationContext.Current.OutgoingMessageHeaders.Add(MessageHeader.CreateHeader("Version", "http://custom/namespace", "v1.0"));
                    ComplexNumberArithmetics(channelV1, z1, z2);
                }

                Console.WriteLine("\nPlease hit any key to re-run OR enter 'exit' to terminate.");
                command = Console.ReadLine();
            }

          ((IClientChannel)channelV1).Close();
        }

        static string f(ComplexNumber z)
        {
            return (String.Format("({0}, {1})", z.Real, z.Imaginary));
        }

        static void ComplexNumberArithmetics(IComplexNumber channel, ComplexNumber z1, ComplexNumber z2)
        {
            try
            {
                Console.WriteLine("{0} + {1} = {2}", f(z1), f(z2), f(channel.Add(z1, z2)));
                Console.WriteLine("{0} - {1} = {2}", f(z1), f(z2), f(channel.Subtract(z1, z2)));
                Console.WriteLine("{0} * {1} = {2}", f(z1), f(z2), f(channel.Multiply(z1, z2)));
                Console.WriteLine("{0} / {1} = {2}", f(z1), f(z2), f(channel.Divide(z1, z2)));
            }
            catch (Exception fx)
            {
                Console.WriteLine(fx.Message);
            }
        }
    }
}
