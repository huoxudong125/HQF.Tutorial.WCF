using System;

namespace Binding.UdpBinding.Common
{
    public class StockService : IStockService
    {
        public void SendStockDetail(Stock stock)
        {
            Console.WriteLine("Stock Name: {0}, Price: ${1:000.00}", stock.Name, stock.Price);
        }
    }
}
