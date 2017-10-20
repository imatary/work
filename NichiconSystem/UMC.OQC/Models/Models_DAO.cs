using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using UMC.DB;

namespace UMC.OQC.Models
{
    public class Models_DAO : BASE_DAO
    {
        private DBHelper dbHelper = new DBHelper();
        /// <summary>
        /// Constructor
        /// </summary>
        public Models_DAO()
        {
            dbHelper.connectionString = connectionString;
        }
        /// <summary>
        /// Add a record
        /// </summary>
        /// <param name="model">ModelsEntity class</param>
        /// <returns>Số hàng bị ảnh hưởng bởi hoạt động</returns>
        public int Add(Models model)
        {
            string sql = @"INSERT INTO Models
				(ModelID,ModelName,CreatedBy,DateCreated,Quantity,SerialNo,CustomerName,CheckWidthModelCus,CodeMurata,FujiHP,QuantityHP) 
				VALUES(@ModelID,@ModelName,@CreatedBy,@DateCreated,@Quantity,@SerialNo,@CustomerName,@CheckWidthModelCus,@CodeMurata,@FujiHP,@QuantityHP)";
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@ModelID", SqlDbType.VarChar, 150){ Value = model.ModelID },
                new SqlParameter("@ModelName", SqlDbType.VarChar, 250){ Value = model.ModelName },
                model.CreatedBy == null ? new SqlParameter("@CreatedBy", SqlDbType.VarChar, 100) { Value = DBNull.Value } : new SqlParameter("@CreatedBy", SqlDbType.VarChar, 100) { Value = model.CreatedBy },
                new SqlParameter("@DateCreated", SqlDbType.DateTime, 8){ Value = model.DateCreated },
                new SqlParameter("@Quantity", SqlDbType.Int, -1){ Value = model.Quantity },
                new SqlParameter("@SerialNo", SqlDbType.VarChar, 50){ Value = model.SerialNo },
                model.CustomerName == null ? new SqlParameter("@CustomerName", SqlDbType.VarChar, 150) { Value = DBNull.Value } : new SqlParameter("@CustomerName", SqlDbType.VarChar, 150) { Value = model.CustomerName },
                model.CheckWidthModelCus == null ? new SqlParameter("@CheckWidthModelCus", SqlDbType.Bit, -1) { Value = DBNull.Value } : new SqlParameter("@CheckWidthModelCus", SqlDbType.Bit, -1) { Value = model.CheckWidthModelCus },
                model.CodeMurata == null ? new SqlParameter("@CodeMurata", SqlDbType.VarChar, 50) { Value = DBNull.Value } : new SqlParameter("@CodeMurata", SqlDbType.VarChar, 50) { Value = model.CodeMurata },
                model.FujiHP == null ? new SqlParameter("@FujiHP", SqlDbType.Bit, -1) { Value = DBNull.Value } : new SqlParameter("@FujiHP", SqlDbType.Bit, -1) { Value = model.FujiHP },
                model.QuantityHP == null ? new SqlParameter("@QuantityHP", SqlDbType.Int, -1) { Value = DBNull.Value } : new SqlParameter("@QuantityHP", SqlDbType.Int, -1) { Value = model.QuantityHP }
            };
            return dbHelper.Execute(sql, parameters);
        }
        /// <summary>
        /// Update record
        /// </summary>
        /// <param name="model">ModelsEntity class</param>
        public int Update(Models model)
        {
            string sql = @"UPDATE Models SET 
				ModelName=@ModelName,CreatedBy=@CreatedBy,DateCreated=@DateCreated,Quantity=@Quantity,SerialNo=@SerialNo,CustomerName=@CustomerName,CheckWidthModelCus=@CheckWidthModelCus,CodeMurata=@CodeMurata,FujiHP=@FujiHP,QuantityHP=@QuantityHP
				WHERE ModelID=@ModelID";
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@ModelName", SqlDbType.VarChar, 250){ Value = model.ModelName },
                model.CreatedBy == null ? new SqlParameter("@CreatedBy", SqlDbType.VarChar, 100) { Value = DBNull.Value } : new SqlParameter("@CreatedBy", SqlDbType.VarChar, 100) { Value = model.CreatedBy },
                new SqlParameter("@DateCreated", SqlDbType.DateTime, 8){ Value = model.DateCreated },
                new SqlParameter("@Quantity", SqlDbType.Int, -1){ Value = model.Quantity },
                new SqlParameter("@SerialNo", SqlDbType.VarChar, 50){ Value = model.SerialNo },
                model.CustomerName == null ? new SqlParameter("@CustomerName", SqlDbType.VarChar, 150) { Value = DBNull.Value } : new SqlParameter("@CustomerName", SqlDbType.VarChar, 150) { Value = model.CustomerName },
                model.CheckWidthModelCus == null ? new SqlParameter("@CheckWidthModelCus", SqlDbType.Bit, -1) { Value = DBNull.Value } : new SqlParameter("@CheckWidthModelCus", SqlDbType.Bit, -1) { Value = model.CheckWidthModelCus },
                model.CodeMurata == null ? new SqlParameter("@CodeMurata", SqlDbType.VarChar, 50) { Value = DBNull.Value } : new SqlParameter("@CodeMurata", SqlDbType.VarChar, 50) { Value = model.CodeMurata },
                model.FujiHP == null ? new SqlParameter("@FujiHP", SqlDbType.Bit, -1) { Value = DBNull.Value } : new SqlParameter("@FujiHP", SqlDbType.Bit, -1) { Value = model.FujiHP },
                model.QuantityHP == null ? new SqlParameter("@QuantityHP", SqlDbType.Int, -1) { Value = DBNull.Value } : new SqlParameter("@QuantityHP", SqlDbType.Int, -1) { Value = model.QuantityHP },
                new SqlParameter("@ModelID", SqlDbType.VarChar, 150){ Value = model.ModelID }
            };
            return dbHelper.Execute(sql, parameters);
        }
        /// <summary>
        /// Xóa
        /// </summary>
        public int Delete(string modelid)
        {
            string sql = "DELETE FROM Models WHERE ModelID=@ModelID";
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@ModelID", SqlDbType.VarChar, 150){ Value = modelid }
            };
            return dbHelper.Execute(sql, parameters);
        }
        /// <summary>
        /// Converts the DataReader to the List method
        /// </summary>
        private List<Models> DataReaderToList(SqlDataReader dataReader)
        {
            List<Models> List = new List<Models>();
            Models model = null;
            while (dataReader.Read())
            {
                model = new Models();
                model.ModelID = dataReader.GetString(0);
                model.ModelName = dataReader.GetString(1);
                if (!dataReader.IsDBNull(2))
                    model.CreatedBy = dataReader.GetString(2);
                model.DateCreated = dataReader.GetDateTime(3);
                model.Quantity = dataReader.GetInt32(4);
                model.SerialNo = dataReader.GetString(5);
                if (!dataReader.IsDBNull(6))
                    model.CustomerName = dataReader.GetString(6);
                if (!dataReader.IsDBNull(7))
                    model.CheckWidthModelCus = dataReader.GetBoolean(7);
                if (!dataReader.IsDBNull(8))
                    model.CodeMurata = dataReader.GetString(8);
                if (!dataReader.IsDBNull(9))
                    model.FujiHP = dataReader.GetBoolean(9);
                if (!dataReader.IsDBNull(10))
                    model.QuantityHP = dataReader.GetInt32(10);
                List.Add(model);
            }
            return List;
        }
        /// <summary>
        /// Lấy về tất cả bản ghi
        /// </summary>
        public List<Models> GetAll(string cusName)
        {
            string sql = "SELECT * FROM Models WHERE (CustomerName=@CustomerName) AND (ModelName !='IT Test')  AND (ModelName !='IT-Test') ORDER BY ModelName ASC ";
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@CustomerName", SqlDbType.VarChar, 150){ Value = cusName }
            };
            SqlDataReader dataReader = dbHelper.GetDataReader(sql, parameters);
            List<Models> List = DataReaderToList(dataReader);
            dataReader.Close();
            return List;
        }

        /// <summary>
        /// Get by ID
        /// </summary>
        public Models Get(string modelid)
        {
            string sql = "SELECT TOP(1) * FROM Models WHERE ModelID=@ModelID";
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@ModelID", SqlDbType.VarChar, 150){ Value = modelid }
            };
            SqlDataReader dataReader = dbHelper.GetDataReader(sql, parameters);
            List<Models> List = DataReaderToList(dataReader);
            dataReader.Close();
            return List.Count > 0 ? List[0] : null;
        }
    }
}
