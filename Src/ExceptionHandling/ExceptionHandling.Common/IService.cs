using System;
using System.ServiceModel;

namespace Common
{
    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        void ThrowException(string typeName);
    }
}
