using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using BarcodeShipping.Data;

namespace BarcodeShipping.Services
{
    public interface IOQCService
    {
        IEnumerable<tbl_test_log> GetLogs();
        tbl_test_log GetLogsById(string productionId);
        IEnumerable<Model> GetModels();
        Model GetModelById(string modelid);
        mst_operator GetOperatorByCode(string operatorCode);



    }
    public class OQCService : IOQCService
    {
        private readonly IQCDataEntities _context = new IQCDataEntities();
        public IEnumerable<tbl_test_log> GetLogs()
        {
            return _context.Database.SqlQuery<tbl_test_log>("EXEC sp_SelectAllLogs").ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="productionId"></param>
        /// <returns></returns>
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
                SqlDbType = SqlDbType.Char,
                Value = boxId,
            };
            return _context.Database.SqlQuery<tbl_test_log>("EXEC sp_GetLogsByBoxId @boxId", param).ToList();
        }

        public void DeleteLogByProductionId(string productionId)
        {
            var log = GetLogByProductionId(productionId);
            if (log != null)
            {
                _context.sp_DeleteLogByProductionId(productionId);
            }
        }
        public void DeleteLogByBoxId(string boxId)
        {
            foreach (var item in GetLogsByBoxId(boxId))
            {
                _context.tbl_test_log.Remove(item);
                _context.SaveChanges();
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

        public Model GetModelById(string modelId)
        {
            var param = new SqlParameter()
            {
                ParameterName = "@modelId",
                SqlDbType = SqlDbType.VarChar,
                Value = modelId,
            };
            return _context.Database.SqlQuery<Model>("EXEC [sp_GetModelById] @modelId", param).FirstOrDefault();
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

        public IEnumerable<Model> GetModels()
        {
            return _context.Database.SqlQuery<Model>("EXEC sp_SelectAllModels").ToList();
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