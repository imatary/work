using System.Data;
using System.Data.SqlClient;

namespace UMC.DB
{
    /// <summary>
    /// SQLSERVER
    /// </summary>
    public class DBHelper
    {
        public DBHelper()
        {
            this.connectionString = "";
        }
        public DBHelper(string connString)
        {
            this.connectionString = connString;
        }
        public string connectionString;
        private SqlConnection connection;
        /// <summary>
        /// 
        /// </summary>
        public string ConnectionString
        {
            get { return this.connectionString; }
        }
        /// <summary>
        /// 
        /// </summary>
        public SqlConnection Connection
        {
            get
            {
                if (this.connection == null)
                {
                    this.connection = new SqlConnection(this.connectionString);
                    this.connection.Open();
                }
                else if (this.connection.State != ConnectionState.Open)
                {
                    this.connection.Open();
                }
                return this.connection;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            if (this.connection != null && this.connection.State != ConnectionState.Closed)
            {
                this.connection.Close();
            }
            this.connection.Dispose();
        }

        /// <summary>
        /// SqlDataReader
        /// </summary>
        /// <param name="sql">sql</param>
        /// <returns></returns>
        public SqlDataReader GetDataReader(string sql)
        {
            this.connection = new SqlConnection(ConnectionString);
            this.connection.Open();
            using (SqlCommand cmd = new SqlCommand(sql, this.connection))
            {
                cmd.Prepare();
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
        }

        /// <summary>
        /// SqlDataReader
        /// </summary>
        /// <param name="sql">sql</param>
        /// <returns></returns>
        public SqlDataReader GetDataReader(string sql, SqlParameter[] parameter)
        {
            this.connection = new SqlConnection(ConnectionString);
            this.connection.Open();
            using (SqlCommand cmd = new SqlCommand(sql, this.connection))
            {
                if (parameter != null && parameter.Length > 0)
                    cmd.Parameters.AddRange(parameter);
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                cmd.Parameters.Clear();
                cmd.Prepare();
                return dr;
            }
        }

        /// <summary>
        /// DataTable
        /// </summary>
        /// <param name="sql">sql</param>
        /// <returns></returns>
        public DataTable GetDataTable(string sql)
        {
            using (this.connection = new SqlConnection(ConnectionString))
            {
                this.connection.Open();
                using (SqlCommand cmd = new SqlCommand(sql, this.connection))
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(dr);
                    dr.Close();
                    dr.Dispose();
                    cmd.Prepare();
                    return dt;
                }
            }
        }

        /// <summary>
        /// DataTable
        /// </summary>
        /// <param name="sql">sql</param>
        /// <returns></returns>
        public DataTable GetDataTable(string sql, SqlParameter[] parameter)
        {
            using (this.connection = new SqlConnection(ConnectionString))
            {
                this.connection.Open();
                using (SqlCommand cmd = new SqlCommand(sql, this.connection))
                {
                    if (parameter != null && parameter.Length > 0)
                        cmd.Parameters.AddRange(parameter);
                    SqlDataReader dr = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(dr);
                    dr.Close();
                    dr.Dispose();
                    cmd.Parameters.Clear();
                    cmd.Prepare();
                    return dt;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public DataSet GetDataSet(string sql)
        {
            using (this.connection = new SqlConnection(ConnectionString))
            {
                this.connection.Open();
                using (SqlDataAdapter dap = new SqlDataAdapter(sql, this.connection))
                {
                    DataSet ds = new DataSet();
                    dap.Fill(ds);
                    return ds;
                }
            }
        }

        /// <summary>
        /// SQL
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public int Execute(string sql)
        {
            using (this.connection = new SqlConnection(ConnectionString))
            {
                this.connection.Open();
                using (SqlCommand cmd = new SqlCommand(sql, this.connection))
                {
                    cmd.Prepare();
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// SQL
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public int Execute(string sql, SqlParameter[] parameter)
        {
            using (this.connection = new SqlConnection(ConnectionString))
            {
                this.connection.Open();
                using (SqlCommand cmd = new SqlCommand(sql, this.connection))
                {
                    if (parameter != null && parameter.Length > 0)
                        cmd.Parameters.AddRange(parameter);
                    int i = cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                    cmd.Prepare();
                    return i;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public string ExecuteScalar(string sql)
        {
            using (this.connection = new SqlConnection(ConnectionString))
            {
                this.connection.Open();
                using (SqlCommand cmd = new SqlCommand(sql, this.connection))
                {
                    object obj = cmd.ExecuteScalar();
                    cmd.Prepare();
                    return obj != null ? obj.ToString() : string.Empty;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public string ExecuteScalar(string sql, SqlParameter[] parameter)
        {
            using (this.connection = new SqlConnection(ConnectionString))
            {
                this.connection.Open();
                using (SqlCommand cmd = new SqlCommand(sql, this.connection))
                {
                    if (parameter != null && parameter.Length > 0)
                        cmd.Parameters.AddRange(parameter);
                    object obj = cmd.ExecuteScalar();
                    cmd.Parameters.Clear();
                    cmd.Prepare();
                    return obj != null ? obj.ToString() : string.Empty;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sql">sql</param>
        /// <returns></returns>
        public string GetFields(string sql, SqlParameter[] param)
        {
            using (this.connection = new SqlConnection(ConnectionString))
            {
                this.connection.Open();
                System.Text.StringBuilder names = new System.Text.StringBuilder(500);
                using (SqlCommand cmd = new SqlCommand(sql, this.connection))
                {
                    if (param != null && param.Length > 0)
                        cmd.Parameters.AddRange(param);
                    SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SchemaOnly);
                    for (int i = 0; i < dr.FieldCount; i++)
                    {
                        names.Append("[" + dr.GetName(i) + "]" + (i < dr.FieldCount - 1 ? "," : string.Empty));
                    }
                    cmd.Parameters.Clear();
                    dr.Close();
                    dr.Dispose();
                    cmd.Prepare();
                    return names.ToString();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public string GetFields(string sql, SqlParameter[] param, out string tableName)
        {
            using (this.connection = new SqlConnection(ConnectionString))
            {
                this.connection.Open();
                System.Text.StringBuilder names = new System.Text.StringBuilder(500);
                using (SqlCommand cmd = new SqlCommand(sql, this.connection))
                {
                    if (param != null && param.Length > 0)
                        cmd.Parameters.AddRange(param);
                    SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SchemaOnly);
                    tableName = dr.GetSchemaTable().TableName;
                    for (int i = 0; i < dr.FieldCount; i++)
                    {
                        names.Append("[" + dr.GetName(i) + "]" + (i < dr.FieldCount - 1 ? "," : string.Empty));
                    }
                    cmd.Parameters.Clear();
                    dr.Close();
                    dr.Dispose();
                    cmd.Prepare();
                    return names.ToString();
                }
            }
        }

    }
}
