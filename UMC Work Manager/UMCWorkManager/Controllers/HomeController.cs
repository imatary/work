using System.Web.Mvc;

namespace UMCWorkManager.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        // GET: home/index
        public ActionResult Index()
        {
            if (User.IsInRole("Manager"))
            {
                return RedirectToAction("Manager", "User");
            }
            else
            {
                return RedirectToAction("Employee", "User", new { id = User.Identity.Name });
            }
            
        }

        public ActionResult Social()
        {
            return View();
        }

        // GET: home/inbox
        public ActionResult Inbox()
        {
            return View();
        }

        // GET: home/widgets
        public ActionResult Widgets()
        {
            return View();
        }

        // GET: home/chat
        public ActionResult Chat()
        {
            return View();
        }
    }
}