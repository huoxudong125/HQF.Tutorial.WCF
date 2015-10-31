using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Contract.AsyncPattern.Client.ServiceReference;

namespace Contract.AsyncPattern.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var proxy =new FileReaderClient())
            {
             
                Console.WriteLine("文件内容：{0}", proxy.Read("HelloWorld.txt"));
            }
            Console.Read();
        }
    }
}
