using Dapper;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace UMC.Services
{
    public class QA_BaseService
    {
        private readonly string ConnectionString = ConfigurationManager.ConnectionStrings["ShippingFujiXeroxDbContext"].ConnectionString;

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

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DateTime GetDatabaseTime()
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                var cmd = new SqlCommand("SELECT GETDATE()", conn);
                conn.Open();

                return (DateTime)cmd.ExecuteScalar();
            }
        }
    }
}
