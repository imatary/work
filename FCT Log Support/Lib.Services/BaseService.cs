using System.Configuration;
using System.Data.SqlClient;

namespace Lib.Services
{
    public class BaseService
    {
        public bool CheckConnection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MESSystemDbContext"].ConnectionString; ;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
    }
}
