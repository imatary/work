using System.Linq;
using IndicateReport.Data;

namespace IndicateReport.Services
{
    public class ProcessService
    {
        private readonly IndicateReportEntities _context;

        public ProcessService()
        {
            _context = new IndicateReportEntities();
        }

        public ID_process GetProcessById(int id)
        {
            using (var context=new IndicateReportEntities())
            {
                return context.ID_process.FirstOrDefault(p => p.ID_process1 == id);
            }
        }
    }
}