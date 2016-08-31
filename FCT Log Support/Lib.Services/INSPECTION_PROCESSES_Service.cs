using Lib.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Lib.Services
{
    public class INSPECTION_PROCESSES_Service
    {
        private readonly MESSystemDbContext _context;
        public INSPECTION_PROCESSES_Service()
        {
            _context = new MESSystemDbContext();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public INSPECTION_PROCESSES GET_INSPECTION_PROCESSES_BY_PRODUCT_ID(string productId)
        {
            object[] param =
            {
                new SqlParameter() { ParameterName="@PRODUCT_ID", Value=productId, SqlDbType=SqlDbType.NVarChar },

                new SqlParameter("@Out_Parameter", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                }
            };

            try
            {
                return _context.Database.SqlQuery<INSPECTION_PROCESSES>("EXEC [dbo].[sp_GET_INSPECTION_PROCESSES_BY_PRODUCT_ID] @PRODUCT_ID", param).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
