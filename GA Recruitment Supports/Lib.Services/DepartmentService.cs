using Lib.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lib.Services
{
    public interface IDepartmentService
    {
        List<MS_Department> GetDepartments();
    }
    public class DepartmentService : IDepartmentService
    {
        private readonly GADbContext _context;
        public DepartmentService()
        {
            _context = new GADbContext();
        }
        public List<MS_Department> GetDepartments()
        {
            try
            {
                return _context.Database.SqlQuery<MS_Department>("EXEC [dbo].[sp_Get_Departments]").ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
