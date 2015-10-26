using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Routing.Common;

namespace Routing.Base.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var cf = new ChannelFactory<IComplexNumber>("BasicHttpBinding_IComplexNumber");
            var channel = cf.CreateChannel();

            var z1 = new Complex();
            var z2 = new Complex();

            z1.Real = 3D;
            z1.Imaginary = 4D;

            z2.Real = 2D;
            z2.Imaginary = -2D;

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

        static string f(Complex z)
        {
            return (String.Format("({0}, {1})", z.Real, z.Imaginary));
        }

        static void ComplexNumberArithmetics(IComplexNumber channel, Complex z1, Complex z2)
        {
            try
            {
                Console.WriteLine("\n*** Complex Number Arithmetics ***\n");

                Console.WriteLine("{0} + {1} = {2}", f(z1), f(z2), f(channel.Add(z1, z2)));
                Console.WriteLine("{0} - {1} = {2}", f(z1), f(z2), f(channel.Subtract(z1, z2)));
                Console.WriteLine("{0} * {1} = {2}", f(z1), f(z2), f(channel.Multiply(z1, z2)));
                Console.WriteLine("{0} / {1} = {2}", f(z1), f(z2), f(channel.Divide(z1, z2)));
                Console.WriteLine("Conjugate[{0}] = {1}", f(z1), f(channel.Conjugate(z1)));
                Console.WriteLine("Conjugate[{0}] = {1}", f(z2), f(channel.Conjugate(z2)));
                Console.WriteLine("Recipocal[{0}] = {1}", f(z1), f(channel.Recipocal(z1)));
                Console.WriteLine("Recipocal[{0}] = {1}", f(z2), f(channel.Recipocal(z2)));
                Console.WriteLine("Modulus[{0}] = {1}", f(z1), channel.Modulus(z1));
                Console.WriteLine("Modulus[{0}] = {1}", f(z2), channel.Modulus(z2));
                Console.WriteLine("Argument[{0}] = {1} Radians", f(z1), channel.Argument(z1));
                Console.WriteLine("Argument[{0}] = {1} Radians", f(z2), channel.Argument(z2));
            }
            catch (Exception fx)
            {
                Console.WriteLine(fx.Message);
            }
        }
    }
}
