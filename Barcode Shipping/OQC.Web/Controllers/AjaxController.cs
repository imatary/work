using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OQC.Web.Controllers
{
    public class AjaxController : BaseController
    {
        // GET: Ajax
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