using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Umc.Web.Areas.oqc.Controllers
{
    public class ReportsController : Controller
    {
        // GET: oqc/Reports
        public ActionResult Index()
        {
            return View();
        }

        UMC.OQC.OQCDbContext db = new UMC.OQC.OQCDbContext();

        [ValidateInput(false)]
        public ActionResult NichiconPartial()
        {
            var model = db.NICHICONs;
            return PartialView("_NichiconPartial", model.ToList());
        }

        [ValidateInput(false)]
        public ActionResult MurataPartial()
        {
            var model = db.Muratas;
            return PartialView("_MurataPartial", model.ToList());
        }

    }
}