**Error Handling**

When using WCF in your service layer, you should handle exceptions properly so that the service consumer is communicated with the appropriate error message when an exception occurs. You can write exception blocks to handle runtime errors that occur in your WCF services. Handling exceptions in WCF is a bit tricky though primarily because you are constrained to sending .Net objects over the wire and your WCF service can only send out serialized data. You can actually handle exceptions in WCF in one of these three ways:

- FaultException -- You can leverage fault exceptions in WCF to transmit user friendly error messages when exceptions occur in your WCF service methods. Fault exceptions are thrown by a WCF service when an exception occurs at runtime.
- IErrorHandler -- you can take advantage of this interface to handle WCF exceptions globally.
- Using returnUnknownExceptionsAsFaults attribute -- You can set the returnUnknownExceptionsAsFaults attribute to "True" in the service behavior to ensure that your service method can raise an exception as a SOAP fault automatically.

You should include exception details in debug builds only. You should never disclose the stack trace or exception details for WCF services hosted in the production environments -- it is always a recommended practice to take advantage of Fault Contracts to transmit custom error messages that might occur in your WCF service.

I am here with a small description of the way of exception handling in WCF. In this article, we will come to learn about:

1. Ways of handling exceptions in WCF.
2. When and what type of exception handling can be used.

Exception handling is critical to all applications for troubleshooting the unexpected problems in applications. The Windows Communication Framework (WCF) provides several options for handling exceptions in WCF services. This article discusses these approaches and describes the advantages and disadvantages of each. The following options are provided to handle exceptions in WCF:

1. Using returnUnknownExceptionsAsFaults:** Debugging Mode**
2. Using FaultException: **Best Option**.
3. Using IErrorHandler: **Only when the exception can't be handled by Fault**

**Exceptions inside a WCF Service**

Before describing the details of exception handling in WCF, let's explore what happens if we do not handle an exception inside the service. Consider a service with the CreateUser method as shown in the following:  

1. Public void CreateUser(User user)  
2. {  
3.     If(user.isValid())  
4.     {  
5.         //Create User  
6.     }  
7.     Else  
8.     {  
9.         Throw new ApplicationException(“User Inavalid.”);  
10.     }  
11. }    

In the preceding example, if the user is invalid, the ApplicationException is discarded and is no longer handled by the service. When this kind of exception occurs in a service, the communication channel between the service and its client is broken and the client receives the following generic exception message:   
  
**CommunicationException**: the server did not provide a meaningful reply; this might have been caused due to a contract mismatch, a premature session shutdown or an internal server error.   
  
The client is then unable to communicate with the server using the same channel. To avoid this, you need to handle the exception properly and raise the exception as a Soap Fault so that the communication channel between the client and the service does not break. We can use any of the exception handling methods provided by WCF to handle exceptions like this. The following sections describe each of the exception handling options in detail.   
  
**Using returnUnknownExceptionsAsFaults **  
WCF provides an option to raise the exception automatically as a Soap Fault. To enable this option, set returnUnknownExceptionsAsFaults to "True" in the service behavior setting in the application configuration file under the system.servicemodel section as shown below.   

1. &lt;behaviors&gt;  
2.    &lt;behavior name="MyServiceBehavior"  
3.        returnUnknownExceptionsAsFaults="True"&gt;  
4.    &lt;/behavior&gt;  
5. &lt;/behaviors&gt;    

**Note: **It's also possible to set this value programmatically using the ServiceBehaviour attribute, but the recommended approach is to set it using the config file.  
  
Once returnUnknownExceptionsAsFaults is set to "True", all the exceptions are wrapped as a Soap Fault before being sent to the clients. However, using this option exposes all the exceptions and their details to the client and the details might contain sensitive information like database schemas, connection strings and so on. We recommend that this option is only used when debugging in order to identify the exceptions raised by the services.  
  
When you use the returnUnknownExceptionsAsFaults option, the client will receive an UnknownFaultException instead of a CommuncationException. The resulting Soap Fault message is similar to that shown below:   

1. &lt;s:Fault&gt;  
2. &lt;s:Code&gt;  
3. &lt;s:Value&gt;s:Receiver&lt;/s:Value&gt;  
4. &lt;/s:Code&gt;  
5. &lt;s:Reason&gt;  
6. &lt;s:Text xml:lang="en-US"&gt;User Invalid&lt;/s:Text&gt;  
7. &lt;/s:Reason&gt;  
8. &lt;s:Detail&gt;  
9. &lt;z:anyType xmlns:d32="http://www.w3.org/2001/XMLSchema" i:type="d32:string" xmlns:i="http://www.w3.org/2001/XMLSchema-instance" xmlns:z="http://schemas.microsoft.com/2003/10/Serialization/"&gt;System.ApplicationException: Order Invalid at MySamples.ErrorSampleService.CreateOrder(Order order) in D:\SoapBox\WindowsCommunicationFoundation\TechnologySamples\Extensibility\ErrorHandling\CS\service\service.cs:line 40 ...(Stack Trace) &lt;/z:anyType&gt;  
10. &lt;/s:Detail&gt;  
11. &lt;/s:Fault&gt;    

Why should we not use the returnUnknownExceptionsAsFaults option in a production environment?  
  
As explained earlier, the returnUnknownExceptionsAsFaults option should only be used during debugging. It must not be used in a production environment since it might expose sensitive information, as an exception, to the client.   
  
**Using FaultException **  
  
FaultException is a new type of exception introduced in WCF to create a Soap Fault. Using the Fault Exception, you can wrap a .NET exception or any custom object into a Soap Fault. A FaultException example is shown below.   

