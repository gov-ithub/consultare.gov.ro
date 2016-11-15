using Ng2Web.TaskRunner.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Timers;
using System.Threading.Tasks;
using System.Threading;
using Ng2Net.Core;
using Ng2Net.TaskRunner.Interfaces;
using Ng2Net.Database;

namespace Ng2Net.TaskRunner
{
    partial class TaskRunnerService : ServiceBase
    {
        List<Thread> _threads = new List<Thread>();
        Logging log = new Logging();


        public TaskRunnerService()
        {
            InitializeComponent();
        }
        protected override void OnStart(string[] args)
        {
//#if DEBUG
//            while (!Debugger.IsAttached)
//                System.Threading.Thread.Sleep(5000);
//#endif
            try
            {

                foreach (ServiceTask task in ServiceTask.GetTasks())
                {

                    log.LogMessageLine("Registering Service Task: " + task.Name + "; Channel=" + task.CurrentChannel + "; Occurs every " + task.Frequency + " seconds");
                    Thread t = new Thread(new ThreadStart(delegate ()
                    {
                        doWorkEvery(task);
                    }));
                    _threads.Add(t);
                    t.Start();
                    log.LogMessageLine("Registered successfully");
                }
            }
            catch (Exception ex)
            {
                log.LogException(ex);
            }
        }

        public void doWorkEvery(ServiceTask task)
        {
            while (true)
            {
                uint startTicks;
                int workTicks, remainingTicks;
                startTicks = (uint)Environment.TickCount;
                ExecuteServiceTask(task);
                workTicks = (int)((uint)Environment.TickCount - startTicks);
                remainingTicks = (task.Frequency)*1000 - workTicks;
                if (remainingTicks > 0) Thread.Sleep(remainingTicks);
            }
        }

        private void ExecuteServiceTask(ServiceTask task)
        {
            try
            {
                IServiceTask serviceTask = (IServiceTask)Activator.CreateInstance(task.ExecuteAssembly, task.ExecuteModule).Unwrap();
                DatabaseContext context = new DatabaseContext();
                serviceTask.Run(context, log, task.Settings);
            }
            catch (Exception ex)
            {
                log.LogException(ex);
            }
        }

        protected override void OnStop()
        {
            foreach (Thread t in _threads)
            {
                t.Abort();
            }
        }
    }
}
