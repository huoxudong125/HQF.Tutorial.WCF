using System;
using System.ServiceModel;
using Binding.UdpBinding.Common;

namespace Binding.UdpBinding.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var cf = new ChannelFactory<IStockService>("UdpBinding_IStockService");
            var channel = cf.CreateChannel();

            Console.WriteLine("*** One-Way Multicast Demo using UdpBinding ***\n");
            Console.WriteLine("Please any key to start multicasting ...");
            string command = Console.ReadLine();

            while (true)
            {
                var stock = GetStockDetails();
                channel.SendStockDetail(stock);

                Console.WriteLine("Details of the Stock: {0} has been sent.", stock.Name);
                System.Threading.Thread.Sleep(3000);
            }

           ((IClientChannel)channel).Close();
        }

        static Stock GetStockDetails()
        {
            Random rnd = new Random();

            Stock stock = new Stock();

            stock.Name = GetStockName();
            stock.Price = rnd.Next(1, 999) + rnd.NextDouble();

            return stock;
        }

        static string GetStockName()
        {
            char[] charArr = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

            string stockName = string.Empty;
            Random rnd = new Random();

            for (int n = 0; n < 4; n++)
                stockName += charArr.GetValue(rnd.Next(1, charArr.Length));

            return stockName;
        }
    }
}
