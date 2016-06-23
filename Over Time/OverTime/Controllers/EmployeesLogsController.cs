using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OverTime.Models;

namespace OverTime.Controllers
{
    public class EmployeesLogsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: EmployeesLogs
        public async Task<ActionResult> Index()
        {
            var employeesLogs = db.EmployeesLogs.Include(e => e.Department);
            return View(await employeesLogs.ToListAsync());
        }

        // GET: EmployeesLogs/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeesLog employeesLog = await db.EmployeesLogs.FindAsync(id);
            if (employeesLog == null)
            {
                return HttpNotFound();
            }
            return View(employeesLog);
        }

        // GET: EmployeesLogs/Create
        public ActionResult Create()
        {
            ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentID", "Name");
            return View();
        }

        // POST: EmployeesLogs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,StaffCode,FullName,DateCheck,DepartmentID,Note,LeaderApproved,ManagerApproved,GaComplete")] EmployeesLog employeesLog)
        {
            if (ModelState.IsValid)
            {
                employeesLog.Id = Guid.NewGuid();
                db.EmployeesLogs.Add(employeesLog);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentID", "Name", employeesLog.DepartmentID);
            return View(employeesLog);
        }

        // GET: EmployeesLogs/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeesLog employeesLog = await db.EmployeesLogs.FindAsync(id);
            if (employeesLog == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentID", "Name", employeesLog.DepartmentID);
            return View(employeesLog);
        }

        // POST: EmployeesLogs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,StaffCode,FullName,DateCheck,DepartmentID,Note,LeaderApproved,ManagerApproved,GaComplete")] EmployeesLog employeesLog)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employeesLog).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentID", "Name", employeesLog.DepartmentID);
            return View(employeesLog);
        }

        // GET: EmployeesLogs/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeesLog employeesLog = await db.EmployeesLogs.FindAsync(id);
            if (employeesLog == null)
            {
                return HttpNotFound();
            }
            return View(employeesLog);
        }

        // POST: EmployeesLogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            EmployeesLog employeesLog = await db.EmployeesLogs.FindAsync(id);
            db.EmployeesLogs.Remove(employeesLog);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
