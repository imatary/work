﻿using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Umc.Web.Areas.oqc.Controllers
{
    public class ModelsController : Controller
    {
        // GET: oqc/Models
        public ActionResult Index()
        {
            return View();
        }

        UMC.OQC.OQCDbContext db = new UMC.OQC.OQCDbContext();

        [ValidateInput(false)]
        public ActionResult ModelsPartial()
        {
            var model = db.Models;
            return PartialView("_ModelsPartial", model.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult ModelsPartialAddNew(UMC.OQC.Model item)
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
            return PartialView("_ModelsPartial", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult ModelsPartialUpdate(UMC.OQC.Model item)
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
            return PartialView("_ModelsPartial", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult ModelsPartialDelete(System.String ModelID)
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
            return PartialView("_ModelsPartial", model.ToList());
        }
    }
}