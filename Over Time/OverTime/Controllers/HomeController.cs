using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Lib.Models;
using Microsoft.AspNet.Identity;
using OverTime.Helpers;
using OverTime.Models;
using OverTime.Services;

namespace OverTime.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IEmployeesService _employeesService;
        private readonly IEmployeesLogService _employeesLogService;
        private readonly IEventLogService _eventLogService;

        public HomeController(
            IEmployeesLogService employeesLogService,
            IEventLogService eventLogService, 
            IEmployeesService employeesService)
        {
            
            _employeesLogService = employeesLogService;
            _eventLogService = eventLogService;
            _employeesService = employeesService;
        }

        public async Task<ActionResult> Index(string searchDate)
        {
            IEnumerable<EmployeesLog> employeesLogs = null;
            var userDepartment = await _eventLogService.GetUserDepartmentsAsync(User.Identity.GetUserId());
            if (User.IsInRole("Leader"))
            {
                DateTime startDate = DateTime.Today;
                DateTime endDate = DateTime.Today;
                TimeSpan startTime = new TimeSpan(08, 00, 00);

                IEnumerable<EventLog> eventLogs = await _eventLogService.GetLogsUsers(User.Identity.GetUserId(), startDate, endDate, "538598286");
                var departments = userDepartment as IList<Department> ?? userDepartment.ToList();
                foreach (var eventLog in eventLogs)
                {
                    var employessYesterDay = await _employeesService.GetEmployessByIdAndDateAsync(eventLog.nUserID.ToString(), startDate.Subtract(startTime), departments.First().DepartmentID);
                    if (employessYesterDay != null)
                    {
                        if (eventLog.nUserID.ToString() == employessYesterDay.StaffCode)
                        {
                            var employees = await _employeesLogService.CheckEmployeesLogExitsByStaffCodeAndDateCheckAysnc(eventLog.nUserID.ToString(), startDate);
                            if (employees == null)
                            {
                                var employeesLog = new EmployeesLog()
                                {
                                    StaffCode = eventLog.nUserID.ToString(),
                                    FullName = eventLog.sUserName,
                                    DepartmentID = eventLog.DepartmentName,
                                    Note = StringHelper.GetInfo(User.Identity.GetUserName()),
                                    DateCheck = startDate,
                                    TimeCheck = employessYesterDay.DateCheck,
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
                }
                employeesLogs = await _employeesLogService.GetEmployeesLogsByApprovedAsync("Leader", DateTime.Today, departments);
            }
            else if (User.IsInRole("ManageDepartmentShift"))
            {
                employeesLogs = await _employeesLogService.GetEmployeesLogsByApprovedAsync("ManageDepartmentShift", DateTime.Today, userDepartment);
            }
            else if (User.IsInRole("Manager"))
            {
                employeesLogs = await _employeesLogService.GetEmployeesLogsByApprovedAsync("Manager", DateTime.Today, userDepartment);
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
                else if(User.IsInRole("GA"))
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
        [Authorize(Roles = "Leader, ManageDepartmentShift, Manager, Admin")]
        public async Task<ActionResult> Approveds()
        {
            var userDepartment = await _eventLogService.GetUserDepartmentsAsync(User.Identity.GetUserId());
            IEnumerable<EmployeesLog> employeesLogs;
            if (User.IsInRole("Leader"))
            {
                employeesLogs = await _employeesLogService.GetEmployeesLogsByApprovedAsync("Leader", DateTime.Now, userDepartment);
                foreach (var log in employeesLogs)
                {
                    log.LeaderApproved = true;
                    await _employeesLogService.UpdateAsync(log);
                }
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            if (User.IsInRole("ManageDepartmentShift"))
            {
                employeesLogs = await _employeesLogService.GetEmployeesLogsByApprovedAsync("ManageDepartmentShift", DateTime.Now, userDepartment);
                foreach (var log in employeesLogs)
                {
                    log.ManageDepartmentShiftApproved = true;
                    await _employeesLogService.UpdateAsync(log);
                }
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            if(User.IsInRole("Manager"))
            {
                employeesLogs = await _employeesLogService.GetEmployeesLogsByApprovedAsync("Manager", DateTime.Now, userDepartment);
                foreach (var log in employeesLogs)
                {
                    log.ManagerApproved = true;
                    await _employeesLogService.UpdateAsync(log);
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
                if(User.IsInRole("Leader"))
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

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}