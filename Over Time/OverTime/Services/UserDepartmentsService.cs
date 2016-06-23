using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using OverTime.Models;

namespace OverTime.Services
{
    public interface IUserDepartmentsService
    {
        Task<IdentityResult> SetUserDepartmentsAsync(string userId, params string[] departmentIds);
        Task<IEnumerable<Department>> GetUserDepartmentsAsync(string userId);
        Task<Department> FindByIdAsync(string id);

        IEnumerable<Department> GetUserDepartments(string userId);
    }
    public class UserDepartmentsService : IUserDepartmentsService
    {
        private readonly ApplicationDbContext _context;
        public UserDepartmentsService()
        {
            _context = new ApplicationDbContext();
        }

        public async Task<IdentityResult> SetUserDepartmentsAsync(string userId, params string[] departmentIds)
        {
            //Clear current group membership:
            var currentDepartment = await this.GetUserDepartmentsAsync(userId);
            foreach (var department in currentDepartment)
            {
                department.UserDepartmentses.Remove(
                    department.UserDepartmentses.FirstOrDefault(gr => gr.ApplicationUserId == userId));
            }
            await _context.SaveChangesAsync();

            // Add the user to the new groups:
            foreach (string departmentId in departmentIds)
            {
                var newDepartment = await this.FindByIdAsync(departmentId);
                newDepartment.UserDepartmentses.Add(new UserDepartments()
                {
                    ApplicationUserId = userId,
                    DepartmentId = departmentId
                });
            }
            await _context.SaveChangesAsync();

            return IdentityResult.Success;
        }

        public async Task<IEnumerable<Department>> GetUserDepartmentsAsync(string userId)
        {
            //var userDepartments = (from g in this._context.Departments
            //                       join ud in _context.UserDepartmentses on g.DepartmentID equals ud.DepartmentId
            //                       where ud.ApplicationUserId == userId
            //                       //where g.UserDepartmentses.Where(u => u.ApplicationUserId == userId)
            //                       select g).ToListAsync();

            var userDepartments = (from g in this._context.Departments
                                   where g.UserDepartmentses.Any(u => u.ApplicationUserId == userId)
                                   select g).ToListAsync();
            return await userDepartments;
        }

        public IEnumerable<Department> GetUserDepartments(string userId)
        {
            var userDepartments = (from g in this._context.Departments
                                   where g.UserDepartmentses.Any(u => u.ApplicationUserId == userId)
                                   select g).ToList();
            return userDepartments;
        }
        public async Task<Department> FindByIdAsync(string id)
        {
            return await _context.Departments.FindAsync(id);
        }
    }

}