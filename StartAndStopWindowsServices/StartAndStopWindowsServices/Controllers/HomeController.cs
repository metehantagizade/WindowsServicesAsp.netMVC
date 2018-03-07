using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Web;
using System.Web.Mvc;

namespace StartAndStopWindowsServices.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.status = ServiceStatus().ToString();
            return View();
        }

        [HttpPost]
        public ActionResult StartService()
        {
            Start();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult StopService()
        {
            Stop();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult RestartService()
        {
            Restart();
            return RedirectToAction("Index");
        }

        private void Stop()
        {
            ServiceController sc = new ServiceController("MyWindowServiceWithTopshelf");
            if(sc.Status == ServiceControllerStatus.Running)
            {
                TimeSpan timeOut = TimeSpan.FromMilliseconds(5000);
                sc.Stop();
                sc.WaitForStatus(ServiceControllerStatus.Stopped, timeOut);
            }
        }

        private void Start()
        {
            ServiceController sc = new ServiceController("MyWindowServiceWithTopshelf");
            if(sc.Status != ServiceControllerStatus.Running && sc.Status != ServiceControllerStatus.StartPending)
            {
                try
                {
                    TimeSpan timeOut = TimeSpan.FromMilliseconds(5000);
                    sc.Start();
                    sc.WaitForStatus(ServiceControllerStatus.Running, timeOut);
                }
                catch(Exception ex)
                {

                }
                
            }
        }
        public static void Restart()
        {
            ServiceController service = new ServiceController("MyWindowServiceWithTopshelf");
            try
            {
                TimeSpan timeOut = TimeSpan.FromMilliseconds(5000);
                service.Stop();
                service.WaitForStatus(ServiceControllerStatus.Stopped, timeOut);

                service.Start();
                service.WaitForStatus(ServiceControllerStatus.Running, timeOut);
            }
            catch
            {
                // ...
            }
        }

        public ServiceControllerStatus ServiceStatus()
        {
            ServiceController sc = new ServiceController("MyWindowServiceWithTopshelf");
            return sc.Status;
        }
        
    }
}