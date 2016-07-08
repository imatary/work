using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Threading.Tasks;
using OverTime.Models;

namespace OverTime.Services
{
    public interface IEmployeesLogService
    {
        Task<IEnumerable<EmployeesLog>> GetEmployeesLogsAsync();
        Task<IEnumerable<EmployeesLog>> GetEmployeesLogsYesterdayAsync(string staffCode, DateTime dateCheck);
        Task<IEnumerable<EmployeesLog>> GetEmployeesLogsByApprovedAsync(string roleName, DateTime dateCheck);
        Task<IEnumerable<EmployeesLog>> GetEmployeesLogsByApprovedAsync(string roleName, DateTime dateCheck, string departmentId);
        Task<IEnumerable<EmployeesLog>> GetEmployeesLogsByApprovedAsync(string roleName, DateTime dateCheck, IEnumerable<Department> departments);
        Task<IEnumerable<EmployeesLog>> GetEmployeesLogsByDeptIdAsync(string departmentId);
        Task<EmployeesLog> GetEmployeesLogsByIdAsync(Guid id);
        Task<EmployeesLog> CheckEmployeesLogExitsByStaffCodeAndDateCheckAysnc(string staffCode, DateTime dateCheck);
        Task CreateAsync(EmployeesLog employeesLog);
        Task UpdateAsync(EmployeesLog employeesLog);
        Task RemoveAsync(Guid id);
        Task<Employess> ApprovedAllByUserIdAsync(Guid id, string staffcode, DateTime date, string departmentId);
        Task<Employess> ApprovedByUserIdAsync(Guid id, string staffcode, string roleName);
    }
    public class EmployeesLogService : IEmployeesLogService
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public EmployeesLogService()
        {
            _applicationDbContext = new ApplicationDbContext();
        }

        public async Task<IEnumerable<EmployeesLog>> GetEmployeesLogsAsync()
        {
            return await _applicationDbContext.EmployeesLogs.ToListAsync();
        }

        public async Task<IEnumerable<EmployeesLog>> GetEmployeesLogsYesterdayAsync(string staffCode, DateTime dateCheck)
        {
            return await _applicationDbContext.EmployeesLogs.Where(
                        item =>
                            item.StaffCode == staffCode &&
                            item.DateCheck.Date == dateCheck.Date)
                        .ToListAsync();
        }

        public async Task<IEnumerable<EmployeesLog>> GetEmployeesLogsByApprovedAsync(string roleName, DateTime dateCheck)
        {
            IEnumerable<EmployeesLog> employeesLogs = await _applicationDbContext.EmployeesLogs.ToListAsync();
            if (roleName == "Leader")
            {
                return employeesLogs.Where(item => item.LeaderApproved == false && item.IsDelete == false && item.DateCheck.Date == dateCheck.Date);
            }
            if (roleName == "ManageDepartmentShift")
            {
                return employeesLogs.Where(item => item.ManageDepartmentShiftApproved == false && item.LeaderApproved && item.DateCheck.Date == dateCheck.Date);
            }
            if (roleName == "Manager")
            {
                return employeesLogs.Where(item => item.ManagerApproved == false && item.LeaderApproved && item.ManageDepartmentShiftApproved && item.DateCheck.Date == dateCheck.Date);
            }
            if (roleName == "GA")
            {
                return employeesLogs.Where(
                    item =>
                        item.GaComplete == false &&
                        item.LeaderApproved &&
                        item.ManageDepartmentShiftApproved &&
                        item.ManagerApproved &&
                        item.IsDelete == false &&
                        item.DateCheck.Date == dateCheck.Date);
            }
            if(roleName == "Admin")
            {
                return employeesLogs.Where(item => item.DateCheck.Date == dateCheck.Date);
            }
            return employeesLogs;
        }

        public async Task<IEnumerable<EmployeesLog>> GetEmployeesLogsByApprovedAsync(string roleName, DateTime dateCheck, string departmentId)
        {
            IEnumerable<EmployeesLog> employeesLogs = await _applicationDbContext.EmployeesLogs.ToListAsync();
            if (roleName == "Leader")
            {
                return employeesLogs.Where(
                    item => item.LeaderApproved == false &&
                            item.IsDelete == false &&
                            item.DateCheck.Date == dateCheck.Date &&
                            item.DepartmentID == departmentId);
            }
            if (roleName == "ManageDepartmentShift")
            {
                return employeesLogs.Where(
                    item =>
                        item.LeaderApproved == false &&
                        item.ManageDepartmentShiftApproved == false &&
                        item.IsDelete == false &&
                        item.DateCheck.Date == dateCheck.Date &&
                        item.DepartmentID == departmentId);
            }
            if (roleName == "Manager")
            {
                employeesLogs = employeesLogs.Where(
                    item =>
                        item.LeaderApproved == false &&
                        item.ManageDepartmentShiftApproved &&
                        item.ManagerApproved == false &&
                        item.IsDelete == false &&
                        item.DateCheck.Date == dateCheck.Date &&
                        item.DepartmentID == departmentId);

                return employeesLogs;
            }
            if (roleName == "GA")
            {
                return
                    employeesLogs.Where(
                        item =>
                            item.LeaderApproved == false &&
                            item.ManageDepartmentShiftApproved &&
                            item.ManagerApproved &&
                            item.GaComplete == false &&
                            item.IsDelete == false &&
                            item.DateCheck.Date == dateCheck.Date);
            }
            return employeesLogs;
        }

