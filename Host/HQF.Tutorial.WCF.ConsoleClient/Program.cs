using System;
using HQF.Tutorial.WCF.ConsoleClient.CalculatorService;

namespace HQF.Tutorial.WCF.ConsoleClient
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                using (var proxy = new CalculatorServiceClient())
                {
                    Console.WriteLine("x + y = {2} when x = {0} and y = {1}", 1, 2, proxy.Add(1, 2));
                    Console.WriteLine("x - y = {2} when x = {0} and y = {1}", 1, 2, proxy.Subtract(1, 2));
                    Console.WriteLine("x * y = {2} when x = {0} and y = {1}", 1, 2, proxy.Multiply(1, 2));
                    Console.WriteLine("x / y = {2} when x = {0} and y = {1}", 1, 2, proxy.Divide(1, 2));

                    
                }
            }
            catch (Exception ex)
            {
                
               Console.WriteLine("Error :\n {0}",ex.Message);
            }

            Console.Read();

        }
    }
}