using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Lib.Models;
using OverTime.Infrastructure;
using OverTime.Models;
using OverTime.Repositories;

namespace OverTime.Services
{
    public interface IDepartmentService
    {
        Task<IEnumerable<Department>> GetDepartmentsAsync();
        Task<Department> GetDepartmentByIdAsync(string id);
        Task<IEnumerable<Department>> GetUserDepartmentsAsync(string userId);
        Task CreateAsync(Department department);
        Task UpdateAsync(Department department);
        Task DeleteAsync(string id);
        Task<TB_USER_DEPT> GetBiosDepartmentByIdAsync(int id);
        Task<TB_USER_DEPT> GetBiosDepartmentByNameAsync(string sName);
        Task<int> MaxSortAsync();
    }
    public class DepartmentService : IDepartmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly BioStarDbContext _bioStarDbContext;
        private readonly ApplicationDbContext _applicationDbContext;

        public DepartmentService(IUnitOfWork unitOfWork, IDepartmentRepository departmentRepository)
        {
            _unitOfWork = unitOfWork;
            _departmentRepository = departmentRepository;
            _bioStarDbContext = new BioStarDbContext();
            _applicationDbContext = new ApplicationDbContext();
        }

        public async Task<IEnumerable<Department>> GetDepartmentsAsync()
        {
            return await _applicationDbContext.Departments.OrderBy(d => d.DepartmentID).ToListAsync();
        }

        public async Task<Department> GetDepartmentByIdAsync(string id)
        {
            return await _applicationDbContext.Departments.FindAsync(id);
        }

        public async Task<IEnumerable<Department>> GetUserDepartmentsAsync(string userId)
        {
            //var userDepartments = (from g in this._context.Departments
            //                       join ud in _context.UserDepartmentses on g.DepartmentID equals ud.DepartmentId
            //                       where ud.ApplicationUserId == userId
            //                       //where g.UserDepartmentses.Where(u => u.ApplicationUserId == userId)
            //                       select g).ToListAsync();

            var userDepartments = (from g in _applicationDbContext.Departments
                                   where g.UserDepartmentses.Any(u => u.ApplicationUserId == userId)
                                   select g).ToListAsync();
            return await userDepartments;
        }

        public async Task CreateAsync(Department department)
        {
            if(department != null)
            {
                _applicationDbContext.Departments.Add(department);
                await _applicationDbContext.SaveChangesAsync();
            }
        }

        public async Task UpdateAsync(Department department)
        {
            if(department != null)
            {
                _applicationDbContext.Entry(department).State = EntityState.Modified;
                await _applicationDbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(string id)
        {
            if(id!=null)
            {
                var department = await GetDepartmentByIdAsync(id);
                if(department!=null)
                {
                    _applicationDbContext.Departments.Remove(department);
                    await _applicationDbContext.SaveChangesAsync();
                }
            }
        }

        public async Task<TB_USER_DEPT> GetBiosDepartmentByIdAsync(int id)
        {
            return await _bioStarDbContext.TB_USER_DEPT.FindAsync(id);
        }
        public async Task<TB_USER_DEPT> GetBiosDepartmentByNameAsync(string sName)
        {
            return await _bioStarDbContext.TB_USER_DEPT.FirstOrDefaultAsync(d => d.sName == sName);
        }

        public async Task<int> MaxSortAsync()
        {
            var departments = await GetDepartmentsAsync();
            var max = departments.Max(d => d.Sort);
            if (max != null)
                return max.Value + 1;
            return 0;
        }
    }
}