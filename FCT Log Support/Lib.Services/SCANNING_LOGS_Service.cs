using Lib.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Lib.Services
{
    public class SCANNING_LOGS_Service : BaseService
    {
        private readonly MESSystemDbContext _context;
        public SCANNING_LOGS_Service()
        {
            _context = new MESSystemDbContext();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="boardNo"></param>
        /// <returns></returns>
        public List<SCANNING_LOGS> Get_SCANNING_LOGS(string boardNo)
        {
            if (CheckConnection())
            {
                object[] param =
                {
                    new SqlParameter() { ParameterName="@BOARD_NO", Value=boardNo, SqlDbType=SqlDbType.NVarChar },
                    new SqlParameter("@Out_Parameter", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    }
                };

                try
                {
                    return _context.Database.SqlQuery<SCANNING_LOGS>("EXEC [dbo].[sp_Get_SCANNING_LOGS_By_BroadNo] @BOARD_NO", param).ToList();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }

            }
            else
            {
                throw new Exception("Connected to database faild. Please check network, then try again! ");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="boardNo"></param>
        /// <param name="productId"></param>
        /// <returns></returns>
        public List<SCANNING_LOGS> Get_SCANNING_LOGS(string boardNo, string productId)
        {
            object[] param =
            {
                    new SqlParameter() { ParameterName="@BOARD_NO", Value=boardNo, SqlDbType=SqlDbType.NVarChar },
                    new SqlParameter() { ParameterName="@PRODUCT_ID", Value=productId, SqlDbType=SqlDbType.NVarChar },
                    new SqlParameter("@Out_Parameter", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    }
                };

            try
            {
                return _context.Database.SqlQuery<SCANNING_LOGS>("EXEC [dbo].[sp_Get_SCANNING_LOGS_LIKE_BroadNo_PRODUCTID] @BOARD_NO, @PRODUCT_ID", param).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
