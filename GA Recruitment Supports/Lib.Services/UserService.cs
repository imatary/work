using Lib.Data;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Lib.Services
{
    public interface IUserService
    {
        User GetUserByUserName(string userName);
        bool CheckLogin(string userName, string password);
    }
    public class UserService : IUserService
    {
        private readonly GARecruitmentEntities _context;
        public UserService()
        {
            _context = new GARecruitmentEntities();
        }
        public bool CheckLogin(string userName, string password)
        {
            object[] param =
            {
                new SqlParameter() { ParameterName = "@userName", Value = userName, SqlDbType = SqlDbType.VarChar},
                new SqlParameter() { ParameterName = "@password", Value = password, SqlDbType = SqlDbType.VarChar},
                new SqlParameter("@Out_Parameter", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                }
            };
            try
            {
                var user = _context.Database.SqlQuery<User>("EXEC [dbo].[sp_CheckLogin] @userName, @password", param).FirstOrDefault();
                if (user != null)
                {
                    return true;
                }
                return false;   
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public User GetUserByUserName(string userName)
        {
            var param = new SqlParameter()
            {
                ParameterName = "@userName",
                SqlDbType = SqlDbType.VarChar,
                Value = userName,
            };
            try
            {
                return _context.Database.SqlQuery<User>("EXEC [dbo].[sp_GetUserByUserName] @userName", param).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
