using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using UMC.DB;

namespace UMC.PVS.USERS
{
    public class USERS_DAO : BASE_DAO
    {
        private DBHelper dbHelper = new DBHelper();
        
        /// <summary>
        /// Constructor
        /// </summary>
        public USERS_DAO()
        {
            dbHelper.connectionString = connectionString;
        }
        /// <summary>
        /// Converts the DataReader to the List method
        /// </summary>
        private List<USERS> DataReaderToList(SqlDataReader dataReader)
        {
            List<USERS> List = new List<USERS>();
            USERS model = null;
            while (dataReader.Read())
            {
                model = new USERS();
                model.DESCRIPTION = dataReader.GetString(0);
                model.ID = dataReader.GetString(1);
                model.NAME = dataReader.GetString(2);
                model.PASSWORD = dataReader.GetString(3);
                List.Add(model);
            }
            return List;
        }
        /// <summary>
        /// Lấy về tất cả bản ghi
        /// </summary>
        public List<USERS> GetAll()
        {
            string sql = "SELECT * FROM USERS";
            SqlDataReader dataReader = dbHelper.GetDataReader(sql);
            List<USERS> List = DataReaderToList(dataReader);
            dataReader.Close();
            return List;
        }
        /// <summary>
        /// Get by ID
        /// </summary>
        public USERS Get(string id)
        {
            string sql = "SELECT * FROM USERS WHERE ID=@ID";
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@ID", SqlDbType.NVarChar, 128){ Value = id }
            };
            SqlDataReader dataReader = dbHelper.GetDataReader(sql, parameters);
            List<USERS> List = DataReaderToList(dataReader);
            dataReader.Close();
            return List.Count > 0 ? List[0] : null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public USERS Get(string username, string password)
        {
            string sql = "SELECT * FROM USERS WHERE (ID=@ID) AND (PASSWORD=@PASSWORD)";
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@ID", SqlDbType.NVarChar, 128){ Value = username },
                new SqlParameter("@PASSWORD", SqlDbType.NVarChar, 128){ Value = password },
            };
            SqlDataReader dataReader = dbHelper.GetDataReader(sql, parameters);
            List<USERS> List = DataReaderToList(dataReader);
            dataReader.Close();
            return List.Count > 0 ? List[0] : null;
        }
    }
}
