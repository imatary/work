using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Umc.Web.Areas.Education.Controllers
{
    [Authorize(Roles = "Edu, Admin")]
    public class SkillsController : Controller
    {
        // GET: Education/Skills
        public ActionResult Index()
        {
            return View();
        }
    }
}