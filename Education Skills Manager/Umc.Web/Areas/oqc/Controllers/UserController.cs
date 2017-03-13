using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Umc.Web.Areas.oqc.Controllers
{
    public class UserController : Controller
    {
        // GET: oqc/User
        public ActionResult Index()
        {
            return View();
        }

        UMC.OQC.OQCDbContext db = new UMC.OQC.OQCDbContext();

        [ValidateInput(false)]
        public ActionResult UsersPartial()
        {
            var model = db.mst_operator;
            return PartialView("_UsersPartial", model.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult UsersPartialAddNew(UMC.OQC.mst_operator item)
        {
            var model = db.mst_operator;
            if (ModelState.IsValid)
            {
                try
                {
                    model.Add(item);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_UsersPartial", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult UsersPartialUpdate(UMC.OQC.mst_operator item)
        {
            var model = db.mst_operator;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.OperatorID == item.OperatorID);
                    if (modelItem != null)
                    {
                        this.UpdateModel(modelItem);
                        db.SaveChanges();
                    }
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_UsersPartial", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult UsersPartialDelete(System.String OperatorID)
        {
            var model = db.mst_operator;
            if (OperatorID != null)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.OperatorID == OperatorID);
                    if (item != null)
                        model.Remove(item);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_UsersPartial", model.ToList());
        }
    }
}