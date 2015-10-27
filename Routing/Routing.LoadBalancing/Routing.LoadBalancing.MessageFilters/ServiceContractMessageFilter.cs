using System;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;

namespace Routing.LoadBalancing.MessageFilters
{
    public class ServiceContractMessageFilter : MessageFilter
    {
        readonly string _serviceContractName;

        public ServiceContractMessageFilter(string serviceContractName)
        {
            if (string.IsNullOrEmpty(serviceContractName)) { throw new ArgumentNullException("serviceContractName"); }

            this._serviceContractName = serviceContractName;
        }

        public override bool Match(Message message)
        {
            return message.Headers.Action.Contains(_serviceContractName);
        }

        public override bool Match(MessageBuffer buffer)
        {
            return buffer.CreateMessage().Headers.Action.Contains(_serviceContractName);
        }
    }
}
