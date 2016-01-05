using System.Collections.Generic;
using System.Linq;
using IndicateReport.Data;

namespace IndicateReport.Services
{
    public class LineService
    {
        private readonly IndicateReportMasterEntities _context;

        public LineService()
        {
            _context = new IndicateReportMasterEntities();
        }

        /// <summary>
        /// Get List
        /// </summary>
        /// <returns></returns>
        public List<Line> GetLines()
        {
            using (var context=new IndicateReportMasterEntities())
            {
                return context.Lines.ToList();
            }
        }


        /// <summary>
        /// Insert Line
        /// </summary>
        /// <param name="line"></param>
        public void Insert(Line line)
        {
            if (line != null)
            {
                _context.Lines.AddObject(line);
                SaveChanges();
            }
        }


        private void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}