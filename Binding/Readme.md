
#WCF Binding Demo

##Http Binding

##wsHttpBinding

##Net TCP Binding

##Net UDP Binding
###Intruduction
**WCF 4.5** came with a support of **User Datagram Protocol (UDP)**. 
**UDP** is a connectionless, lightweight and unreliable protocol, and sometimes called "send and pray" because there is no dialog between the sender and receiver. 
If the receiver does not get a message, then the sender will never know about the same. But **UDP** is very efficient when there is little chance of errors. It is important to note that, UDP messages are not routed across the networkboundaries and thus can only be used within a network. 
**UDP** is faster than TCP because there is no error-checking for packets.WCF 4.5 offers a new binding UdpBinding based on this protocol. As **UDP** supports multicasting, so now one can write multicasting applications using this binding. This transport is useful in cases where a sender needs to send out small messages to multiple receivers simultaneously without ensuring whether any specific message is actually received or lost. So here **speed is more important than reliability**.  

Please note that,  **I've used multicast address: 224.1.1.1:4000 in the base address of the service**. It is important to note that multicast addresses must be in the range of `224.0.0.0` to `239.255.255.255`. This address range refers class D in the context of IPv4. All addresses of this range have a binary pattern begin with 1110. Addresses of this range are reserved for special purposes. So free uses on this range are limited.

###Features of UdpBinding
- Interoperability - .NET application. It can be achieved by implementing the standard SOAP-over-UDP specification which this binding implements.
- Security - None
- Session – None
- Transactions – None
- Duplex – NA
- Encoding – Text
- Streaming – No
- Message - Request/Response and One Way
- One-Way messages are true one-way unidirectional calls. No exception would be thrown by the client if the service isn't available
###Limitations of UdpBinding
- No IIS/WAS activation support as there is no UDP shared listener for WAS.
- No UDP multicast support on Azure.

##MSMQ Binding
The `NetMsmqBinding` binding provides support for queuing by using Message Queuing (MSMQ) as a transport and enables support for loosely-coupled applications, failure isolation, load leveling and disconnected operations. For a discussion of these features, see **[Queues Overview](https://msdn.microsoft.com/en-us/library/ms733789.aspx)**.  

This is one of the system-provided bindings provided by Windows Communication Foundation (WCF). The recommended procedure is to define the binding using configuration values and not to use a code-based approach, except in certain advanced scenarios where configuration values must be set as a service is initialized.

- [NetMsmqBinding Class in MSDN](https://msdn.microsoft.com/en-us/library/system.servicemodel.netmsmqbinding.aspx)
- [A beginner's guide to queuing with WCF and MSMQ showing bi-directional client correspondance](http://www.codeproject.com/Articles/520323/A-beginners-guide-to-queuing-with-WCF-and-MSMQ-sho)
- [Creating a WCF Service with MSMQ Communication and Certificate Security](http://www.codeproject.com/Articles/326909/Creating-a-WCF-Service-with-MSMQ-Communication-and)

###MSMQ  Mail
[Dennis van der Stelt provide a good sample on WCF + MSMQ.](http://bloggingabout.net/blogs/dennis/archive/2008/02/28/wcf-and-msmq.aspx)

##RabbitMQ
[RabbitMQ WCF Binding](https://www.rabbitmq.com/dotnet-api-guide.html)