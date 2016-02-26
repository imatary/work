using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MeetingRoom.Web.Controllers
{
    public class GuestController : Controller
    {
        // GET: Guest
        public ActionResult Vip()
        {
            return View();
        }
    }
}