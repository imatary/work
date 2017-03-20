using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Umc.Web.Areas.oqc.Controllers
{
    public class ModelController : Controller
    {
        // GET: oqc/Model
        public ActionResult Index()
        {
            return View();
        }

        Umc.Web.Areas.oqc.Models.OQCDataContext db = new Umc.Web.Areas.oqc.Models.OQCDataContext();

        [ValidateInput(false)]
        public ActionResult ModelPartial()
        {
            var model = db.Models;
            return PartialView("_ModelPartial", model.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult ModelPartialAddNew(Umc.Web.Areas.oqc.Models.Model item)
        {
            var model = db.Models;
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
            return PartialView("_ModelPartial", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult ModelPartialUpdate(Umc.Web.Areas.oqc.Models.Model item)
        {
            var model = db.Models;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.ModelID == item.ModelID);
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
            return PartialView("_ModelPartial", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult ModelPartialDelete(System.String ModelID)
        {
            var model = db.Models;
            if (ModelID != null)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.ModelID == ModelID);
                    if (item != null)
                        model.Remove(item);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_ModelPartial", model.ToList());
        }
    }
}