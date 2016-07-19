using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OQC.Web.Controllers
{
    public class UnobtrusiveAjaxController : BaseController
    {
        // GET: UnobtrusiveAjax
        public ActionResult Index(int? page)
        {
            var listPaged = GetPagedNames(page); // GetPagedNames is found in BaseController
            if (listPaged == null)
                return HttpNotFound();

            ViewBag.Names = listPaged;
            return Request.IsAjaxRequest()
                ? (ActionResult)PartialView("UnobtrusiveAjax_Partial")
                : View();
        }
    }
}