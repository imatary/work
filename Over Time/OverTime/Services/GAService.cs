using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Lib.GA.Data;

namespace OverTime.Services
{
    public interface IGAService
    {
        Task<GAStaff> GetStaffByCode(string staffCode);
        Task<IEnumerable<MS_Department>> GetGaDepartments();
    }
    public class GAService : IGAService
    {
        private readonly GADbContext _gaDbContext;
        public GAService()
        {
            _gaDbContext = new GADbContext();
        }

        public async Task<GAStaff> GetStaffByCode(string staffCode)
        {
            object[] param =
            {
                new SqlParameter()
                {
                    ParameterName = "@staffCode",
                    Value = staffCode,
                    SqlDbType = SqlDbType.VarChar
                },
                new SqlParameter("@Out_Parameter", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                }
            };

            return await _gaDbContext.Database.SqlQuery<GAStaff>("EXEC [sp_GetStaffByCode] @staffCode", param).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<MS_Department>> GetGaDepartments()
        {
            return await _gaDbContext.Database.SqlQuery<MS_Department>("EXEC [sp_Get_All_Departments]").ToListAsync();
        }
    }
}