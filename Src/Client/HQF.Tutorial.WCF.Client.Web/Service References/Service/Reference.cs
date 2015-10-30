﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HQF.Tutorial.WCF.Client.Web.Service {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://www.itelite.com/", ConfigurationName="Service.CalculatorService")]
    public interface CalculatorService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.itelite.com/CalculatorService/Add", ReplyAction="http://www.itelite.com/CalculatorService/AddResponse")]
        double Add(double x, double y);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.itelite.com/CalculatorService/Add", ReplyAction="http://www.itelite.com/CalculatorService/AddResponse")]
        System.Threading.Tasks.Task<double> AddAsync(double x, double y);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.itelite.com/CalculatorService/Subtract", ReplyAction="http://www.itelite.com/CalculatorService/SubtractResponse")]
        double Subtract(double x, double y);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.itelite.com/CalculatorService/Subtract", ReplyAction="http://www.itelite.com/CalculatorService/SubtractResponse")]
        System.Threading.Tasks.Task<double> SubtractAsync(double x, double y);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.itelite.com/CalculatorService/Multiply", ReplyAction="http://www.itelite.com/CalculatorService/MultiplyResponse")]
        double Multiply(double x, double y);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.itelite.com/CalculatorService/Multiply", ReplyAction="http://www.itelite.com/CalculatorService/MultiplyResponse")]
        System.Threading.Tasks.Task<double> MultiplyAsync(double x, double y);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.itelite.com/CalculatorService/Divide", ReplyAction="http://www.itelite.com/CalculatorService/DivideResponse")]
        double Divide(double x, double y);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.itelite.com/CalculatorService/Divide", ReplyAction="http://www.itelite.com/CalculatorService/DivideResponse")]
        System.Threading.Tasks.Task<double> DivideAsync(double x, double y);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface CalculatorServiceChannel : HQF.Tutorial.WCF.Client.Web.Service.CalculatorService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class CalculatorServiceClient : System.ServiceModel.ClientBase<HQF.Tutorial.WCF.Client.Web.Service.CalculatorService>, HQF.Tutorial.WCF.Client.Web.Service.CalculatorService {
        
        public CalculatorServiceClient() {
        }
        
        public CalculatorServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public CalculatorServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CalculatorServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CalculatorServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public double Add(double x, double y) {
            return base.Channel.Add(x, y);
        }
        
        public System.Threading.Tasks.Task<double> AddAsync(double x, double y) {
            return base.Channel.AddAsync(x, y);
        }
        
        public double Subtract(double x, double y) {
            return base.Channel.Subtract(x, y);
        }
        
        public System.Threading.Tasks.Task<double> SubtractAsync(double x, double y) {
            return base.Channel.SubtractAsync(x, y);
        }
        
        public double Multiply(double x, double y) {
            return base.Channel.Multiply(x, y);
        }
        
        public System.Threading.Tasks.Task<double> MultiplyAsync(double x, double y) {
            return base.Channel.MultiplyAsync(x, y);
        }
        
        public double Divide(double x, double y) {
            return base.Channel.Divide(x, y);
        }
        
        public System.Threading.Tasks.Task<double> DivideAsync(double x, double y) {
            return base.Channel.DivideAsync(x, y);
        }
    }
}