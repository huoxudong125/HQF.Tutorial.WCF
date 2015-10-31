﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Contract.AsyncPattern.Client.ServiceReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://hqfz.cnblogs.com/", ConfigurationName="ServiceReference.IFileReader")]
    public interface IFileReader {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://hqfz.cnblogs.com/IFileReader/Read", ReplyAction="http://hqfz.cnblogs.com/IFileReader/ReadResponse")]
        string Read(string fileName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://hqfz.cnblogs.com/IFileReader/Read", ReplyAction="http://hqfz.cnblogs.com/IFileReader/ReadResponse")]
        System.Threading.Tasks.Task<string> ReadAsync(string fileName);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IFileReaderChannel : Contract.AsyncPattern.Client.ServiceReference.IFileReader, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class FileReaderClient : System.ServiceModel.ClientBase<Contract.AsyncPattern.Client.ServiceReference.IFileReader>, Contract.AsyncPattern.Client.ServiceReference.IFileReader {
        
        public FileReaderClient() {
        }
        
        public FileReaderClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public FileReaderClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public FileReaderClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public FileReaderClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string Read(string fileName) {
            return base.Channel.Read(fileName);
        }
        
        public System.Threading.Tasks.Task<string> ReadAsync(string fileName) {
            return base.Channel.ReadAsync(fileName);
        }
    }
}
