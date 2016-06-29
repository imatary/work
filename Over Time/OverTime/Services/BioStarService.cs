using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Lib.Models;

namespace OverTime.Services
{
    public interface IBioStarService
    {
        Task<TB_USER> GetUserById(string userId);

        Task<IEnumerable<UserInfo>> GetExportsUserInfoAsync();
    }
    public class BioStarService : IBioStarService
    {
        private readonly BioStarDbContext _bioStarDbContext;
        public BioStarService()
        {
            _bioStarDbContext = new BioStarDbContext();
        }
        public async Task<TB_USER> GetUserById(string userId)
        {
            object[] param =
            {
                new SqlParameter()
                {
                    ParameterName = "userId",
                    Value = userId,
                    SqlDbType = SqlDbType.VarChar
                },
                new SqlParameter("@Out_Parameter", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                }
            };

            return await _bioStarDbContext.Database.SqlQuery<TB_USER>("EXEC sp_GetUserByID @userId", param).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<UserInfo>> GetExportsUserInfoAsync()
        {
            return await _bioStarDbContext.Database.SqlQuery<UserInfo>("EXEC [sp_GetExportsUserInfo]").ToListAsync();
        }
    }
}