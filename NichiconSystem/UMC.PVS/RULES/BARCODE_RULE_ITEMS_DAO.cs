using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using UMC.DB;

namespace UMC.PVS.RULES
{
    public class BARCODE_RULE_ITEMS_DAO : BASE_DAO
    {
        private DBHelper dbHelper = new DBHelper();
        /// <summary>
        /// Constructor
        /// </summary>
        public BARCODE_RULE_ITEMS_DAO()
        {
            dbHelper.connectionString = connectionString;
        }
        /// <summary>
        /// Converts the DataReader to the List method
        /// </summary>
        private List<BARCODE_RULE_ITEMS> DataReaderToList(SqlDataReader dataReader)
        {
            List<BARCODE_RULE_ITEMS> List = new List<BARCODE_RULE_ITEMS>();
            BARCODE_RULE_ITEMS model = null;
            while (dataReader.Read())
            {
                model = new BARCODE_RULE_ITEMS();
                model.CONTENT = dataReader.GetString(0);
                model.CONTENT_LENGTH = dataReader.GetInt32(1);
                model.RANGE_CONTENT1 = dataReader.GetString(2);
                model.RANGE_CONTENT2 = dataReader.GetString(3);
                model.CUSTOM_CONTENT_LENGTH = dataReader.GetInt32(4);
                model.CUSTOM_CONTENT_LOCATION = dataReader.GetInt32(5);
                model.DESCRIPTION = dataReader.GetString(6);
                model.ID = dataReader.GetGuid(7);
                model.INDEX = dataReader.GetInt32(8);
                model.IS_CONVERSION_ENTRY = dataReader.GetBoolean(9);
                model.IS_FROM_RIGHT_TO_LEFT = dataReader.GetBoolean(10);
                model.IS_USING_CASE_IGNORING = dataReader.GetBoolean(11);
                model.IS_USING_CONTENT_CHECKING = dataReader.GetBoolean(12);
                model.IS_USING_CUSTOM_CONTENT = dataReader.GetBoolean(13);
                model.IS_USING_LENGTH_CHECKING = dataReader.GetBoolean(14);
                model.IS_USING_MULTIPLE_CONTENT = dataReader.GetBoolean(15);
                model.IS_USING_MULTIPLE_RANGE_CONTENT = dataReader.GetBoolean(16);
                model.IS_USING_RANGE_CONTENT = dataReader.GetBoolean(17);
                model.LENGTH = dataReader.GetInt32(18);
                model.LOCATION = dataReader.GetInt32(19);
                model.RULE_ID = dataReader.GetGuid(20);
                model.RULE_NAME = dataReader.GetString(21);
                model.RULE_NO = dataReader.GetString(22);
                model.UPDATE_TIME = dataReader.GetDateTime(23);
                model.UPDATER_NAME = dataReader.GetString(24);
                List.Add(model);
            }
            return List;
        }
        /// <summary>
        /// Lấy về tất cả bản ghi
        /// </summary>
        public List<BARCODE_RULE_ITEMS> GetAll()
        {
            string sql = "SELECT * FROM BARCODE_RULE_ITEMS";
            SqlDataReader dataReader = dbHelper.GetDataReader(sql);
            List<BARCODE_RULE_ITEMS> List = DataReaderToList(dataReader);
            dataReader.Close();
            return List;
        }
        /// <summary>
        /// Get by ID
        /// </summary>
        public BARCODE_RULE_ITEMS Get(Guid id)
        {
            string sql = "SELECT * FROM BARCODE_RULE_ITEMS WHERE ID=@ID";
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@ID", SqlDbType.UniqueIdentifier){ Value = id }
            };
            SqlDataReader dataReader = dbHelper.GetDataReader(sql, parameters);
            List<BARCODE_RULE_ITEMS> List = DataReaderToList(dataReader);
            dataReader.Close();
            return List.Count > 0 ? List[0] : null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public BARCODE_RULE_ITEMS Get(string name)
        {
            string sql = "SELECT TOP(1) * FROM BARCODE_RULE_ITEMS WHERE (RULE_NO=@RULE_NO) AND (RULE_NAME=@RULE_NAME)";
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@RULE_NO", SqlDbType.NVarChar, 128){ Value = name },
                new SqlParameter("@RULE_NAME", SqlDbType.NVarChar, 128){ Value = name }
            };
            SqlDataReader dataReader = dbHelper.GetDataReader(sql, parameters);
            List<BARCODE_RULE_ITEMS> List = DataReaderToList(dataReader);
            dataReader.Close();
            return List.Count > 0 ? List[0] : null;
        }
    }
}
