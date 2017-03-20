using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Umc.Web.Areas.Education.Controllers
{

    [Authorize(Roles = "Edu, Admin")]
    public class ReportsController : Controller
    {
        // GET: Education/Reports
        public ActionResult Index()
        {
            return View();
        }

        Umc.Web.Models.ApplicationDbContext db = new Umc.Web.Models.ApplicationDbContext();

        [ValidateInput(false)]
        public ActionResult OlympicPartial()
        {
            var model = db.Olympics;
            return PartialView("_OlympicPartial", model.ToList());
        }

        //[ValidateInput(false)]
        //public ActionResult CheckSolderPartial()
        //{
        //    var model = db.Olympics;
        //    return PartialView("_CheckSolderPartial", model.ToList());
        //}

        [HttpPost, ValidateInput(false)]
        public ActionResult OlympicPartialAddNew(Umc.Web.Models.Olympic item)
        {
            var model = db.Olympics;
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
            return PartialView("_OlympicPartial", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult OlympicPartialUpdate(Umc.Web.Models.Olympic item)
        {
            var model = db.Olympics;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.Id == item.Id);
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
            return PartialView("_OlympicPartial", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult OlympicPartialDelete(System.Guid Id)
        {
            var model = db.Olympics;
            if (Id != null)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.Id == Id);
                    if (item != null)
                        model.Remove(item);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_OlympicPartial", model.ToList());
        }

        [ValidateInput(false)]
        public ActionResult CheckSolderPartial()
        {
            //var model = UMC.GA.GADataProvider.GetCheckSolders(null, null);
            //return PartialView("_CheckSolderPartial", model);
            return PartialView();

        }

        [ValidateInput(false)]
        public ActionResult CheckEyePartial()
        {
            //var model = UMC.GA.GADataProvider.GetCheckEyes();
            //return PartialView("_CheckEyePartial", model);

            return PartialView();
        }
    }
}