1. public void CreateUserWithFaultException(User user)  
2. {  
3.     try  
4.     {  
5.         if (user.isValid())  
6.         {  
7.             //Create the order....  
8.         }  
9.         else  
10.         {  
11.            throw new ApplicationException("USer Invalid");  
12.         }  
13.     }  
14.     catch (ApplicationException ex)  
15.     {  
16.         throw new FaultException&lt;ApplicationException&gt;  
17.         (ex, new FaultReason(ex.Message), new FaultCode("Sender"));  
18.     }  
19. }    

**Note:** Always provide the appropriate details for a FaultReason and FaultCode when you are raise a FaultException. FaultCode is used to identify whether the fault is due to the client or server information and the Fault reason field can be used to send additional information about the exception.   
  
If the FaultContract contract is not specified, the clients receive all the exceptions as unknowfaultexceptions even if the exception is raised as a FaultException for an ApplicationException. FaultContract is an attribute in WCF used to specify the type of exception that can be raised by that service. The FaultContract can be specified along with the operation contract as shown as below:  

1. [OperationContract()]  
2. [FaultContract(typeof(ApplicationException))]  
3. void CreateUserWithFaultException(User user);    

Since the FaultContract is specified in the service, the service definition file (wsdl) will contain this information along with the schema of the ApplicationException. The Client can access the ApplicationException from the details of the Soap Fault as shown below.   

1. using (ErrorSampleServiceProxy proxy = new ErrorSampleServiceProxy())  
2. {  
3.     try  
4.     {  
5.        Console.WriteLine("Calling Create User");  
6.        User user = new User();  
7.        proxy.CreateUser(user);  
8.        Console.WriteLine("CreateUser Executed Successfully");  
9.     }  
10.     catch (FaultException&lt;ApplicationException&gt;e)  
11.     {  
12.        Console.WriteLine("FaultException&lt;&gt;: " + e.Detail.GetType().Name + " - " + e.Detail.Message);  
13.     }  
14.     catch (FaultException e)  
15.     {  
16.         Console.WriteLine("FaultException: " + e.GetType().Name + " - " + e.Message);  
17.     }  
18.     catch (Exception e)  
19.     {  
20.        Console.WriteLine("EXCEPTION: " + e.GetType().Name + " - " + e.Message);  
21.     }  
22. }    

The Detail property in the FaultException has ApplicationException. Similar to ApplicationException, you can send any custom data object inside a Soap Fault element.   
  
It is a good practice to send a custom data object with required parameters to the client instead of sending the Exception object since it might have unnecessary details, that might not be required for the client. For example, instead of raising the FaultException of the ApplicationException, you can raise the FaultException of a custom object as given below:  

1. public void CreateUserWithFaultMsg(User user)  
2. {  
3.     try  
4.     {  
5.         if (user.isValid())  
6.         {  
7.             //Create the user....  
8.         }  
9.         else  
10.         {  
11.             throw new ApplicationException("User Invalid");  
12.         }  
13.     }  
14.     catch (Exception ex)  
15.     {  
16.         CustomExpMsg customMsg = new CustomExpMsg(ex.Message);  
17.         throw new FaultException&lt;CustomExpMsg&gt;(customMsg, new  
18.         FaultReason(customMsg.ErrorMsg), new FaultCode("Sender"));  
19.     }  
20. }     

And the custommessage class would be as in the following.  

1. DataContract]  
2. public class CustomExpMsg  
3. {  
4.     public CustomExpMsg()  
5.     {  
6.         this.ErrorMsg = "Service encountered an error;  
7.     }  
8.     public CustomExpMsg(string message)  
9.     {  
        this.ErrorMsg = message;  
10.     }  
11.     private int errorNumber;  
12.     [DataMember(Order = 0)]  
13.     public int ErrorNumber  
14.     {  
15.         get { return errorNumber; }  
16.         set { errorNumber = value; }  
17.     }  
18.     private string errrorMsg;  
19.     [DataMember(Order = 1)]  
20.     public string ErrorMsg  
21.     {  
22.       get { return errrorMsg; }  
23.       set { errrorMsg = value; }  
24.     }  
25.     private string description;  
26.     [DataMember(Order = 2)]  
27.     public string Description  
28.     {  
29.        get { return description; }  
30.        set { description = value; }  
31.     }  
32. }    

**Using IErrorHandler**  
  
The last approach for exception handling in WCF is the IErrorHandler approach. With this approach, you can intercept all the exceptions raised inside a service using IErrorHandler. If you implement IErrorHandler interface methods in your service, you can intercept all the exceptions and you can "log and suppress" the exceptions or you can “log and throw” them as a FaultException. The structure of IErrorHandler is shown below.   

1. public interface IErrorHandler  
2. {  
3.     bool HandleError(Exception error, MessageFault fault);  
4.     void ProvideFault(Exception error, ref MessageFault fault, ref string faultAction);  
5. }     

If you want to suppress the fault message, just implement the HandlerError method and return false. If you want to raise FaultException instead of suppressing, then implement the ProvideFault method to provide the MessageFault value. IErrorHandler approach should be used with care, since it handles all the exceptions inside the service in a generic way. It is always better to handle the exception where it occurred instead of going with the generic exception handler like IErrorHandler.  
  
**Summary **  
Since there are many options to handle exceptions in the WCF, you need to choose the best option based on your requirements. You can use the returnUnknownExceptionsAsFaults option only for debugging and not in a production environment. In the case of interoperating applications on various platforms, you should use the FaultException approach with a custom data object. For WCF applications you can use the FaultException approach with a .Net exception type, since both ends of applications can understand .Net exception types.  
  
The IErrorHandler approach can be used only for the exception that cannot be handled using the faultException approach.




## Demo
http://www.olegsych.com/2008/07/simplifying-wcf-using-exceptions-as-faults/