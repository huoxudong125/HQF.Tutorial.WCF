using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace Concurrency.Reentrant.Service.Interface
{
      [ServiceContract(Namespace = "http://www.artech.com/")]
       public interface ICalculatorCallback
       {
           [OperationContract]
           void ShowResult(double result);
       }
}
