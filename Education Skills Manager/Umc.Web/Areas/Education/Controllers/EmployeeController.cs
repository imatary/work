using System.Linq;
using System.Web.Mvc;
using UMC.GA;

namespace Umc.Web.Areas.Education.Controllers
{
    [Authorize(Roles = "Edu, Admin")]
    public class EmployeeController : Controller
    {
        // GET: Education/Employee
        public ActionResult Index()
        {
            return View();
        }

        [ValidateInput(false)]
        public ActionResult EmployeePartial()
        {
            var employees = UMC.GA.GADataProvider.GetAllStaff;
            return PartialView("_EmployeePartial", employees);
        }
    }
}