using Lib.Data;
using System.Threading;
using System.Web.Mvc;

namespace ReportsMaster.Web.Controllers
{
    public class CustomerController : Controller
    {

        [ChildActionOnly]
        public ActionResult GetCustomers()
        {
            using (var context= new MasterDbContext())
            {
                //var cus = context.Customers.ToList();
                return PartialView("_CustomerPartial");
            }
        }
    }
}