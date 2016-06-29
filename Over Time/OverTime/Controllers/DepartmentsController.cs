using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using OverTime.Models;
using OverTime.Services;

namespace OverTime.Controllers
{
    [Authorize(Roles = "Admin")]
    public class DepartmentsController : Controller
    {
        private readonly IDepartmentService _departmentService;
        private readonly IGAService _gaService;

        public DepartmentsController(
            IDepartmentService departmentService, 
            IGAService gaService)
        {
            _departmentService = departmentService;
            _gaService = gaService;
        }

        // GET: Departments
        public async Task<ActionResult> Index()
        {
            //var departments = await _gaService.GetGaDepartments();
            //foreach (var department in departments)
            //{
            //    var currentDeptpartment = await _departmentService.GetDepartmentByIdAsync(department.DeptCode);
            //    if (currentDeptpartment == null)
            //    {
            //        var addDepartment = new Department()
            //        {
            //            DepartmentID = department.DeptCode,
            //            Name = department.DeptName,
            //            ParentID = "Root",
            //            Description = "Dept " + department.DeptName,
            //            Sort = await _departmentService.MaxSortAsync()
            //        };
            //        try
            //        {
            //            await _departmentService.CreateAsync(addDepartment);
            //        }
            //        catch (Exception ex)
            //        {
            //            throw new Exception(ex.Message);
            //        }

            //    }
            //}
            return View(await _departmentService.GetDepartmentsAsync());
        }

        // GET: Departments/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department department = await _departmentService.GetDepartmentByIdAsync(id);
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }

        // GET: Departments/Create
        public async Task<ActionResult> Create()
        {
            var departments = await _departmentService.GetDepartmentsAsync();
            List<SelectListItem> items = new List<SelectListItem>();
                // departments
                //.Select(d =>
                //    new SelectListItem()
                //    {
                //        Value = d.DepartmentID,
                //        Text = d.Name,
                //    }).ToList();
            SelectListItem root = new SelectListItem()
            {
                Value = "Root",
                Text = "---Root---",
                Selected = true,
            };
            items.Add(root);
            foreach (var department in departments.Where(d=>d.ParentID== "Root"))
            {
                SelectListItem itemDept = new SelectListItem()
                {
                    Value = department.DepartmentID,
                    Text = department.Name,
                };
                items.Add(itemDept);
            }
            ViewBag.ParentID = items;
            return View();
        }

        // POST: Departments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "DepartmentID,Name,Description,ParentID,Sort")] Department department)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    department.Sort = await _departmentService.MaxSortAsync();
                    await _departmentService.CreateAsync(department);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                return RedirectToAction("Index");
            }

            return View(department);
        }

        // GET: Departments/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department department = await _departmentService.GetDepartmentByIdAsync(id);
            if (department == null)
            {
                return HttpNotFound();
            }
            var departments = await _departmentService.GetDepartmentsAsync();
            List<SelectListItem> items = new List<SelectListItem>();
            SelectListItem root = new SelectListItem()
            {
                Value = "Root",
                Text = "---Root---",
                Selected = true,
            };
            items.Add(root);
            foreach (var dept in departments.Where(d => d.ParentID == "Root"))
            {
                SelectListItem itemDept = new SelectListItem()
                {
                    Value = dept.DepartmentID,
                    Text = dept.Name,
                };
                items.Add(itemDept);
            }
            ViewBag.ParentID = items;
            return View(department);
        }

        // POST: Departments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "DepartmentID,Name,Description,ParentID,Sort")] Department department)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _departmentService.UpdateAsync(department);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                return RedirectToAction("Index");
            }
            return View(department);
        }

        // GET: Departments/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            try
            {
                await _departmentService.DeleteAsync(id);
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