        public async Task<IEnumerable<EmployeesLog>> GetEmployeesLogsByApprovedAsync(string roleName, DateTime dateCheck, IEnumerable<Department> departments)
        {
            IEnumerable<EmployeesLog> employeesLogs = await _applicationDbContext.EmployeesLogs.ToListAsync();
            if (roleName == "Leader")
            {
                return employeesLogs.Where(
                    item => item.LeaderApproved == false &&
                            item.IsDelete == false &&
                            item.DateCheck.Date == dateCheck.Date &&
                            item.DepartmentID == departments.First().DepartmentID);
            }
            if (roleName == "ManageDepartmentShift")
            {
                IEnumerable<EmployeesLog> employeesLogsIds = employeesLogs.Where(
                    item =>
                        item.LeaderApproved &&
                        item.ManageDepartmentShiftApproved == false &&
                        item.IsDelete == false &&
                        item.DateCheck.Date == dateCheck.Date);
                List<EmployeesLog> employeesLogsByDeptIds = new List<EmployeesLog>();
                foreach (var department in departments)
                {
                    foreach (var log in employeesLogsIds)
                    {
                        if (log.DepartmentID == department.DepartmentID)
                        {
                            employeesLogsByDeptIds.Add(log);
                        }
                    }
                }
                employeesLogs = employeesLogsByDeptIds;

                return employeesLogs;
            }
            if (roleName == "Manager")
            {
                IEnumerable<EmployeesLog> employeesLogsIds =
                    employeesLogs.Where(
                        item =>
                            item.ManagerApproved == false && 
                            item.LeaderApproved && 
                            item.ManageDepartmentShiftApproved &&
                            item.DateCheck.Date == dateCheck.Date);

                List<EmployeesLog> employeesLogsByDeptIds = new List<EmployeesLog>();
                foreach (var department in departments)
                {
                    foreach (var log in employeesLogsIds)
                    {
                        if (log.DepartmentID == department.DepartmentID)
                        {
                            employeesLogsByDeptIds.Add(log);
                        }
                    }
                }
                employeesLogs = employeesLogsByDeptIds;

                return employeesLogs;
            }
            if (roleName == "GA")
            {
                return
                    employeesLogs.Where(
                        item =>
                            item.GaComplete == false && 
                            item.LeaderApproved && 
                            item.ManageDepartmentShiftApproved &&
                            item.ManagerApproved && 
                            item.IsDelete == false && 
                            item.DateCheck.Date == dateCheck.Date);
            }
            return employeesLogs;
        }

        public Task<IEnumerable<EmployeesLog>> GetEmployeesLogsByDeptIdAsync(string departmentId)
        {
            throw new NotImplementedException();
        }

        public async Task<EmployeesLog> GetEmployeesLogsByIdAsync(Guid id)
        {
            return await _applicationDbContext.EmployeesLogs.FirstOrDefaultAsync(item => item.Id == id);
        }

        public async Task<EmployeesLog> CheckEmployeesLogExitsByStaffCodeAndDateCheckAysnc(string staffCode, DateTime dateCheck)
        {
            return await _applicationDbContext.EmployeesLogs.Where(item => item.StaffCode == staffCode && item.DateCheck == dateCheck).FirstOrDefaultAsync();
        }

        public async Task CreateAsync(EmployeesLog employeesLog)
        {
            if (employeesLog != null)
            {
                _applicationDbContext.EmployeesLogs.Add(employeesLog);
                await _applicationDbContext.SaveChangesAsync();
            }
        }

        public async Task UpdateAsync(EmployeesLog employeesLog)
        {
            if (employeesLog != null)
            {
                _applicationDbContext.Entry(employeesLog).State = EntityState.Modified;
                await _applicationDbContext.SaveChangesAsync();
            }  
        }

        public async Task RemoveAsync(Guid id)
        {
            var log = await GetEmployeesLogsByIdAsync(id);
            if(log!=null)
            {
                _applicationDbContext.EmployeesLogs.Remove(log);
                await _applicationDbContext.SaveChangesAsync();
            }
        }
        public Task<Employess> ApprovedAllByUserIdAsync(Guid id, string staffcode, DateTime date, string departmentId)
        {
            throw new NotImplementedException();
        }

        public Task<Employess> ApprovedByUserIdAsync(Guid id, string staffcode, string roleName)
        {
            throw new NotImplementedException();
        }
    }
}