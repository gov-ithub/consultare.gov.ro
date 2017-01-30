using Ng2Net.TaskRunner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace Ng2Web.TaskRunner
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {            
            log4net.Config.XmlConfigurator.Configure();

            TaskRunnerService service = new TaskRunnerService();

            if (Environment.UserInteractive)
            {
                service.StartService();
                Console.WriteLine("Press any key to stop program");
                Console.ReadKey();
                service.StopService();
            }
            else
            {
                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[]
                {
                    new TaskRunnerService()
                };
                ServiceBase.Run(ServicesToRun);
            }            
        }
    }
}
