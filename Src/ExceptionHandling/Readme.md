**Error Handling**

When using WCF in your service layer, you should handle exceptions properly so that the service consumer is communicated with the appropriate error message when an exception occurs. You can write exception blocks to handle runtime errors that occur in your WCF services. Handling exceptions in WCF is a bit tricky though primarily because you are constrained to sending .Net objects over the wire and your WCF service can only send out serialized data. You can actually handle exceptions in WCF in one of these three ways:

- FaultException -- You can leverage fault exceptions in WCF to transmit user friendly error messages when exceptions occur in your WCF service methods. Fault exceptions are thrown by a WCF service when an exception occurs at runtime.
- IErrorHandler -- you can take advantage of this interface to handle WCF exceptions globally.
- Using returnUnknownExceptionsAsFaults attribute -- You can set the returnUnknownExceptionsAsFaults attribute to "True" in the service behavior to ensure that your service method can raise an exception as a SOAP fault automatically.

You should include exception details in debug builds only. You should never disclose the stack trace or exception details for WCF services hosted in the production environments -- it is always a recommended practice to take advantage of Fault Contracts to transmit custom error messages that might occur in your WCF service.


## Demo
http://www.olegsych.com/2008/07/simplifying-wcf-using-exceptions-as-faults/