using System;
using Common;
using WcfExtensions;

namespace Server
{
    public class Service : IService
    {
        void IService.ThrowException(string typeName)
        {
            Type exceptionType = Type.GetType(typeName);
            if (exceptionType == null)
            {
                throw new ArgumentException(
                    string.Format("Cannot load type: {0}", typeName),
                    "typeName");
            }

            Exception exception = (Exception)Activator.CreateInstance(exceptionType, "Exception raised on the service side");

            // Test serialization of Data dictionary which cannot be handled by DataContractSerializer
            exception.Data.Add("exception", "data");

            Console.WriteLine("Throwing {0}...", exception.GetType().FullName);
            throw exception;
        }
    }
}
