﻿using System;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace WcfExtensions
{
    public class ExceptionMarshallingErrorHandler : IErrorHandler
    {
        bool IErrorHandler.HandleError(Exception error)
        {
            if (error is FaultException)
            {
                return false; // Let WCF do normal processing
            }
            else
            {
                return true; // Fault message is already generated
            }
        }

        void IErrorHandler.ProvideFault(Exception error, MessageVersion version, ref Message fault)
        {
            if (error is FaultException)
            {
                // Let WCF do normal processing
            }
            else
            {
                // Generate fault message manually
                MessageFault messageFault = MessageFault.CreateFault(
                    new FaultCode("Sender"),
                    new FaultReason(error.Message),
                    error,
                    new NetDataContractSerializer());
                fault = Message.CreateMessage(version, messageFault, null);
            }
        }
    }
}
