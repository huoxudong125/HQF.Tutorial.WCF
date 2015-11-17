using Concurrency.Single.Common.Interface;
using System.ServiceModel;
using System.Threading;

namespace Concurrency.Single.Common
{
    [ServiceBehavior(UseSynchronizationContext = false,ConcurrencyMode=ConcurrencyMode.Single)]
    public class CalculatorService : ICalculator
    {
        public double Add(double x, double y)
        {
            EventMonitor.Send(EventType.StartExecute);
            Thread.Sleep(5000);
            var result = x + y;
            EventMonitor.Send(EventType.EndExecute);
            return result;
        }
    }
}