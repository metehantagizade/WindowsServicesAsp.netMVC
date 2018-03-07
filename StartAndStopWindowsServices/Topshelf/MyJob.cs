using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Topshelf
{
    public class MyJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            if (!System.IO.File.Exists(Environment.CurrentDirectory + "start.txt"))
                System.IO.File.Create(Environment.CurrentDirectory + "start.txt");
            System.IO.File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "start.txt", DateTime.Now.ToString());
        }
        public class JobScheduler
        {
            public void Start()
            {
                IScheduler scheduler = StdSchedulerFactory.GetDefaultScheduler();
                scheduler.Start();

                IJobDetail job = JobBuilder.Create<MyJob>().Build();

                ITrigger trigger = TriggerBuilder.Create()
                       .WithSimpleSchedule(a => a.WithIntervalInMinutes(1).RepeatForever())
                       .Build();

                scheduler.ScheduleJob(job, trigger);
            }

            public void Stop()
            {
                IScheduler scheduler = StdSchedulerFactory.GetDefaultScheduler();
                scheduler.Shutdown();
            }
        }
    }
}
