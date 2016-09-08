using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace ReportsMaster.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        private static Timer threadingTimer;
        public static System.Timers.Timer timer = new System.Timers.Timer(1000);
        public ActionResult ReportByCusID(string id)
        {
            //if (threadingTimer == null)
            //{
            //    //raise timer callback every 5 minutes
            //    threadingTimer = new Timer(new TimerCallback(LapVoTan),
            //                              HttpContext.CurrentHandler, 1 * 6000, 1 * 6000);
            //}

            timer.Enabled = true;
            timer.Elapsed += new System.Timers.ElapsedEventHandler(timer_Elapsed);

            return View();
        }
        int count = 0;
        void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            // Do Your Stuff
            count++;
            SetText(count.ToString());
        }

        delegate void SetCallBack(string tex);
        private void SetText(string t)
        {
            ViewBag.Data = t;
        }

        private void LapVoTan(object sender)
        {
            int count = 0;
            while (true)
            {
                count++;
                ViewBag.Data=count.ToString();
                Thread.Sleep(1000);
            }

        }
    }
}