using System.Linq;
using IndicateReport.Data;

namespace IndicateReport.Services
{
    public class IndicateReportService
    {
        private readonly IndicateReportEntities _context;

        public IndicateReportService()
        {
            _context=new IndicateReportEntities();
        }

        public Data.IndicateReport GetIndicateReportById(string reportId)
        {
            using (var context=new IndicateReportEntities())
            {
                return context.IndicateReports.FirstOrDefault(item => item.ReportID == reportId);
            }
        }
    }
}