using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Threading.Tasks;
using OverTime.Infrastructure;
using OverTime.Models;
using OverTime.Repositories;

namespace OverTime.Services
{
    public interface IEmployeesService
    {
        IEnumerable<Employess> GetEmployesses();
        Task<IEnumerable<Employess>> GetEmployessesAsync();
        Task<Employess> GetEmployessByIdAsync(string id);
        Task<IEnumerable<Employess>> FindEmployessesByDateAsync(DateTime date);
        Task<IEnumerable<Employess>> FindEmployessesByDateAsync(DateTime date, string departmentId);
        Task<Employess> GetEmployesByIdAsync(Guid id, string staffCode);
        Employess GetEmployessByIdAndDate(string staffCode, DateTime dateCheck);
        Task<IEnumerable<Employess>> GetEmployessYesterDayByIdAndDateAsync(DateTime date, string departmentId);
        Task<Employess> GetEmployessByIdAndDateAsync(string staffCode, DateTime date);
        Task<Employess> GetEmployessByIdAndDateAsync(string staffCode, DateTime date, string departmentId);
        Task<IEnumerable<Employess>> GetEmployeesYesterdayAsync(string staffCode, DateTime dateCheck, string departmentId);
        Task<IEnumerable<Employess>> GetEmployeesYesterdayAsync(DateTime dateCheck, string departmentId);
        IEnumerable<Employess> GetEmployeesYesterday(DateTime dateCheck);
        IEnumerable<Employess> GetEmployeesYesterday(DateTime dateCheck, string departmentId);
        Task<Employess> ApprovedAllByUserIdAsync(Guid id, string staffcode, DateTime date, string departmentId);
        Task<Employess> ApprovedByUserIdAsync(Guid id, string staffcode, string roleName);
        Task RemoveAsync(Guid id, string staffCode);
        Task CreateAsync(Employess employess);
    }
    public class EmployeesService : IEmployeesService
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public EmployeesService()
        {
            _applicationDbContext = new ApplicationDbContext();
        }

        public IEnumerable<Employess> GetEmployesses()
        {
            return _applicationDbContext.Employesses.ToList();
        }

        public async Task<IEnumerable<Employess>> GetEmployessesAsync()
        {
            return await _applicationDbContext.Employesses.ToListAsync();
        }

        public async Task<Employess> GetEmployessByIdAsync(string id)
        {
            return await _applicationDbContext.Employesses.FindAsync(id);
        }

        public async Task<IEnumerable<Employess>> FindEmployessesByDateAsync(DateTime date)
        {
            return await _applicationDbContext.Employesses.Where(
                        item => EntityFunctions.TruncateTime(item.DateCheck) == date.Date).ToListAsync();
        }

        public async Task<IEnumerable<Employess>> FindEmployessesByDateAsync(DateTime date, string departmentId)
        {
            return await _applicationDbContext.Employesses.Where(
                item =>
                    item.DepartmentID == departmentId &&
                    EntityFunctions.TruncateTime(item.DateCheck) == date.Date).ToListAsync();
        }

        public Task<Employess> GetEmployesByIdAsync(Guid id, string staffCode)
        {
            return _applicationDbContext.Employesses.FindAsync(id, staffCode);
        }

        public Employess GetEmployessByIdAndDate(string staffCode, DateTime dateCheck)
        {
            return _applicationDbContext.Employesses.FirstOrDefault(item => item.StaffCode == staffCode && item.DateCheck.ToString("d") == dateCheck.ToString("d"));
        }

        public async Task<IEnumerable<Employess>> GetEmployessYesterDayByIdAndDateAsync(DateTime date, string departmentId)
        {
            return await _applicationDbContext.Employesses.Where(
                item => item.DepartmentID == departmentId &&
                        EntityFunctions.TruncateTime(item.DateCheck) == date.Date).ToListAsync();
        }

        public async Task<Employess> GetEmployessByIdAndDateAsync(string staffCode, DateTime date)
        {
            return await _applicationDbContext.Employesses.Where(
                item => item.StaffCode == staffCode &&
                        EntityFunctions.TruncateTime(item.DateCheck) == date.Date).FirstOrDefaultAsync();
        }

        public async Task<Employess> GetEmployessByIdAndDateAsync(string staffCode, DateTime date, string departmentId)
        {
            return await _applicationDbContext.Employesses.Where(
                item => item.StaffCode == staffCode &&
                        item.DepartmentID == departmentId &&
                        EntityFunctions.TruncateTime(item.DateCheck) == date.Date).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Employess>> GetEmployeesYesterdayAsync(string staffCode, DateTime dateCheck, string departmentId)
        {
            return await _applicationDbContext.Employesses.Where(
                item =>
                    item.StaffCode == staffCode &&
                    item.DepartmentID == departmentId &&
                    EntityFunctions.TruncateTime(item.DateCheck) == dateCheck.Date)
                .ToListAsync();
        }

        public async Task<IEnumerable<Employess>> GetEmployeesYesterdayAsync(DateTime dateCheck, string departmentId)
        {
            return await _applicationDbContext.Employesses.Where(
                item =>
                    item.DepartmentID == departmentId &&
                    EntityFunctions.TruncateTime(item.DateCheck) == dateCheck.Date)
                .ToListAsync();
        }

        public IEnumerable<Employess> GetEmployeesYesterday(DateTime dateCheck)
        {
            return _applicationDbContext.Employesses.Where(
                item =>
                    EntityFunctions.TruncateTime(item.DateCheck) == dateCheck.Date)
                .ToList();
        }

        public IEnumerable<Employess> GetEmployeesYesterday(DateTime dateCheck, string departmentId)
        {
            return _applicationDbContext.Employesses.Where(
                item =>
                    item.DepartmentID == departmentId &&
                    EntityFunctions.TruncateTime(item.DateCheck) == dateCheck.Date)
                .ToList();
        }

        public Task<Employess> ApprovedAllByUserIdAsync(Guid id, string staffcode, DateTime date, string departmentId)
        {
            throw new NotImplementedException();
        }

        public async Task<Employess> ApprovedByUserIdAsync(Guid id, string staffcode, string roleName)
        {
            var emp = await GetEmployesByIdAsync(id, staffcode);
            if (emp != null)
            {
                if (roleName == "Leader")
                {
                    emp.LeaderApproved = true;
                }else if (roleName == "Manager")
                {
                    emp.ManagerApproved = true;
                }
                else if(roleName=="GA")
                {
                    emp.GaComplete = true;
                }
                _applicationDbContext.Employesses.Attach(emp);
                _applicationDbContext.Entry(emp).State = EntityState.Modified;
                await _applicationDbContext.SaveChangesAsync();
            }
            return null;
        }

        public async Task RemoveAsync(Guid id, string staffCode)
        {
            var emp = await GetEmployesByIdAsync(id, staffCode);
            if (emp != null)
            {
                _applicationDbContext.Employesses.Remove(emp);
                await _applicationDbContext.SaveChangesAsync();
            }
        }

        public async Task CreateAsync(Employess employess)
        {
            if (employess == null)
            {
                throw new Exception("Create faild!");
            }
            _applicationDbContext.Employesses.Add(employess);
            await _applicationDbContext.SaveChangesAsync();
        }
    }
}