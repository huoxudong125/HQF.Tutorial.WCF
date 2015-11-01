using System;
using System.Diagnostics;
using System.ServiceModel;
using System.ServiceModel.Description;
using Common;
using WcfExtensions;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            // Redirect debug output to console
            Debug.Listeners.Add(new TextWriterTraceListener(Console.Out));

            // Create and open a ServiceHost
            Console.WriteLine();
            Console.WriteLine("Press one of the following keys to configure ServiceHost:");
            Console.WriteLine("    'a' to use attributes");
            Console.WriteLine("    'c' to use configuration file");
            Console.WriteLine("    'p' to configure the host programmatically");
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            switch (keyInfo.Key)
            {
                case ConsoleKey.A:
                    ConfigureHostUsingAttributes();
                    break;
                case ConsoleKey.C:
                    ConfigureHostUsingConfigFile();
                    break;
                case ConsoleKey.P:
                    ConfigureHostProgrammatically();
                    break;
                default:
                    Console.WriteLine("Unexpected key pressed");
                    return;
            }

            // Wait for the user to press Escape
            do
            {
                Console.WriteLine();
                Console.WriteLine("Press Esc to quit");
            }
            while (Console.ReadKey().Key != ConsoleKey.Escape);
        }

        private static void ConfigureHostProgrammatically()
        {
            Console.WriteLine();
            Console.WriteLine("Configuring host programmatically...");
            ServiceHost host = new ServiceHost(typeof(ProgrammaticService));
            ServiceEndpoint endpoint = host.AddServiceEndpoint(typeof(IService), new NetTcpBinding(), new Uri("net.tcp://localhost:9001/Service"));
            endpoint.Behaviors.Add(new ExceptionMarshallingBehavior());
            // or host.Description.Behaviors.Add(new ExceptionMarshallingBehavior());
            // or endpoint.Contract.Behaviors.Add(new ExceptionMarshallingBehavior());
            host.Open();
        }

        private static void ConfigureHostUsingAttributes()
        {
            Console.WriteLine();
            Console.WriteLine("Configuring host using attributes...");
            ServiceHost host = new ServiceHost(typeof(AttributedService));
            host.AddServiceEndpoint(typeof(IService), new NetTcpBinding(), new Uri("net.tcp://localhost:9001/Service"));
            host.Open();
        }

        private static void ConfigureHostUsingConfigFile()
        {
            Console.WriteLine();
            Console.WriteLine("Configuring host using configuration file...");
            ServiceHost host = new ServiceHost(typeof(Service));
            host.Open();
        }
    }
}
