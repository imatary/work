using BarcodeShipping.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace BarcodeShipping.Services
{
    public class MurataService
    {
        private readonly ShippingFujiXeroxDbContext _context;
        public MurataService()
        {
            _context = new ShippingFujiXeroxDbContext();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="labelCustumer"></param>
        /// <returns></returns>
        public Murata GetProducts_Murata_by_ModelCustomer(string labelCustumer)
        {
            var param = new SqlParameter()
            {
                ParameterName = "@labelMurata",
                SqlDbType = SqlDbType.VarChar,
                Value = labelCustumer,
            };
            try
            {
                return _context.Database.SqlQuery<Murata>("EXEC [dbo].[sp_Murata_by_LabelMurata] @labelMurata", param).SingleOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Label UMC
        /// </summary>
        /// <param name="label"></param>
        /// <returns></returns>
        public Murata GetProducts_Murata_by_ID(string label)
        {
            var param = new SqlParameter()
            {
                ParameterName = "@labelUMC",
                SqlDbType = SqlDbType.VarChar,
                Value = label,
            };
            return _context.Database.SqlQuery<Murata>("EXEC [dbo].[sp_Murata_by_ID] @labelUMC", param).SingleOrDefault();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="boxId"></param>
        /// <returns></returns>
        public IEnumerable<Murata> GetProducts_Murata_by_BoxId(string boxId)
        {
            var param = new SqlParameter()
            {
                ParameterName = "@boxId",
                SqlDbType = SqlDbType.VarChar,
                Value = boxId,
            };
            return _context.Database.SqlQuery<Murata>("EXEC [dbo].[sp_Murata_by_BoxId] @boxId", param).ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dateCheck"></param>
        /// <returns></returns>
        public IEnumerable<Murata> Find_Murata_by_Date(DateTime dateCheck)
        {
            object[] param =
                {
                    new SqlParameter() { ParameterName = "@dateCheck", Value = dateCheck, SqlDbType = SqlDbType.Date},
                    new SqlParameter("@Out_Parameter", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    }
                };
            try
            {
                return _context.Database.SqlQuery<Murata>("EXEC [dbo].[sp_Murata_Find_by_Date] @dateCheck", param).ToList();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }  
        }

        /// <summary>
        /// Insert Log
        /// </summary>
        /// <param name="productionId"></param>
        /// <param name="lineId"></param>
        /// <param name="macAddress"></param>
        /// <param name="boxId"></param>
        /// <param name="modelId"></param>
        /// <param name="workingOder"></param>
        /// <param name="quantity"></param>
        /// <param name="operatorCode"></param>
        /// <param name="qaCheck"></param>
        public void InsertLogs(
            string productionId,
            int lineId,
            string boxId,
            string modelId,
            string modelName,
            string operatorCode,
            string labelMurata,
            bool judgeResult)
        {
            object[] param =
                {
                    new SqlParameter() {ParameterName = "@productionID", Value = productionId, SqlDbType = SqlDbType.VarChar},
                    new SqlParameter() {ParameterName = "@lineId", Value = lineId, SqlDbType = SqlDbType.Int},
                    new SqlParameter() {ParameterName = "@boxId", Value = boxId, SqlDbType = SqlDbType.Char},
                    new SqlParameter() {ParameterName = "@modelId", Value = modelId, SqlDbType = SqlDbType.VarChar},
                    new SqlParameter() {ParameterName = "@modelName", Value = modelName, SqlDbType = SqlDbType.VarChar},
                    new SqlParameter() {ParameterName = "@dateCheck", Value = DateTime.Now.Date, SqlDbType = SqlDbType.Date},
                    new SqlParameter() {ParameterName = "@timeCheck", Value = DateTime.Now.TimeOfDay, SqlDbType = SqlDbType.Time},
                    new SqlParameter() {ParameterName = "@operatorCode", Value = operatorCode, SqlDbType = SqlDbType.VarChar},
                    new SqlParameter() {ParameterName = "@labelMurata", Value = labelMurata, SqlDbType = SqlDbType.VarChar},
                    new SqlParameter() {ParameterName = "@judgeResult", Value = judgeResult, SqlDbType = SqlDbType.Bit},
                    new SqlParameter("@Out_Parameter", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    }
                };
            try
            {
                _context.Database.ExecuteSqlCommand("EXEC [dbo].[sp_MurataInsert] @productionID, @lineId, @boxId, @modelId, @modelName, @dateCheck, @timeCheck, @operatorCode, @labelMurata, @judgeResult", param);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="productionId"></param>
        public void DeleteLogByProductionId(string productionId)
        {
            var log = GetProducts_Murata_by_ID(productionId);
            
            if (log != null)
            {
                object[] param =
                {
                    new SqlParameter() { ParameterName = "@labelUMC", Value = productionId, SqlDbType = SqlDbType.VarChar},
                    new SqlParameter("@Out_Parameter", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    }
                };
                try
                {
                    _context.Database.ExecuteSqlCommand("EXEC [dbo].[sp_Murata_Delete_by_ID] @labelUMC", param);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
        public void DeleteLogByBoxId(string boxId)
        {
            object[] param =
            {
                new SqlParameter() { ParameterName = "@boxId", Value = boxId, SqlDbType = SqlDbType.Char},
                new SqlParameter("@Out_Parameter", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                }
            };

            try
            {
                _context.Database.ExecuteSqlCommand("EXEC [dbo].[sp_Murata_Delete_by_BoxId] @boxId", param);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
