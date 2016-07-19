using System.Web.Mvc;

namespace OQC.Web.Controllers
{
    public class TraditionalPagingController : BaseController
    {
        // GET: TraditionalPaging
        public ActionResult Index(int? page)
        {
            var listPaged = GetPagedNames(page); // GetPagedNames is found in BaseController
            if (listPaged == null)
                return HttpNotFound();

            // pass the paged list to the view and render
            ViewBag.Names = listPaged;
            return View();
        }
    }
}