using Lib.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Lib.Services
{
    public class WORK_ORDER_ITEMS_Service
    {
        private readonly MESSystemDbContext _context;
        public WORK_ORDER_ITEMS_Service()
        {
            _context = new MESSystemDbContext();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="boardNo"></param>
        /// <returns></returns>
        public WORK_ORDER_ITEMS Get_WORK_ORDER_ITEMS_By_BoardNo(string boardNo)
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
                return _context.Database.SqlQuery<WORK_ORDER_ITEMS>("EXEC [dbo].[sp_GET_WORK_ORDER_ITEMS_BY_BOARD_NO] @BOARD_NO", param).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="boardNo"></param>
        /// <returns></returns>
        public List<WORK_ORDER_ITEMS> Get_WORK_ORDER_ITEMS_BoardNo(string boardNo)
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
                return _context.Database.SqlQuery<WORK_ORDER_ITEMS>("EXEC [dbo].[sp_GET_WORK_ORDER_ITEMS_BY_BOARD_NO] @BOARD_NO", param).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
