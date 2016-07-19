using OQC.Web.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System;
using System.Linq;

namespace OQC.Web.Services
{
    public interface IOperatorService
    {
        Task<IEnumerable<mst_operator>> GetOperatorsAsync();
        Task<mst_operator> GetOperatorByCodeAsync(string id);
        mst_operator GetOperatorByCode(string id);
        Task InsertAsync(mst_operator opera);
        Task UpdateAsync(mst_operator opera);
        void Delete(string id);
    }
    public class OperatorService : IOperatorService
    {
        private readonly ApplicationDbContext _context;
        public OperatorService()
        {
            _context = new ApplicationDbContext();
        }
        public async Task<IEnumerable<mst_operator>> GetOperatorsAsync()
        {
            return await _context.Database.SqlQuery<mst_operator>("EXEC [sp_GetOperators]").ToListAsync();
        }

        public async Task<mst_operator> GetOperatorByCodeAsync(string id)
        {
            var param = new SqlParameter()
            {
                ParameterName = "@operatorCode",
                SqlDbType = SqlDbType.Char,
                Value = id,
            };
            return await _context.Database.SqlQuery<mst_operator>("EXEC [sp_GetOperatorByCode] @operatorCode", param).FirstOrDefaultAsync();
        }
        public mst_operator GetOperatorByCode(string id)
        {
            var param = new SqlParameter()
            {
                ParameterName = "@operatorCode",
                SqlDbType = SqlDbType.Char,
                Value = id,
            };
            return _context.Database.SqlQuery<mst_operator>("EXEC [sp_GetOperatorByCode] @operatorCode", param).FirstOrDefault();
        }

        public void Delete(string id)
        {
            var param = new SqlParameter()
            {
                ParameterName = "@operatorCode",
                SqlDbType = SqlDbType.Char,
                Value = id,
            };

            _context.Database.ExecuteSqlCommand("EXEC [sp_DeleteOperatorByCode] @operatorCode", param);
        }

        public async Task InsertAsync(mst_operator opera)
        {
            object[] param =
            {
                new SqlParameter() { ParameterName = "@operatorCode", Value = opera.OperatorID, SqlDbType = SqlDbType.Char},
                new SqlParameter() { ParameterName = "@operatorName", Value = opera.OperatorName, SqlDbType = SqlDbType.NVarChar},
                new SqlParameter("@Out_Parameter", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                }
            };

            try
            {
                _context.Database.ExecuteSqlCommand("EXEC [sp_InsertOperator] @operatorCode, @operatorName", param);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public async Task UpdateAsync(mst_operator opera)
        {
            object[] param =
            {
                new SqlParameter() { ParameterName = "@operatorCode", Value = opera.OperatorID, SqlDbType = SqlDbType.Char},
                new SqlParameter() { ParameterName = "@operatorName", Value = opera.OperatorName, SqlDbType = SqlDbType.NVarChar},
                new SqlParameter("@Out_Parameter", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                }
            };

            try
            {
                _context.Database.ExecuteSqlCommand("EXEC [sp_UpdateOperator] @operatorCode, @operatorName", param);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        
    }
}