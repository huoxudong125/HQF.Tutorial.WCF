using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Routing.Multicast.Common;

namespace Routing.Multicast.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var cf = new ChannelFactory<IStockService>("stockDetails");
            var channel = cf.CreateChannel();

            Console.WriteLine("*** Multicasting using RoutingService ***\n");
            Console.WriteLine("Please hit any key to start: ");
            string command = Console.ReadLine();

            while (command != "exit")
            {
                var stock = GetStockDetails();
                channel.SendStockDetail(stock);

                Console.WriteLine("Details of the Stock: {0} has been multicasted.", stock.Name);
                System.Threading.Thread.Sleep(3000);
            }

            ((IClientChannel)channel).Close();
        }

        static Stock GetStockDetails()
        {
            Stock stock = new Stock();

            Random rnd = new Random();

            stock.Name = GetStockName();
            stock.StockType = GetStockType();
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

        static string GetStockType()
        {
            string[] stockTypes = {
                                   "Large Cap",
                                   "Mid Cap",
                                   "Small Cap",
                                   "Diversified",
                                   "Index",
                                   "Sectoral ",
                                   "ELSS"
                             };

            var rnd = new Random();
            var index = rnd.Next(0, 6);

            return stockTypes[index];
        }

        static double GetStockPrice()
        {
            Random rnd = new Random();

            return (rnd.Next(1, 999) + rnd.NextDouble());
        }
    }
}
