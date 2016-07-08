using System.Web.Mvc;

namespace OQC.Web.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult NotFound()
        {
            return View();
        }
        public ActionResult BadRequest()
        {
            return View();
        }

    }
}