using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umc.Web.Areas.Education.Models;

namespace Umc.Web.Areas.Education.Controllers
{
    [Authorize(Roles = "Edu, Admin")]
    public class SubjectController : Controller
    {
        // GET: Education/Subject
        public ActionResult Index()
        {
            return View();
        }


        Umc.Web.Areas.Education.Models.EduDataContext db = new Umc.Web.Areas.Education.Models.EduDataContext();

        [ValidateInput(false)]
        public ActionResult SubjectPartial()
        {
            var model = db.PR_Bomon;
            return PartialView("_SubjectPartial", model.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult SubjectPartialAddNew(Umc.Web.Areas.Education.Models.PR_Bomon item)
        {
            var model = db.PR_Bomon;
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
            return PartialView("_SubjectPartial", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult SubjectPartialUpdate(Umc.Web.Areas.Education.Models.PR_Bomon item)
        {
            var model = db.PR_Bomon;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.MaBoMon == item.MaBoMon);
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
            return PartialView("_SubjectPartial", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult SubjectPartialDelete(System.String MaBoMon)
        {
            var model = db.PR_Bomon;
            if (MaBoMon != null)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.MaBoMon == MaBoMon);
                    if (item != null)
                        model.Remove(item);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_SubjectPartial", model.ToList());
        }
    }
}