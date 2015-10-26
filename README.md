# HQF.Tutorial.WCF
[![Build status](https://ci.appveyor.com/api/projects/status/rh94a4lbniy8iam8?svg=true)](https://ci.appveyor.com/project/huoxudong125/hqf-tutorial-wcf)  

##WCF 3.5 Vs WCF 4.0 Vs WCF 4.5
In this WCF tutorial, we will see the new and important features introduced in different versions of Windows Communication Foundation starting from WCF 3.5, 4.0 to WCF 4.5.

###What's New in WCF v3.5
Repost from [here](http://www.codeproject.com/Articles/745456/WCF-Vs-WCF-Vs-WCF)

- WCF support for **REST Style Services** by introducing Web programming model using rich features of HTTP instead of just a transport.
- In order to build **Workflow Services**, WCF 3.5 supports integration with WF (Windows Workflow Foundation).
- Using framework 3.5, now we can build** AJAX-enabled WCF Services**.
- It's possible to build services using WCF 3.5 that can be easily persisted and reloaded again. Such services are called **Durable Services**.
- To make WCF Services Interoperable, v3.5 is align with standards like WS-Trust, WS-SecurityPolicy, Web Service Reliable Messaging and Web Service Atomic Transaction etc.
- In order to process** Syndication feeds**, WCF now supports a strongly typed object model.
- For applications those are configured with a trust level other than Full are called **Partial Trust Applications**. Such Partial trust applications can use limited features of WCF now.  

Later with WCF v3.5 SP1, more features introduced

- Scalability in web-hosted applications. 
- Improvements with DataContract serializer.
- For Partial Trust application scenarios, further improved debugging support.
- Using ADO.NET Entity Framework entities in WCF Contracts.

###What's new in WCF v4.0

If we look into the new WCF 4.0 features, we can easily say that it's developer oriented. A number of new features that improve the productivity of a WCF developer.

- **WCF Configuration** has been simplified by introducing default endpoints, binding and behavior configuration. Now its not necessary to provide an endpoint while hosting a WCF service, it will be created automatically. And we can have configuration free services as well.
- **REST Improvements** like Help page and declarative HTTP caching.
- **Discovery** Alignment with standard like WS-Discovery protocol. A client can dynamically identify the service if a service endpoint address is changing.
- **Routing** A configurable routing service is introduced providing features like content-based routing, protocol bridging and error handling previously included with Dublin.  
- **Workflow v4.0** further enhances support for integrating WCF with WF. Now workflow service can be hosted from .xamlx file without .svc file.  
Hopefully, this post provides details clearly about what's released in WCF 3.5 and WCF 4.0. What's new released in WCF 4.5, please follow the below link.


###New Features in WCF v4.5
- **Simplified Generated Configuration** files, generated configuration file on client will only have non-default binding configuration. more…
- **Validating WCF Configuration** is now part of v4.5. While compiling if there are some validation errors with configuration file, it will be displayed as warnings in Visual Studio. more…
- WCF 4.5 support for **Task-based Asynchronous programming model**(TAP).
- **Contract First Development** is now supported. Only contract will be generated in service.cs, if we use SvcUtil.exe with “/ServiceContract” switch while generating proxy.
- **ASP.NET Compatibility Mode** changed to enable WCF service to participate in ASP.NET Pipeline just like ASMX services.
- **Tooltip and intellisense** support in Configuration files. more…
- **XmlDictionaryReaderQuotas** default values has been changed.
- v4.5 allows to create an endpoint that supports** Multiple Authentication Types**.
- Automatic** HTTPS endpoints** in IIS.
- Improvements in Streaming, support for **real asynchronous streaming**, no blockage of one thread per client as with previous versions.
- Support for **UDP transport**, using UDP one way messages are very fast.
- **BasicHttpsBinding**, new security configuration option.
- In order to have bidirectional communication with better performance like TCP, **WebSocket** is the right choice. WCF v4.5 introduces NetHttpBinding and NetHttpsBinding bindings for supporting WebSockets.
- **Single WSDL Document**, now we can create WSDL information in one file. more…
- IDN (**Internationalized Domain Names**) support means WCF Service can be called using IDN names by client.
- **Compression support** is now available for Binary Encoder in WCF 4.5 through CompressionFormat property.
- **ChannelFactory Cache**, WCF 4.5 now support for caching Channel Factories to reduce overhead associated while creating a ChannelFactory instance.
- WCF Service can be configured using config file or through code. In v4.5, **configuration through code** has been simplified by defining a public static method (i.e. configure) instead of creating a ServiceHostFactory.

##Binding Demos
[Binding Demos intuduction](/Binding/Readme.md)


##resources
[WCF 之旅](http://www.cnblogs.com/artech/archive/2007/09/15/893838.html)    
[Hosting Services](https://msdn.microsoft.com/en-us/library/ms730158(v=vs.110).aspx)   
[How to: Host a WCF Service in IIS](https://msdn.microsoft.com/en-us/library/ms733766(v=vs.110).aspx)    
