using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Contract.AsyncPattern.Common
{
    [ServiceContract(Namespace = "http://hqfz.cnblogs.com/")]
    public interface IFileReader
    {
        [OperationContract(AsyncPattern = true)]
        IAsyncResult BeginRead(string fileName, AsyncCallback userCallback, object stateObject);
        string EndRead(IAsyncResult asynResult);
    }


}
