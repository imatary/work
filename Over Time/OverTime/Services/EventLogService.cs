using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Lib.Models;
using OverTime.Models;

namespace OverTime.Services
{
    public interface IEventLogService
    {
        Task<IEnumerable<EventLog>> GetLogsUsers(string userId, DateTime startDate, DateTime endDate, string readerId);
        Task<IEnumerable<Department>> GetUserDepartmentsAsync(string userId);

        Task<TB_USER_DEPT> GetBiosDepartmentByIdAsync(int id);
        Task<TB_USER_DEPT> GetBiosDepartmentByNameAsync(string sName);
    }
    public class EventLogService : IEventLogService
    {
        private readonly BioStarDbContext _bioStarDbContext;
        private readonly ApplicationDbContext _applicationDbContext;
        public EventLogService()
        {
            _bioStarDbContext=new BioStarDbContext();
            _applicationDbContext = new ApplicationDbContext();
        }
        public async Task<IEnumerable<EventLog>> GetLogsUsers(string userId, DateTime startDate, DateTime endDate, string readerId)
        {
            TimeSpan startTime = new TimeSpan(08, 00, 00);
            TimeSpan endTime = new TimeSpan(06, 20, 00);
            var userDepartment = await GetUserDepartmentsAsync(userId);
            var biosDepartment = await GetBiosDepartmentByNameAsync(userDepartment.First().DepartmentID);
            object[] param =
            {
                new SqlParameter() { ParameterName = "startTime", Value = startDate.Subtract(startTime).ToString("yyyyMMdd HH:mm:ss"), SqlDbType = SqlDbType.VarChar},
                new SqlParameter() { ParameterName = "endTime", Value = endDate.Subtract(endTime).ToString("yyyyMMdd HH:mm:ss"), SqlDbType = SqlDbType.VarChar},
                new SqlParameter() { ParameterName = "readerId", Value = readerId, SqlDbType = SqlDbType.Int },
                new SqlParameter() { ParameterName = "departmentId", Value = biosDepartment.nDepartmentIdn, SqlDbType = SqlDbType.Int },
                new SqlParameter("@Out_Parameter", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                }
            };
            var logs = _bioStarDbContext.Database.SqlQuery<EventLog>("EXEC sp_GetEventLogByDate @startTime, @endTime, @readerId, @departmentId", param)
                .GroupBy(p => p.nUserID)
                .Select(p =>
                    new EventLog()
                    {
                        nUserID = p.Key,
                        sUserName = p.FirstOrDefault()?.sUserName,
                        nReaderIdn = p.First().nReaderIdn,
                        nUserIdn = p.First().nUserID,
                        nDepartmentIdn = p.First().nDepartmentIdn,
                        DepartmentName = p.First().DepartmentName,
                    }).ToList();


            return logs;
        }

        public async Task<IEnumerable<Department>> GetUserDepartmentsAsync(string userId)
        {
            //var userDepartments = (from g in this._context.Departments
            //                       join ud in _context.UserDepartmentses on g.DepartmentID equals ud.DepartmentId
            //                       where ud.ApplicationUserId == userId
            //                       //where g.UserDepartmentses.Where(u => u.ApplicationUserId == userId)
            //                       select g).ToListAsync();

            var userDepartments = (from g in this._applicationDbContext.Departments
                                   where g.UserDepartmentses.Any(u => u.ApplicationUserId == userId)
                                   select g).ToListAsync();
            return await userDepartments;
        }

        public async Task<TB_USER_DEPT> GetBiosDepartmentByIdAsync(int id)
        {
            return await _bioStarDbContext.TB_USER_DEPT.FindAsync(id);
        }
        public async Task<TB_USER_DEPT> GetBiosDepartmentByNameAsync(string sName)
        {
            return await _bioStarDbContext.TB_USER_DEPT.FirstOrDefaultAsync(d => d.sName == sName);
        }

    }
}