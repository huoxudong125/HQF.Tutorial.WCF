﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Routing.LoadBalancing.Common;

namespace Routing.LoadBalancing.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var cfAll = new ChannelFactory<IComplexNumber>("thirdTypeEndUsers");
            var cfBinary = new ChannelFactory<IBinaryOperation>("firstTypeEndUsers");
            var cfUnary = new ChannelFactory<IUnaryOperation>("secondTypeEndUsers");

            var channelAll = cfAll.CreateChannel();
            var channelBinary = cfBinary.CreateChannel();
            var channelUnary = cfUnary.CreateChannel();

            var z1 = new Complex();
            var z2 = new Complex();

            z1.Real = 3D;
            z1.Imaginary = 4D;

            z2.Real = 1D;
            z2.Imaginary = -2D;

            Console.WriteLine("*** Protocol Bridging ***\n");
            Console.WriteLine("\nPlease hit any key to run OR enter 'exit' to exit.");
            string command = Console.ReadLine();

            while (command != "exit")
            {
                Console.WriteLine("Please hit any key to simulate  first Type End-Users: ");
                Console.ReadLine();
                ComplexNumberBinaryArithmetics(channelBinary, z1, z2);

                Console.WriteLine("Please hit any key to simulate  second Type End-Users: ");
                Console.ReadLine();
                ComplexNumberUnaryArithmetics(channelUnary, z1);

                Console.WriteLine("Please hit any key to simulate  third Type End-Users: ");
                Console.ReadLine();
                ComplexNumberArithmetics(channelAll, z1, z2);

                Console.WriteLine("\nPlease hit any key to re-run OR enter 'exit' to exit.");
                command = Console.ReadLine();
            }

            ((IClientChannel)channelAll).Close();
            ((IClientChannel)channelBinary).Close();
            ((IClientChannel)channelUnary).Close();
        }

        static string f(Complex z)
        {
            return (String.Format("({0}, {1})", z.Real, z.Imaginary));
        }

        static void ComplexNumberArithmetics(IComplexNumber channel, Complex z1, Complex z2)
        {
            try
            {
                Console.WriteLine("{0} + {1} = {2}", f(z1), f(z2), f(channel.Add(z1, z2)));
                Console.WriteLine("{0} - {1} = {2}", f(z1), f(z2), f(channel.Subtract(z1, z2)));
                Console.WriteLine("{0} * {1} = {2}", f(z1), f(z2), f(channel.Multiply(z1, z2)));
                Console.WriteLine("{0} / {1} = {2}", f(z1), f(z2), f(channel.Divide(z1, z2)));
                Console.WriteLine("Conjugate[{0}] = {1}", f(z1), f(channel.Conjugate(z1)));
                Console.WriteLine("Recipocal[{0}] = {1}", f(z1), f(channel.Reciprocal(z1)));
                Console.WriteLine("Modulus[{0}] = {1}", f(z1), channel.Modulus(z1));
                Console.WriteLine("Argument[{0}] = {1} Radians", f(z1), channel.Argument(z1));
            }
            catch (Exception fx)
            {
                Console.WriteLine(fx.Message);
            }
        }

        static void ComplexNumberBinaryArithmetics(IBinaryOperation channel, Complex z1, Complex z2)
        {
            try
            {
                Console.WriteLine("\n*** Complex Number Binary Arithmetics ***\n");

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

        static void ComplexNumberUnaryArithmetics(IUnaryOperation channel, Complex z)
        {
            try
            {
                Console.WriteLine("\n*** Complex Number Unary Arithmetics ***\n");

                Console.WriteLine("Conjugate[{0}] = {1}", f(z), f(channel.Conjugate(z)));
                Console.WriteLine("Reciprocal[{0}] = {1}", f(z), f(channel.Reciprocal(z)));
                Console.WriteLine("Modulus[{0}] = {1}", f(z), channel.Modulus(z));
                Console.WriteLine("Argument[{0}] = {1} Radians", f(z), channel.Argument(z));
            }
            catch (Exception fx)
            {
                Console.WriteLine(fx.Message);
            }
        }
    }
}
