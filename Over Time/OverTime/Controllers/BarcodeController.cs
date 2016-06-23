using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Microsoft.AspNet.Identity;
using OverTime.Helpers;
using OverTime.Models;
using OverTime.Services;

namespace OverTime.Controllers
{
    [Authorize(Roles = "Leader, Admin")]
    public class BarcodeController : Controller
    {
        private readonly IEmployeesService _employeesService;
        private readonly IUserDepartmentsService _userDepartmentsService;
        private readonly IBioStarService _bioStarService;
        public BarcodeController(
            IEmployeesService employeesService, 
            IUserDepartmentsService userDepartmentsService,
            IBioStarService bioStarService)
        {
            _employeesService = employeesService;
            _userDepartmentsService = userDepartmentsService;
            _bioStarService = bioStarService;
        }

        // GET: Barcode
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Index(SearchBarcode model)
        {
            if (ModelState.IsValid)
            {
                
                var userDepartment = await _userDepartmentsService.GetUserDepartmentsAsync(User.Identity.GetUserId());
                var user = await _bioStarService.GetUserById(model.SearchKey);
                if (user != null)
                {
                    var departments = userDepartment as IList<Department> ?? userDepartment.ToList();
                    var employes = new Employess()
                    {
                        StaffCode = user.sUserID,
                        FullName = user.sUserName,
                        DepartmentID = departments.First().DepartmentID,
                        DateCheck = DateTime.Now,
                        LeaderApproved = false,
                        ManagerApproved = false,
                        GaComplete = false,
                        Note = StringHelper.GetInfo(User.Identity.GetUserName()),
                    };
                    try
                    {
                        var employesCheck = await _employeesService.GetEmployessByIdAndDateAsync(model.SearchKey, DateTime.Now, departments.First().DepartmentID);
                        if (employesCheck == null)
                        {
                            await _employeesService.CreateAsync(employes);
                            model = new SearchBarcode()
                            {
                                SearchKey = string.Empty,
                            };
                            ModelState.Clear();
                            return View(model);
                        }
                        model = new SearchBarcode()
                        {
                            SearchKey = string.Empty,
                        };
                        ModelState.Clear();
                        ModelState.AddModelError("SearchKey", "Error!");
                        return View(model);
                    }
                    catch (Exception ex)
                    {
                        model = new SearchBarcode()
                        {
                            SearchKey = string.Empty,
                        };
                        ModelState.Clear();
                        ModelState.AddModelError("SearchKey", ex.Message);
                        return View(model);
                    }
                }
                model = new SearchBarcode()
                {
                    SearchKey = string.Empty,
                };
                ModelState.Clear();
                ModelState.AddModelError("SearchKey", "Error! User not exits.");
                return View(model);
            }
            return View(model);
        }

        [ChildActionOnly]
        public PartialViewResult GetBarcodes(string departmentId)
        {
            var userDepartment = _userDepartmentsService.GetUserDepartments(User.Identity.GetUserId());
            var employes = _employeesService.GetEmployeesYesterday(DateTime.Today, userDepartment.First().DepartmentID);
            return PartialView(employes);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(Guid id, string code)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var employess = await _employeesService.GetEmployesByIdAsync(id, code);
            if (employess == null)
            {
                return HttpNotFound();
            }
            await _employeesService.RemoveAsync(id, code);
            return RedirectToAction("Index");
        }

        public static MvcHtmlString DeleteLink(AjaxHelper ajaxHelper, string linkText, string actionName, object routeValues)
        {
            return ajaxHelper.ActionLink(linkText, actionName, routeValues, new AjaxOptions
            {
                Confirm = "Are you sure you want to delete this item?",
                HttpMethod = "DELETE",
                OnSuccess = "function() { window.location.reload(); }"
            });
        }

    }
}