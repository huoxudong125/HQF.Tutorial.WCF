using System;
using System.Diagnostics;
using System.ServiceModel;
using System.ServiceModel.Description;
using Common;
using WcfExtensions;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            // Redirect debug output to console
            Debug.Listeners.Add(new TextWriterTraceListener(Console.Out));

            // Create channel factory
            IService service = null;

            Console.WriteLine();
            Console.WriteLine("Press one of the following keys to configure the channel:");
            Console.WriteLine("   'a' to use attributes");
            Console.WriteLine("   'c' to use configuration file");
            Console.WriteLine("   'p' to configure factory programmatically");
            Console.WriteLine("   Esc to quit");
            
            var key = Console.ReadKey().Key;
            switch (key)
            {
                case ConsoleKey.A:
                    service = ConfigureChannelUsingAttributes();
                    break;
                case ConsoleKey.C:
                    service = ConfigureChannelUsingConfigFile();
                    break;
                case ConsoleKey.P:
                    service = ConfigureChannelProgrammatically();
                    break;
                default:
                    Console.WriteLine("Unexpected key pressed");
                    return;
            }

            // Call the service 
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Press 'e' to call IService.ThrowException or ESC to quit");
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.E:
                        CallThrowException(service);
                        break;
                    case ConsoleKey.Escape:
                        return;
                }
            }
        }

        private static IService ConfigureChannelProgrammatically()
        {
            Console.WriteLine();
            Console.WriteLine("Creating channel factory programmatically...");
            ChannelFactory<IService> factory = new ChannelFactory<IService>(
                new NetTcpBinding(), 
                new EndpointAddress("net.tcp://localhost:9001/Service"));
            factory.Endpoint.Behaviors.Add(new ExceptionMarshallingBehavior());
            // or factory.Endpoint.Contract.Behaviors.Add(new ExceptionMarshallingBehavior());
            IService channel = factory.CreateChannel();
            return channel;
        }

        private static IService ConfigureChannelUsingAttributes()
        {
            Console.WriteLine();
            Console.WriteLine("Creating channel factory programmatically...");
            ChannelFactory<IAttributedService> factory = new ChannelFactory<IAttributedService>(
                new NetTcpBinding(),
                new EndpointAddress("net.tcp://localhost:9001/Service"));
            return factory.CreateChannel();
        }

        private static IService ConfigureChannelUsingConfigFile()
        {
            Console.WriteLine();
            Console.WriteLine("Creating channel factory using configuration file...");
            ChannelFactory<IService> factory = new ChannelFactory<IService>("MyEndpoint");
            return factory.CreateChannel();
        }

        static void CallThrowException(IService service)
        {
            CallThrowException(service, typeof(Exception).FullName);
            CallThrowException(service, typeof(ApplicationException).FullName);
            CallThrowException(service, "Server.ServerException");
        }

        static void CallThrowException(IService service, string typeName)
        {
            try
            {
                Console.WriteLine();
                Console.WriteLine("Calling IService.ThrowException(\"{0}\")...", typeName);
                service.ThrowException(typeName);
            }
            catch (Exception e)
            {
                Console.WriteLine("Caught {0}", e.GetType().FullName);
            }
        }
    }
}
