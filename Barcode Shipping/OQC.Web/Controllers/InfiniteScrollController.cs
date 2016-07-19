using System.Linq;
using System.Web.Mvc;

namespace OQC.Web.Controllers
{
    public class InfiniteScrollController : BaseController
    {
        // GET: InfiniteScroll
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AjaxPage(int? page)
        {
            var listPaged = GetPagedNames(page); // GetPagedNames is found in BaseController
            if (listPaged == null)
                return HttpNotFound();

            return Json(new
            {
                names = listPaged.ToArray(),
                pager = listPaged.GetMetaData()
            }, JsonRequestBehavior.AllowGet);
        }
    }
}