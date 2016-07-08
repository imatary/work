using Microsoft.AspNet.Identity;
using OverTime.Models;
using OverTime.Services;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using OverTime.Helpers;

namespace OverTime.Controllers
{
    [HandleError(ExceptionType = typeof(SqlException), View = "DatabaseError")]
    [HandleError(ExceptionType = typeof(NullReferenceException), View = "LameErrorHandling")]
    public class ConfirmController : Controller
    {
        private readonly IEmployeesService _employeesService;
        private readonly IEmployeesLogService _employeesLogService;
        private readonly IUserDepartmentsService _userDepartmentsService;
        private readonly IGAService _gaService;
        private readonly IDepartmentService _departmentService;
        public ConfirmController(
            IEmployeesService employeesService,
            IEmployeesLogService employeesLogService,
            IUserDepartmentsService userDepartmentsService,
            IDepartmentService departmentService,
            IGAService gaService
            )
        {
            _employeesService = employeesService;
            _employeesLogService = employeesLogService;
            _userDepartmentsService = userDepartmentsService;
            _departmentService = departmentService;
            _gaService = gaService;
        }

        // GET: Confirm
        [Authorize]
        public async Task<ActionResult> Index(string searchDate)
        {
            IEnumerable<EmployeesLog> employeesLogs = null;
            var userDepartment = await _departmentService.GetUserDepartmentsAsync(User.Identity.GetUserId());
            var departments = userDepartment as IList<Department> ?? userDepartment.ToList();
            if (User.IsInRole("ManageDepartmentShift"))
            {
                DateTime startDate = DateTime.Today;
                TimeSpan startTime = new TimeSpan(08, 00, 00);
                foreach (var department in departments)
                {
                    var employesses = await _employeesService.GetEmployessYesterDayByIdAndDateAsync(startDate.Subtract(startTime), department.DepartmentID);
                    foreach (var employess in employesses)
                    {
                        var log = await _employeesLogService.CheckEmployeesLogExitsByStaffCodeAndDateCheckAysnc(employess.StaffCode, startDate);
                        if (log == null)
                        {
                            var employeesLog = new EmployeesLog()
                            {
                                StaffCode = employess.StaffCode,
                                FullName = employess.FullName,
                                DepartmentID = employess.DepartmentID,
                                Note = StringHelper.GetInfo(User.Identity.GetUserName()),
                                CreateBy = User.Identity.GetUserName(),
                                StaffPicture = employess.StaffPicture,
                                DateCheck = startDate,
                                TimeCheck = employess.DateCheck,
                                LeaderApproved = false,
                                ManagerApproved = false,
                                GaComplete = false,
                                ManageDepartmentShiftApproved = false,
                            };
                            try
                            {
                                await _employeesLogService.CreateAsync(employeesLog);
                            }
                            catch (Exception ex)
                            {
                                throw new Exception(ex.Message);
                            }
                        }                   
                    }
                }

                foreach (var department in departments)
                {
                    employeesLogs = await _employeesLogService.GetEmployeesLogsByApprovedAsync("ManageDepartmentShift", DateTime.Today, department.DepartmentID);
                } 
            }
            //else if (User.IsInRole("ManageDepartmentShift"))
            //{
            //    foreach (var department in departments)
            //    {
            //        employeesLogs = await _employeesLogService.GetEmployeesLogsByApprovedAsync("ManageDepartmentShift", DateTime.Today, department.DepartmentID);
            //    }
                
            //}
            else if (User.IsInRole("Manager"))
            {
                employeesLogs = await _employeesLogService.GetEmployeesLogsByApprovedAsync("Manager", DateTime.Today, departments);
            }
            else if (User.IsInRole("GA"))
            {
                if (!string.IsNullOrEmpty(searchDate))
                {
                    try
                    {
                        DateTime dateSearch = DateTime.ParseExact(searchDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        employeesLogs = await _employeesLogService.GetEmployeesLogsByApprovedAsync("GA", dateSearch);
                    }
                    catch (Exception ex)
                    {
                        ViewBag.ErrorMessage = $"Invalid date {searchDate}." + ex.Message;
                        employeesLogs = await _employeesLogService.GetEmployeesLogsByApprovedAsync("GA", DateTime.Today.AddYears(10));
                    }
                }
                else
                {
                    employeesLogs = await _employeesLogService.GetEmployeesLogsByApprovedAsync("GA", DateTime.Today);
                }
            }
            else if (User.IsInRole("Admin"))
            {
                employeesLogs = await _employeesLogService.GetEmployeesLogsByApprovedAsync("Admin", DateTime.Today);
            }
            return View(employeesLogs);
        }


        [HttpGet]
        [AllowAnonymous]
        public ActionResult InputBarcode()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> InputBarcode(SearchBarcode model)
        {
            if (ModelState.IsValid)
            {
                string staffCode = StringHelper.LengthStaffCode(model.SearchKey);
                var staff = await _gaService.GetStaffByCode(staffCode);
                if (staff != null)
                {
                    Employess employess = new Employess()
                    {
                        StaffCode = staff.StaffCode,
                        FullName = staff.FullName,
                        DepartmentID = staff.DeptCode,
                        CreateBy = staffCode,
                        StaffPicture = staff.StaffPicture,
                        DateCheck = DateTime.Now,
                        LeaderApproved = false,
                        ManagerApproved = false,
                        GaComplete = false,
                        Note = StringHelper.GetInfo(staffCode),
                    };

                    try
                    {
                        var employesCheck = await _employeesService.GetEmployessByIdAndDateAsync(model.SearchKey, DateTime.Now);
                        if (employesCheck == null)
                        {
                            await _employeesService.CreateAsync(employess);
                            ViewBag.SuccessMessage = $"Input user {staffCode} successful!";
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
                        ModelState.AddModelError("SearchKey", $"Error! User {staffCode} already exists.\n" +
                                                              $"Tên: {employesCheck.FullName} \n" +
                                                              $"Input time: {employesCheck.DateCheck.ToShortTimeString()}");
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
                ModelState.AddModelError("SearchKey", $"Error! User {staffCode} not exits in database.");
                return View(model);
            }
            return View(model);
        }



        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> InputBarcode(SearchBarcode model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var userDepartment = await _userDepartmentsService.GetUserDepartmentsAsync(User.Identity.GetUserId());
        //        string staffCode = StringHelper.LengthStaffCode(model.SearchKey);
        //        Employess employess = null;
        //        var staff = await _gaService.GetStaffByCode(staffCode);
        //        if (staff != null)
        //        {
        //            foreach (var department in userDepartment)
        //            {
        //                if (staff.DeptCode == department.DepartmentID)
        //                {
        //                    employess = new Employess()
        //                    {
        //                        StaffCode = staff.StaffCode,
        //                        FullName = staff.FullName,
        //                        DepartmentID = staff.DeptCode,
        //                        CreateBy = User.Identity.GetUserName(),
        //                        StaffPicture = staff.StaffPicture,
        //                        DateCheck = DateTime.Now,
        //                        LeaderApproved = false,
        //                        ManagerApproved = false,
        //                        GaComplete = false,
        //                        Note = StringHelper.GetInfo(User.Identity.GetUserName()),
        //                    };

        //                    try
        //                    {
        //                        var employesCheck = await _employeesService.GetEmployessByIdAndDateAsync(model.SearchKey, DateTime.Now, department.DepartmentID);
        //                        if (employesCheck == null)
        //                        {
        //                            await _employeesService.CreateAsync(employess);

        //                            model = new SearchBarcode()
        //                            {
        //                                SearchKey = string.Empty,
        //                            };
        //                            ModelState.Clear();
        //                            return View(model);
        //                        }
        //                        model = new SearchBarcode()
        //                        {
        //                            SearchKey = string.Empty,
        //                        };
        //                        ModelState.Clear();
        //                        ModelState.AddModelError("SearchKey", $"Error! User {staffCode} already exists");
        //                        return View(model);
        //                    }
        //                    catch (Exception ex)
        //                    {
        //                        model = new SearchBarcode()
        //                        {
        //                            SearchKey = string.Empty,
        //                        };
        //                        ModelState.Clear();
        //                        ModelState.AddModelError("SearchKey", ex.Message);
        //                        return View(model);
        //                    }
        //                }
        //            }
        //            if (employess == null)
        //            {
        //                model = new SearchBarcode()
        //                {
        //                    SearchKey = string.Empty,
        //                };
        //                ModelState.Clear();
        //                ModelState.AddModelError("SearchKey", $"Error! User {staffCode} not management of your department.");
        //                return View(model);
        //            }
        //        }
        //        else
        //        {
        //            model = new SearchBarcode()
        //            {
        //                SearchKey = string.Empty,
        //            };
        //            ModelState.Clear();
        //            ModelState.AddModelError("SearchKey", $"Error! User {staffCode} not exits in database.");
        //            return View(model);
        //        }
        //    }
        //    return View(model);
        //}

        [ChildActionOnly]
        public PartialViewResult ShowBarcodes()
        {
            //var userDepartment = _userDepartmentsService.GetUserDepartments(User.Identity.GetUserId());
            //IEnumerable<Employess> employesses = _employeesService.GetEmployesses();
            //foreach (var department in userDepartment)
            //{
            //    employesses = _employeesService.GetEmployeesYesterday(DateTime.Today, department.DepartmentID);

            //}

            IEnumerable<Employess> employesses =
                _employeesService.GetEmployeesYesterday(DateTime.Today)
                .OrderByDescending(item => item.DateCheck);
            return PartialView(employesses);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> Approved(Guid id)
        {
            var eventLog = await _employeesLogService.GetEmployeesLogsByIdAsync(id);
            if (eventLog != null)
            {
                if (User.IsInRole("Leader"))
                {
                    eventLog.LeaderApproved = true;
                }
                else if (User.IsInRole("ManageDepartmentShift"))
                {
                    eventLog.ManageDepartmentShiftApproved = true;
                }
                else if (User.IsInRole("Manager"))
                {
                    eventLog.ManagerApproved = true;
                }
                else if (User.IsInRole("GA"))
                {
                    eventLog.GaComplete = true;
                }
                try
                {
                    await _employeesLogService.UpdateAsync(eventLog);
                    return Json(true, JsonRequestBehavior.AllowGet);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }

            }
            return Json(false, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> Approveds()
        {
            var userDepartment = await _departmentService.GetUserDepartmentsAsync(User.Identity.GetUserId());
            IEnumerable<EmployeesLog> employeesLogs;
            var departments = userDepartment as IList<Department> ?? userDepartment.ToList();
            if (User.IsInRole("Leader"))
            {
                foreach (var department in departments)
                {
                    employeesLogs = await _employeesLogService.GetEmployeesLogsByApprovedAsync("Leader", DateTime.Now, department.DepartmentID);
                    foreach (var log in employeesLogs)
                    {
                        log.LeaderApproved = true;
                        await _employeesLogService.UpdateAsync(log);
                    }  
                }
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            if (User.IsInRole("ManageDepartmentShift"))
            {
                foreach (var department in departments)
                {
                    employeesLogs = await _employeesLogService.GetEmployeesLogsByApprovedAsync("ManageDepartmentShift", DateTime.Now, department.DepartmentID);
                    foreach (var log in employeesLogs)
                    {
                        log.ManageDepartmentShiftApproved = true;
                        await _employeesLogService.UpdateAsync(log);
                    }
                }
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            if (User.IsInRole("Manager"))
            {
                foreach (var department in departments)
                {
                    employeesLogs =
                        await
                            _employeesLogService.GetEmployeesLogsByApprovedAsync("Manager", DateTime.Now,
                                department.DepartmentID);
                    foreach (var log in employeesLogs)
                    {
                        log.ManagerApproved = true;
                        await _employeesLogService.UpdateAsync(log);
                    }
                }
                return Json(true, JsonRequestBehavior.AllowGet);

            }
            return Json(false, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [Authorize(Roles = "Leader")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var eventLog = await _employeesLogService.GetEmployeesLogsByIdAsync(id);
            if (eventLog != null)
            {
                if (User.IsInRole("Leader"))
                {
                    eventLog.IsDelete = true;
                }
                try
                {
                    await _employeesLogService.UpdateAsync(eventLog);
                    return Json(true, JsonRequestBehavior.AllowGet);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            return Json(false, JsonRequestBehavior.AllowGet);
        }

        [Authorize(Roles = "GA, Admin")]
        public async Task<FileContentResult> DownloadCSV()
        {
            string csv =
                string.Concat(
                    from employee in await _employeesLogService.GetEmployeesLogsByApprovedAsync("GA", DateTime.Today)
                    select employee.StaffCode + ","
                           + employee.FullName + ","
                           + employee.DepartmentID + ","
                           + employee.Note + "\n");
            return File(new System.Text.UTF8Encoding().GetBytes(csv), "text/csv", "Report.csv");
        }

        public async Task<ActionResult> ExportToCSV()
        {
            StringWriter sw = new StringWriter();

            sw.WriteLine("\"Date\",\"ID\",\"User Name\",\"Department\",\"Department\",\"End Time\"");
            var fName = $"Export-{DateTime.Now.ToString("s")}";
            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment;filename=" + fName + ".csv");
            Response.ContentType = "application/octet-stream";

            var users = await _employeesLogService.GetEmployeesLogsByApprovedAsync("GA", DateTime.Today);

            foreach (var user in users)
            {
                sw.WriteLine($"\"{user.DateCheck.ToString("MM/dd/yyyy")}\",\"{user.StaffCode}\",\"{user.FullName}\",\"{user.DepartmentID}\",\"{user.DepartmentID}\",\"{user.TimeCheck.ToLongTimeString()}\"");
            }
            Response.Write(sw.ToString());
            Response.End();
            return RedirectToAction("Index");
        }
    } 
}