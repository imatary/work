using BarcodeShipping.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace BarcodeShipping.Services
{
    public class MESService
    {
        private readonly MESSystemDbContext _context;
        public MESService()
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
                return _context.Database.SqlQuery<WORK_ORDER_ITEMS>("EXEC [dbo].[sp_GET_WORK_ORDER_ITEMS_BY_BOARD_NO] @BOARD_NO", param).SingleOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
