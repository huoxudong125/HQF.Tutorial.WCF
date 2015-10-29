using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using Routing.Version.CommonExtend;

namespace Routing.Version.ClientV2
{
    class Program
    {
        static void Main(string[] args)
        {
            var cfV2 = new ChannelFactory<IComplexNumber>("secondVersionEndUsers");
            var channelV2 = cfV2.CreateChannel();

            var z1 = new ComplexNumber();
            var z2 = new ComplexNumber();

            z1.Real = 1D;
            z1.Imaginary = 2D;

            z2.Real = 2D;
            z2.Imaginary = 1D;

            Console.WriteLine("*** Service Versioning: end-users of the second version ***\n");
            Console.WriteLine("\nPlease hit any key to run OR enter 'exit' to terminate.");
            string command = Console.ReadLine();

            while (command != "exit")
            {
                Console.WriteLine("Please hit any key to simulate secondVersionEndUsers: ");
                Console.ReadLine();

                using (new OperationContextScope((IContextChannel)channelV2))
                {
                    OperationContext.Current.OutgoingMessageHeaders.Add(MessageHeader.CreateHeader("Version", "http://custom/namespace", "v2.0"));
                    ComplexNumberArithmetics(channelV2, z1, z2);
                }

                Console.WriteLine("\nPlease hit any key to re-run OR enter 'exit' to terminate.");
                command = Console.ReadLine();
            }

           ((IClientChannel)channelV2).Close();
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
                Console.WriteLine("Conjugate[{0}] = {1}", f(z1), f(channel.Conjugate(z1)));
                Console.WriteLine("Reciprocal[{0}] = {1}", f(z1), f(channel.Reciprocal(z1)));
                Console.WriteLine("Modulus[{0}] = {1}", f(z1), channel.Modulus(z1));
                Console.WriteLine("Argument[{0}] = {1} Radians", f(z1), channel.Argument(z1));
            }
            catch (Exception fx)
            {
                Console.WriteLine(fx.Message);
            }
        }
    }
}
