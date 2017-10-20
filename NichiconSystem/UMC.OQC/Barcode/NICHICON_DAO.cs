using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using UMC.DB;

namespace UMC.OQC.Barcode
{
    public class NICHICON_DAO : BASE_DAO
    {
        private DBHelper dbHelper = new DBHelper();
        /// <summary>
        /// Constructor
        /// </summary>
        public NICHICON_DAO()
        {
            dbHelper.connectionString = connectionString;
        }
        /// <summary>
        /// Add a record
        /// </summary>
        /// <param name="model">NICHICONEntity class</param>
        /// <returns>Số hàng bị ảnh hưởng bởi hoạt động</returns>
        public int Add(NICHICON model)
        {
            string sql = @"INSERT INTO NICHICON
				(ProductionID,LineID,BoxID,ModelID,ModelName,DateCheck,TimeCheck,OperatorCode,JudgeResult,OperatorName) 
				VALUES(@ProductionID,@LineID,@BoxID,@ModelID,@ModelName,@DateCheck,@TimeCheck,@OperatorCode,@JudgeResult,@OperatorName)";
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@ProductionID", SqlDbType.VarChar, 150){ Value = model.ProductionID },
                new SqlParameter("@LineID", SqlDbType.Int, -1){ Value = model.LineID },
                new SqlParameter("@BoxID", SqlDbType.VarChar, 20){ Value = model.BoxID },
                new SqlParameter("@ModelID", SqlDbType.VarChar, 150){ Value = model.ModelID },
                model.ModelName == null ? new SqlParameter("@ModelName", SqlDbType.VarChar, 150) { Value = DBNull.Value } : new SqlParameter("@ModelName", SqlDbType.VarChar, 150) { Value = model.ModelName },
                new SqlParameter("@DateCheck", SqlDbType.Date, -1){ Value = model.DateCheck },
                new SqlParameter("@TimeCheck", SqlDbType.VarChar, 15){ Value = model.TimeCheck },
                model.OperatorCode == null ? new SqlParameter("@OperatorCode", SqlDbType.VarChar, 10) { Value = DBNull.Value } : new SqlParameter("@OperatorCode", SqlDbType.VarChar, 10) { Value = model.OperatorCode },
                model.JudgeResult == null ? new SqlParameter("@JudgeResult", SqlDbType.VarChar, 50) { Value = DBNull.Value } : new SqlParameter("@JudgeResult", SqlDbType.VarChar, 50) { Value = model.JudgeResult },
                model.OperatorName == null ? new SqlParameter("@OperatorName", SqlDbType.NVarChar, 300) { Value = DBNull.Value } : new SqlParameter("@OperatorName", SqlDbType.NVarChar, 300) { Value = model.OperatorName }
            };
            return dbHelper.Execute(sql, parameters);
        }
        /// <summary>
        /// Update record
        /// </summary>
        /// <param name="model">NICHICONEntity class</param>
        public int Update(NICHICON model)
        {
            string sql = @"UPDATE NICHICON SET 
				LineID=@LineID,BoxID=@BoxID,ModelID=@ModelID,ModelName=@ModelName,DateCheck=@DateCheck,TimeCheck=@TimeCheck,OperatorCode=@OperatorCode,JudgeResult=@JudgeResult,OperatorName=@OperatorName
				WHERE ProductionID=@ProductionID";
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@LineID", SqlDbType.Int, -1){ Value = model.LineID },
                new SqlParameter("@BoxID", SqlDbType.VarChar, 20){ Value = model.BoxID },
                new SqlParameter("@ModelID", SqlDbType.VarChar, 150){ Value = model.ModelID },
                model.ModelName == null ? new SqlParameter("@ModelName", SqlDbType.VarChar, 150) { Value = DBNull.Value } : new SqlParameter("@ModelName", SqlDbType.VarChar, 150) { Value = model.ModelName },
                new SqlParameter("@DateCheck", SqlDbType.Date, -1){ Value = model.DateCheck },
                new SqlParameter("@TimeCheck", SqlDbType.VarChar, 15){ Value = model.TimeCheck },
                model.OperatorCode == null ? new SqlParameter("@OperatorCode", SqlDbType.VarChar, 10) { Value = DBNull.Value } : new SqlParameter("@OperatorCode", SqlDbType.VarChar, 10) { Value = model.OperatorCode },
                model.JudgeResult == null ? new SqlParameter("@JudgeResult", SqlDbType.Bit, -1) { Value = DBNull.Value } : new SqlParameter("@JudgeResult", SqlDbType.Bit, -1) { Value = model.JudgeResult },
                model.OperatorName == null ? new SqlParameter("@OperatorName", SqlDbType.NVarChar, 300) { Value = DBNull.Value } : new SqlParameter("@OperatorName", SqlDbType.NVarChar, 300) { Value = model.OperatorName },
                new SqlParameter("@ProductionID", SqlDbType.VarChar, 150){ Value = model.ProductionID }
            };
            return dbHelper.Execute(sql, parameters);
        }
        /// <summary>
        /// Xóa
        /// </summary>
        public int Delete(string productionid)
        {
            string sql = "DELETE FROM NICHICON WHERE ProductionID=@ProductionID";
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@ProductionID", SqlDbType.VarChar, 150){ Value = productionid }
            };
            return dbHelper.Execute(sql, parameters);
        }
        /// <summary>
        /// Converts the DataReader to the List method
        /// </summary>
        private List<NICHICON> DataReaderToList(SqlDataReader dataReader)
        {
            List<NICHICON> List = new List<NICHICON>();
            NICHICON model = null;
            while (dataReader.Read())
            {
                model = new NICHICON();
                model.ProductionID = dataReader.GetString(0);
                model.LineID = dataReader.GetInt32(1);
                model.BoxID = dataReader.GetString(2);
                model.ModelID = dataReader.GetString(3);
                if (!dataReader.IsDBNull(4))
                    model.ModelName = dataReader.GetString(4);
                model.DateCheck = dataReader.GetDateTime(5);
                model.TimeCheck = dataReader.GetString(6);
                if (!dataReader.IsDBNull(7))
                    model.OperatorCode = dataReader.GetString(7);
                if (!dataReader.IsDBNull(8))
                    model.JudgeResult = dataReader.GetString(8);
                if (!dataReader.IsDBNull(9))
                    model.OperatorName = dataReader.GetString(9);
                List.Add(model);
            }
            return List;
        }
        /// <summary>
        /// Lấy về tất cả bản ghi
        /// </summary>
        public List<NICHICON> GetAll()
        {
            string sql = "SELECT * FROM NICHICON";
            SqlDataReader dataReader = dbHelper.GetDataReader(sql);
            List<NICHICON> List = DataReaderToList(dataReader);
            dataReader.Close();
            return List;
        }

        /// <summary>
        /// lấy danh sách board trong thùng
        /// </summary>
        /// <returns></returns>
        public List<NICHICON> GetAll(string boxId)
        {
            string sql = "SELECT * FROM NICHICON WHERE BoxID=@BoxID ORDER BY DateCheck, TimeCheck DESC";
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@BoxID", SqlDbType.VarChar, 25){ Value = boxId }
            };
            SqlDataReader dataReader = dbHelper.GetDataReader(sql, parameters);
            List<NICHICON> List = DataReaderToList(dataReader);
            dataReader.Close();
            return List;
        }

        /// <summary>
        /// Get by ID
        /// </summary>
        public NICHICON Get(string productionid)
        {
            string sql = "SELECT TOP(1) * FROM NICHICON WHERE ProductionID=@ProductionID";
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@ProductionID", SqlDbType.VarChar, 150){ Value = productionid }
            };
            SqlDataReader dataReader = dbHelper.GetDataReader(sql, parameters);
            List<NICHICON> List = DataReaderToList(dataReader);
            dataReader.Close();
            return List.Count > 0 ? List[0] : null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="boxId"></param>
        /// <returns></returns>
        public NICHICON CheckBoxExists(string boxId)
        {
            string sql = "SELECT TOP(1) * FROM NICHICON WHERE BoxID=@BoxID";
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@BoxID", SqlDbType.VarChar, 25){ Value = boxId }
            };
            SqlDataReader dataReader = dbHelper.GetDataReader(sql, parameters);
            List<NICHICON> List = DataReaderToList(dataReader);
            dataReader.Close();
            return List.Count > 0 ? List[0] : null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="boardNo"></param>
        /// <returns></returns>
        public string CheckBoardNOExists(string boardNo)
        {
            string sql = "SELECT ProductionID FROM NICHICON WHERE (ProductionID=@ProductionID)";
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@ProductionID", SqlDbType.VarChar, 150){ Value = boardNo }
            };
            string value = dbHelper.ExecuteScalar(sql, parameters);
            if (value != "")
                return value;
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DateTime GetDateTimeFormSqlServer()
        {
            string sql = "SELECT GETDATE()";
            return DateTime.Parse(dbHelper.ExecuteScalar(sql));
        }
    }
}
