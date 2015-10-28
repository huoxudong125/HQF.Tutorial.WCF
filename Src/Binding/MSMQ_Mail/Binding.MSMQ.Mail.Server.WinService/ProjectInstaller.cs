using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.ServiceProcess;
using System.Threading.Tasks;

namespace Binding.MSMQ.Mail.Server.WinService
{
    [RunInstaller(true)]
    public partial class ProjectInstaller : System.Configuration.Install.Installer
    {
        /// <summary>
        /// In the above code we’ve added a ServiceProcessInstaller and a ServiceInstaller. 
        /// The ServiceProcessInstaller is used by InstallUtil.exe 
        /// and we’re using it to specify that we want to use the Local System account to run our service.
        ///  If you specify ServiceAccount.User and don’t provide a username and password, 
        /// it’ll request these during installation of the service. 
        /// With the ServiceInstaller we’re specifying that our service has to start automatically on Windows startup 
        /// and the name of our service.
        /// </summary>
        public ProjectInstaller()
        {
            InitializeComponent();

            ServiceProcessInstaller processInstaller = new ServiceProcessInstaller();
            ServiceInstaller serviceInstaller = new ServiceInstaller();
            processInstaller.Account = ServiceAccount.LocalSystem;
            serviceInstaller.StartType = ServiceStartMode.Automatic;
            serviceInstaller.ServiceName = "Class-A E-Mail MSMQ Service";
            Installers.Add(serviceInstaller);
            Installers.Add(processInstaller);
        }
    }
}
