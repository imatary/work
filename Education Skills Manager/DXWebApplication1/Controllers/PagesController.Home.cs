using DevExpress.Web.Mvc;
using System;
using System.Linq;
using System.Web.Mvc;

namespace DXWebApplication1.Controllers
{
    public partial class PagesController : Controller
    {
        public ActionResult Home()
        {
            return View();
        }

        UMC.GA.GADbContext db = new UMC.GA.GADbContext();

        [ValidateInput(false)]
        public ActionResult GridView1Partial()
        {
            var model = db.PR_Bomon;
            return PartialView("~/Views/Pages/_GridView1Partial.cshtml", model.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult GridView1PartialAddNew(UMC.GA.PR_Bomon item)
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
            return PartialView("~/Views/Pages/_GridView1Partial.cshtml", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridView1PartialUpdate(UMC.GA.PR_Bomon item)
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
            return PartialView("~/Views/Pages/_GridView1Partial.cshtml", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridView1PartialDelete(System.String MaBoMon)
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
            return PartialView("~/Views/Pages/_GridView1Partial.cshtml", model.ToList());
        }
    }
}