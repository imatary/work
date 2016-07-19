using OQC.Web.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace OQC.Web.Services
{
    public interface ISearchService
    {
        Task<IEnumerable<SearchLogModel>> SearchLogByProductionID(string productionID);
        Task<IEnumerable<SearchLogModel>> SearchLogByBoxID(string boxId);
        Task<IEnumerable<SearchLogModel>> SearchLogByMacAddress(string macAddress);
        Task<IEnumerable<SearchLogModel>> SearchLogByOperationDate(string operationDate);
        Task<IEnumerable<SearchLogModel>> SearchLogByModelID(string modelId);
        Task<IEnumerable<SearchLogModel>> SearchLogByOperatorCode(string operatorCode);
        Task<IEnumerable<SearchLogModel>> SearchLogByLineID(int? lineId);
        Task<IEnumerable<SearchLogModel>> SearchLogs(string productionId, string boxId, string macAddress, DateTime operationDate);
        Task<IEnumerable<SearchLogModel>> SearchLogsTop();
    }
    public class SearchService : ISearchService
    {
        private readonly ApplicationDbContext _context;
        public SearchService()
        {
            _context = new ApplicationDbContext();
        }

        public async Task<IEnumerable<SearchLogModel>> SearchLogByBoxID(string boxId)
        {
            var param = new SqlParameter()
            {
                ParameterName = "@boxId",
                SqlDbType = SqlDbType.Char,
                Value = boxId,
            };
            return await _context.Database.SqlQuery<SearchLogModel>("EXEC [dbo].[sp_SearchLogsByBoxId] @boxId", param).ToListAsync();

        }

        public async Task<IEnumerable<SearchLogModel>> SearchLogByMacAddress(string macAddress)
        {
            var param = new SqlParameter()
            {
                ParameterName = "@macAddress",
                SqlDbType = SqlDbType.Char,
                Value = macAddress,
            };
            return await _context.Database.SqlQuery<SearchLogModel>("EXEC [dbo].[sp_SearchLogsByMacAddress] @macAddress", param).ToListAsync();
        }

        public async Task<IEnumerable<SearchLogModel>> SearchLogByOperationDate(string operationDate)
        {
            var param = new SqlParameter()
            {
                ParameterName = "@operationDate",
                SqlDbType = SqlDbType.VarChar,
                Value = operationDate,
            };
            try
            {
                return await _context.Database.SqlQuery<SearchLogModel>("EXEC [dbo].[sp_SearchLogsByOperationDate] @operationDate", param).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<IEnumerable<SearchLogModel>> SearchLogByModelID(string modelId)
        {
            var param = new SqlParameter()
            {
                ParameterName = "@modelId",
                SqlDbType = SqlDbType.VarChar,
                Value = modelId,
            };
            try
            {
                return await _context.Database.SqlQuery<SearchLogModel>("EXEC [dbo].[sp_SearchLogsByModelID] @modelId", param).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<SearchLogModel>> SearchLogByProductionID(string productionID)
        {
            var param = new SqlParameter()
            {
                ParameterName = "@productionId",
                SqlDbType = SqlDbType.Char,
                Value = productionID,
            };
            return await _context.Database.SqlQuery<SearchLogModel>("EXEC [dbo].[sp_SearchLogByProductionID] @productionId", param).ToListAsync();
        }

        public async Task<IEnumerable<SearchLogModel>> SearchLogs(string productionId, string boxId, string macAddress, DateTime operationDate)
        {
            object[] param = {
                new SqlParameter { ParameterName="@productionId", Value=productionId, SqlDbType=SqlDbType.VarChar },
                new SqlParameter { ParameterName="@boxId", Value=boxId, SqlDbType=SqlDbType.Char },
                new SqlParameter { ParameterName="@macAddress", Value=macAddress, SqlDbType=SqlDbType.Char },
                new SqlParameter { ParameterName="@operationDate", Value=operationDate, SqlDbType=SqlDbType.DateTime, IsNullable=true },
                new SqlParameter("@Out_Parameter", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                }
            };

            try
            {
                return await _context.Database.SqlQuery<SearchLogModel>("EXEC [sp_SearchLogs] @productionId, @boxId, @macAddress, @operationDate", param).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<IEnumerable<SearchLogModel>> SearchLogsTop()
        {
            try
            {
                return await _context.Database.SqlQuery<SearchLogModel>("EXEC [sp_SearchLogTop]").ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<SearchLogModel>> SearchLogByLineID(int? lineId)
        {
            var param = new SqlParameter()
            {
                ParameterName = "@lineId",
                SqlDbType = SqlDbType.Int,
                Value = lineId,
            };
            try
            {
                return await _context.Database.SqlQuery<SearchLogModel>("EXEC [dbo].[sp_SearchLogsByLineID] @lineId", param).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<SearchLogModel>> SearchLogByOperatorCode(string operatorCode)
        {
            var param = new SqlParameter()
            {
                ParameterName = "@operatorCode",
                SqlDbType = SqlDbType.Char,
                Value = operatorCode,
            };
            try
            {
                return await _context.Database.SqlQuery<SearchLogModel>("EXEC [dbo].[sp_SearchLogsByOperatorCode] @operatorCode", param).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}