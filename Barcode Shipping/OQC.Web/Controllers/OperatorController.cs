using System.Linq;
using OQC.Web.Services;
using System.Threading.Tasks;
using System.Web.Mvc;
using System;
using OQC.Web.Models;

namespace OQC.Web.Controllers
{
    public class OperatorController : Controller
    {
        private readonly OperatorService operatorService;
        public OperatorController()
        {
            operatorService = new OperatorService();
        }
        // GET: Operator
        public async Task<ActionResult> Index()
        {
            var operators = await operatorService.GetOperatorsAsync();
            return View(operators.OrderBy(item => item.OperatorName));
        }

        [ChildActionOnly]
        public ActionResult Create()
        {
            return PartialView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(OperatorAddModel operatorModel)
        {
            if (ModelState.IsValid)
            {
                mst_operator opera = new mst_operator
                {
                    OperatorID = operatorModel.OperatorID,
                    OperatorName = operatorModel.OperatorName,
                };

                try
                {
                    await operatorService.InsertAsync(opera);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("OperatorName", ex.Message);
                }
                return RedirectToAction("Index");
            }
            return PartialView();
        }

        [HttpGet]
        [Authorize]
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Error");
            }
            var opera = operatorService.GetOperatorByCode(id);
            if (opera == null)
            {
                return RedirectToAction("Index", "Error");
            }
            return View(opera);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(mst_operator operatorModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await operatorService.UpdateAsync(operatorModel);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("OperatorName", ex.Message);
                }
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Leader, Admin, Delete")]
        public async Task<ActionResult> Delete(string id)
        {
            var opera = await operatorService.GetOperatorByCodeAsync(id);
            if (opera != null)
            {
                try
                {
                    operatorService.Delete(opera.OperatorID);
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
        public async Task<ActionResult> CheckOperatorExits(string OperatorID)
        {
            var opera = await operatorService.GetOperatorByCodeAsync(OperatorID);
            if (opera != null)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            return Json(true, JsonRequestBehavior.AllowGet);
        }
    }
}