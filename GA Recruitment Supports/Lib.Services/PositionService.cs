using Lib.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lib.Services
{
    public interface IPositionService
    {
        List<MS_Position> GetPositions();
    }
    public class PositionService : IPositionService
    {
        private readonly GADbContext _context;
        public PositionService()
        {
            _context = new GADbContext();
        }
        public List<MS_Position> GetPositions()
        {
            try
            {
                return _context.Database.SqlQuery<MS_Position>("EXEC [dbo].[sp_Get_All_Positions]").ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
