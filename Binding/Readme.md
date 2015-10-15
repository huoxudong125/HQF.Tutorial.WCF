
#WCF Binding Demo

##Http Binding

##wsHttpBinding

##Net TCP Binding

##Net UDP Binding

##MSMQ Binding
The `NetMsmqBinding` binding provides support for queuing by using Message Queuing (MSMQ) as a transport and enables support for loosely-coupled applications, failure isolation, load leveling and disconnected operations. For a discussion of these features, see [Queues Overview](https://msdn.microsoft.com/en-us/library/ms733789.aspx).  

This is one of the system-provided bindings provided by Windows Communication Foundation (WCF). The recommended procedure is to define the binding using configuration values and not to use a code-based approach, except in certain advanced scenarios where configuration values must be set as a service is initialized.

- [NetMsmqBinding Class in MSDN](https://msdn.microsoft.com/en-us/library/system.servicemodel.netmsmqbinding.aspx)
- [A beginner's guide to queuing with WCF and MSMQ showing bi-directional client correspondance](http://www.codeproject.com/Articles/520323/A-beginners-guide-to-queuing-with-WCF-and-MSMQ-sho)
- [Creating a WCF Service with MSMQ Communication and Certificate Security](http://www.codeproject.com/Articles/326909/Creating-a-WCF-Service-with-MSMQ-Communication-and)
  