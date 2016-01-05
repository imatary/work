using System.Linq;
using IndicateReport.Data;

namespace IndicateReport.Services
{
    public class ActualModelService
    {
        private readonly IndicateReportEntities _context;

        public ActualModelService()
        {
            _context=new IndicateReportEntities();
        }

        public Actual_model GetActualModelById(int id)
        {
            using (var context=new IndicateReportEntities())
            {
                return context.Actual_model.FirstOrDefault(a => a.Id_model == id);
            }
        }
    }
}