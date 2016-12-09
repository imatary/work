using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using UMCWorkManager.App_Helpers;

namespace UMCWorkManager.Controllers
{
    public class UploadController : Controller
    {
       

        [HttpGet]
        public ActionResult Upload()
        {
            return View();
        }
        public ActionResult FileManager()
        {
            return View();
        }

        [HttpGet]
        public ActionResult _Upload()
        {
            return PartialView();
        }
    }
}