using System;
using System.ServiceModel;
using WcfExtensions;

namespace Common
{
    [ServiceContract]
    [ExceptionMarshallingBehavior]
    public interface IAttributedService: IService
    {
    }
}
