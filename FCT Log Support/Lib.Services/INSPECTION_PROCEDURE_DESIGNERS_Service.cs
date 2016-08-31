using Lib.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Lib.Services
{
    public class INSPECTION_PROCEDURE_DESIGNERS_Service
    {
        private readonly MESSystemDbContext _context;
        public INSPECTION_PROCEDURE_DESIGNERS_Service()
        {
            _context = new MESSystemDbContext();
        }

        public List<INSPECTION_PROCEDURE_DESIGNERS> GET_INSPECTION_PROCEDURE_DESIGNERS_BY_PROCESS_NO(string processNo)
        {
            object[] param =
            {
                new SqlParameter() { ParameterName="@PROCESS_NO", Value=processNo, SqlDbType=SqlDbType.NVarChar },

                new SqlParameter("@Out_Parameter", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                }
            };

            try
            {
                return _context.Database.SqlQuery<INSPECTION_PROCEDURE_DESIGNERS>("EXEC [dbo].[sp_GET_INSPECTION_PROCEDURE_DESIGNERS] @PROCESS_NO", param).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
