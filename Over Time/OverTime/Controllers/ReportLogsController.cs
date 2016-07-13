using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using OverTime.Models;
using OverTime.Services;

namespace OverTime.Controllers
{
    [Authorize]
    public class ReportLogsController : Controller
    {
        private readonly IEmployeesService _employeesService;
        private readonly IUserDepartmentsService _userDepartmentsService;
        public ReportLogsController(IEmployeesService employeesService, 
            IUserDepartmentsService userDepartmentsService)
        {
            _employeesService = employeesService;
            _userDepartmentsService = userDepartmentsService;
        }

        // GET: ReportLogs
        public async Task<ActionResult> Index(string searchKey)
        {
            var userDepartment = await _userDepartmentsService.GetUserDepartmentsAsync(User.Identity.GetUserId());
            var departments = userDepartment as IList<Department> ?? userDepartment.ToList();
            var employess = await _employeesService.FindEmployessesByDateAsync(DateTime.Now);  
            if(!string.IsNullOrEmpty(searchKey))
            {
                try
                {
                    DateTime dateSearch = DateTime.ParseExact(searchKey, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    foreach (var department in departments)
                    {
                        employess = await _employeesService.FindEmployessesByDateAsync(dateSearch, department.DepartmentID);
                    }  
                }
                catch (Exception ex)
                {
                    ViewBag.ErrorMessage = $"Invalid date {searchKey}." + ex.Message;
                }
            }
            else
            {
                foreach (var dept in departments)
                {
                    employess = employess.Where(item => item.DepartmentID == dept.DepartmentID);
                }
            }
            return View(employess);
        }
    }
}