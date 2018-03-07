using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Topshelf.MyJob;

namespace Topshelf
{
    public class MyService
    {
        JobScheduler scheduler;
        public void Start()
        {
            scheduler = new JobScheduler();
            scheduler.Start();
        }
        public void Stop()
        {
            scheduler = new JobScheduler();
            scheduler.Start();
        }
    }
    
}
