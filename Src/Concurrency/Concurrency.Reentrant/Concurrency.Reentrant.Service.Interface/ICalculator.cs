using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Concurrency.Reentrant.Service.Interface
{
    [ServiceContract(Namespace="http://hqf.cnblogs.com/",CallbackContract =typeof(ICalculatorCallback))]
    public interface ICalculator
    {
        [OperationContract]
        void Add(double x, double y);
    }
}
