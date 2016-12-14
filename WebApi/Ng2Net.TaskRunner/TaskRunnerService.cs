using Ng2Web.TaskRunner.Classes;
using System;
using System.Collections.Generic;
using System.ServiceProcess;
using System.Threading;
using Ng2Net.TaskRunner.Interfaces;
using Ng2Net.Infrastrucure.Logging;
using Microsoft.Practices.Unity;
using System.Diagnostics;
using Ng2Net.Infrastructure.Data;
using Ng2Net.Model.Scheduler;
using Ng2Net.Data;
using System.Linq;

namespace Ng2Net.TaskRunner
{
    partial class TaskRunnerService : ServiceBase
    {
        List<Thread> _threads = new List<Thread>();
        Logging log = new Logging();
        IUnityContainer container;


        public TaskRunnerService()
        {
            container = UnityConfig.RegisterComponents();
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

                    Logging.LogMessage("Registering Service Task: " + task.Name + "; Channel=" + task.CurrentChannel + "; Occurs every " + task.Frequency + " seconds");
                    Thread t = new Thread(new ThreadStart(delegate ()
                    {
                        doWorkEvery(task);
                    }));
                    _threads.Add(t);
                    t.Start();
                    Logging.LogMessage("Registered successfully");
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex);
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
            TaskRunnerLog runnerLog = new TaskRunnerLog()
            {
                DateStarted = DateTime.Now,
                TaskName = task.Name,
                TaskResult = "RUNNING"
            };

            try
            {
                IRepository<TaskRunnerLog> taskRunnerLogRepository = new EfRepository<TaskRunnerLog>(new DatabaseContext());
                taskRunnerLogRepository.GetMany(l => l.TaskResult == "RUNNING" && l.TaskName == task.Name).ToList().ForEach(l => {
                    l.DateEnded = DateTime.Now;
                    l.TaskResult = "STOPPED"; });
                taskRunnerLogRepository.Save();
                taskRunnerLogRepository.Insert(runnerLog);
                taskRunnerLogRepository.Save();
                IServiceTask serviceTask = (IServiceTask)Activator.CreateInstance(task.ExecuteAssembly, task.ExecuteModule).Unwrap();                
                serviceTask.Run(task.Settings);
                runnerLog.TaskResult = "COMPLETE";
                runnerLog.DateEnded = DateTime.Now;
                taskRunnerLogRepository.Save();
            }
            catch (Exception ex)
            {
                Logging.LogException(ex);
                runnerLog.TaskResult = "ERROR";
                runnerLog.DateEnded = DateTime.Now;
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
