using System;

namespace Routing.Multicast.Common
{
    public class StockService : IStockService
    {
        public void SendStockDetail(Stock stock)
        {
            Console.WriteLine(string.Format("Stock Name: {0}, Stock Type: {1}, Price: ${2:000.00}", stock.Name, stock.StockType, stock.Price));
        }
    }
}
