using Dapper;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace UMC.Services
{
    public class PVS_BaseService
    {
        private readonly string ConnectionString = ConfigurationManager.ConnectionStrings["MESSystemDbContext"].ConnectionString;

        public IDbConnection GetOpenConnection()
        {
            IDbConnection connection = new SqlConnection(ConnectionString); ;
            SimpleCRUD.SetDialect(SimpleCRUD.Dialect.SQLServer);
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            return connection;
        }
    }
}
