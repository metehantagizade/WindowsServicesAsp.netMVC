using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Topshelf
{
    public class MyService
    {
        public void Start()
        {
            System.IO.File.Create(Environment.CurrentDirectory + "start.txt");
            System.IO.File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "start.txt", "start");
        }
        public void Stop()
        {
            System.IO.File.Create(Environment.CurrentDirectory + "stop.txt");
            System.IO.File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "stop.txt", "stop");
        }
    }
    
}
