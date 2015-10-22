using System.ServiceProcess;

namespace Binding.MSMQ.Mail.Server.WinService
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new MailService()
            };
            ServiceBase.Run(ServicesToRun);
        }
    }
}
