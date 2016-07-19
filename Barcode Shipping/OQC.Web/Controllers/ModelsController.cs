using OQC.Web.Models;
using OQC.Web.Services;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace OQC.Web.Controllers
{
    public class ModelsPcbController : Controller
    {
        private readonly ModelsService modelService;
        public ModelsPcbController()
        {
            modelService = new ModelsService();
        }
        // GET: Models
        public async Task<ActionResult> Index()
        {
            return View(await modelService.GetModelsAsync());
        }

        [ChildActionOnly]
        public ActionResult Create()
        {
            return PartialView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ModelPCB modelView)
        {
            if (ModelState.IsValid)
            {
                ModelPCB model = new ModelPCB
                {
                    ModelID = Guid.NewGuid().ToString(),
                    ModelName = modelView.ModelName,
                    CreatedBy = User.Identity.Name,
                    DateCreated = DateTime.Now,
                    Quantity = modelView.Quantity,
                    SerialNo = modelView.SerialNo,
                    CustomerName = modelView.CustomerName,
                };

                try
                {
                    await modelService.InsertAsync(model);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("ModelName", ex.Message);
                }
                return RedirectToAction("Index");
            }
            return PartialView();
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Error");
            }
            var model = await modelService.GetModelByIdAsync(id);
            if (model == null)
            {
                return RedirectToAction("Index", "Error");
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ModelPCB modelView)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    modelView.CreatedBy = User.Identity.Name;
                    modelView.DateCreated = DateTime.Now;

                    await modelService.UpdateAsync(modelView);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("ModelName", ex.Message);
                }
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Leader, Admin, Delete")]
        public async Task<ActionResult> Delete(string id)
        {
            var model = await modelService.GetModelByIdAsync(id);
            if (model != null)
            {
                try
                {
                    modelService.Delete(model.ModelID);
                    return Json(true, JsonRequestBehavior.AllowGet);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            return Json(false, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Kiểm tra sự tồn tại của Operator
        /// </summary>
        /// <param name="OperatorID"></param>
        /// <returns></returns>
        public async Task<ActionResult> CheckModelNameExits(string ModelName)
        {
            var model = await modelService.GetModelByIdAsync(ModelName);
            if (model != null)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            return Json(true, JsonRequestBehavior.AllowGet);
        }
    }
}