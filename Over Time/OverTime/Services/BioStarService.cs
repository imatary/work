using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Lib.Models;

namespace OverTime.Services
{
    public interface IBioStarService
    {
        Task<TB_USER> GetUserById(string userId);

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
    }
}