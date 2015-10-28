using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using HQF.Tutorial.WCF.Contract;
using HQF.Tutorial.WCF.Contract.Interface;

namespace HQF.Tutorial.WCF.ConsoleHost
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            using (var host = new ServiceHost(typeof (CalculatorService)))
            {
                host.AddServiceEndpoint(typeof (ICalculator), new WSHttpBinding(),
                    "http://127.0.0.1:9999/calculatorservice");

                if (host.Description.Behaviors.Find<ServiceMetadataBehavior>() == null)
                {
                    var behavior = new ServiceMetadataBehavior();
                    behavior.HttpGetEnabled = true;
                    behavior.HttpGetUrl = new Uri("http://127.0.0.1:9999/calculatorservice/metadata");
                    host.Description.Behaviors.Add(behavior);
                }

                host.Opened += delegate { Console.WriteLine("CalculaorService已经启动，按任意键终止服务！"); };

                host.Open();
                Console.Read();
            }
        }
    }
}