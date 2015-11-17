﻿using System.Threading;
using Concurrency.Reentrant.Service.Interface;

namespace Concurrency.Reentrant.Client
{
    public class CalculatorCallbackService : ICalculatorCallback
    {
        public void ShowResult(double result)
        {
            EventMonitor.Send(EventType.StartExecuteCallback);
            Thread.Sleep(10000);
            EventMonitor.Send(EventType.EndExecuteCallback);
        }
    }
}