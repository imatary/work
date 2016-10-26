using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using BarcodeShipping.Data;

namespace BarcodeShipping.Services
{
    public interface IOQCService
    {
        IEnumerable<tbl_test_log> GetLogs();
        tbl_test_log GetLogsById(string productionId);
        mst_operator GetOperatorByCode(string operatorCode);
    }
    public class OQCService : IOQCService
    {
        private readonly ShippingFujiXeroxDbContext _context;
        public OQCService()
        {
            _context = new ShippingFujiXeroxDbContext();
        }
        public IEnumerable<tbl_test_log> GetLogs()
        {
            return _context.Database.SqlQuery<tbl_test_log>("EXEC [sp_SelectAllLogs]").ToList();
        }

        /// <summary>
        /// /
        /// </summary>
        /// <returns></returns>
        public int CountRecords()
        {
            return _context.tbl_test_log.Count();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="boxId"></param>
        /// <returns></returns>
        public string CheckBoxIdExits(string boxId)
        {
            var param = new SqlParameter()
            {
                ParameterName = "@boxId",
                SqlDbType = SqlDbType.Char,
                Value = boxId,
            };
            var log= _context.Database.SqlQuery<tbl_test_log>("EXEC [sp_CheckBoxIdExits] @boxId", param).FirstOrDefault();

            return log.BoxID;
        }

        public tbl_test_log GetLogByProductionId(string productionId)
        {
            var param = new SqlParameter()
            {
                ParameterName = "@productionId",
                SqlDbType = SqlDbType.VarChar,
                Value = productionId,
            };
            return _context.Database.SqlQuery<tbl_test_log>("EXEC sp_GetLogByProductionId @productionId", param).FirstOrDefault();
        }

        public IEnumerable<tbl_test_log> GetLogsByBoxId(string boxId)
        {
            var param = new SqlParameter()
            {
                ParameterName = "@boxId",
                SqlDbType = SqlDbType.VarChar,
                Value = boxId,
            };
            return _context.Database.SqlQuery<tbl_test_log>("EXEC sp_GetLogsByBoxId @boxId", param).ToList();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="boxId"></param>
        /// <param name="dateCheck"></param>
        /// <returns></returns>
        public IEnumerable<tbl_test_log> GetLogsByBoxIdAndDate(string boxId, string dateCheck)
        {
            object[] param =
            {
                new SqlParameter() { ParameterName = "@boxId", Value = boxId, SqlDbType = SqlDbType.Char},
                new SqlParameter() { ParameterName = "@dateCheck", Value = dateCheck, SqlDbType = SqlDbType.Date},
                new SqlParameter("@Out_Parameter", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                }
            };
            return _context.Database.SqlQuery<tbl_test_log>("EXEC [dbo].[sp_GetLogsByBoxIdAndDate] @boxId, @dateCheck", param).ToList();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="productionId"></param>
        public void DeleteLogByProductionId(string productionId)
        {
            var log = GetLogByProductionId(productionId);
            var param = new SqlParameter()
            {
                ParameterName = "@productionId",
                SqlDbType = SqlDbType.VarChar,
                Value = productionId,
            };
            if (log != null)
            {
                _context.Database.ExecuteSqlCommand("EXEC [dbo].[sp_DeleteLogByProductionId] @productionId");
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
                _context.Database.ExecuteSqlCommand("EXEC [dbo].[sp_DeleteLogByBoxId] @boxId", param);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public tbl_test_log GetLogsById(string productionId)
        {
            var param = new SqlParameter()
            {
                ParameterName = "@productionId",
                SqlDbType = SqlDbType.VarChar,
                Value = productionId,
            };
            return _context.Database.SqlQuery<tbl_test_log>("EXEC [sp_GetLogsById] @productionId", param).FirstOrDefault();
        }

        public void UpdateOQCCheck(tbl_test_log production, string operatorCode)
        {
            if (production != null)
            {
                production.QA_Check = true;
                production.CheckBy = operatorCode;
                production.DateCheck = DateTime.Now;
                try
                {
                    _context.Entry(production).State = EntityState.Modified;
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public mst_operator GetOperatorByCode(string operatorCode)
        {
            var param = new SqlParameter()
            {
                ParameterName = "@operatorCode",
                SqlDbType = SqlDbType.Char,
                Value = operatorCode,
            };
            return _context.Database.SqlQuery<mst_operator>("EXEC [sp_GetOperatorByCode] @operatorCode", param).FirstOrDefault();
        }

        
        public void UpdateBoxIdByProductionId(string boxId, string productionId)
        {
            var log = GetLogByProductionId(productionId);
            if (log != null)
            {
                log.BoxID = boxId;
                _context.SaveChanges();
            }
        }


    }
}