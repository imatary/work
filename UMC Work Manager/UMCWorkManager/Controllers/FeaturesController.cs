using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UMCWorkManager.Controllers
{
    public partial class FeaturesController : DevExController
    {
        public override string Name { get { return "Features"; } }

        public ActionResult Index()
        {
            return RedirectToAction("Grouping");
        }
    }
}