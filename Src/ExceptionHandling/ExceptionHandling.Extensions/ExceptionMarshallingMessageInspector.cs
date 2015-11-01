﻿using System;
using System.IO;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Xml;

namespace WcfExtensions
{
    public class ExceptionMarshallingMessageInspector : IClientMessageInspector
    {
        void IClientMessageInspector.AfterReceiveReply(ref Message reply, object correlationState)
        {
            if (reply.IsFault)
            {
                // Create a copy of the original reply to allow default processing of the message
                MessageBuffer buffer = reply.CreateBufferedCopy(Int32.MaxValue);
                Message copy = buffer.CreateMessage();  // Create a copy to work with
                reply = buffer.CreateMessage();         // Restore the original message

                object faultDetail = ReadFaultDetail(copy);
                Exception exception = faultDetail as Exception;
                if (exception != null)
                {
                    throw exception;
                }
            }
        }

        object IClientMessageInspector.BeforeSendRequest(ref Message request, IClientChannel channel)
        {
            return null;
        }

        private static object ReadFaultDetail(Message reply)
        {
            const string detailElementName = "Detail";

            using (XmlDictionaryReader reader = reply.GetReaderAtBodyContents())
            {
                // Find <soap:Detail>
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element && reader.LocalName == detailElementName)
                    {
                        break;
                    }
                }

                // Did we find it?
                if (reader.NodeType != XmlNodeType.Element || reader.LocalName != detailElementName)
                {
                    return null;
                }

                // Move to the contents of <soap:Detail>
                if (!reader.Read())
                {
                    return null;
                }

                // Deserialize the fault
                NetDataContractSerializer serializer = new NetDataContractSerializer();
                try
                {
                    return serializer.ReadObject(reader);
                }
                catch (FileNotFoundException)
                {
                    // Serializer was unable to find assembly where exception is defined 
                    return null;
                }
            }
        }
    }
}
