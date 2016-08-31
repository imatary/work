using Lib.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lib.Services
{
    public class INSPECTION_STATIONS_Service
    {
        private readonly MESSystemDbContext _context; 
        public INSPECTION_STATIONS_Service()
        {
            _context = new MESSystemDbContext();
                
        }

        public List<INSPECTION_STATIONS> Get_INSPECTION_STATIONS()
        {
            try
            {
                return _context.Database.SqlQuery<INSPECTION_STATIONS>("EXEC [dbo].[sp_GetINSPECTION_STATIONS]").ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
