using Lib.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lib.Services
{
    public interface IEducationService
    {
        List<MS_Education> GetEducations(); 
    }
    public class EducationService : IEducationService
    {
        private readonly GADbContext _context;
        public EducationService()
        {
            _context = new GADbContext();
        }
        public List<MS_Education> GetEducations()
        {
            try
            {
                return _context.Database.SqlQuery<MS_Education>("EXEC [dbo].[sp_Get_All_Educations]").ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
