using System.Collections.Generic;
using System.Linq;
using IndicateReport.Data;

namespace IndicateReport.Services
{
    public class ModelService
    {
        private readonly IndicateReportMasterEntities _context;

        public ModelService()
        {
            _context = new IndicateReportMasterEntities();
        }

        /// <summary>
        /// Get List
        /// </summary>
        /// <returns></returns>
        public List<Model> GetModels()
        {
            using (var context=new IndicateReportMasterEntities())
            {
                return context.Models.ToList();
            }
        }


        /// <summary>
        /// Insert Line
        /// </summary>
        /// <param name="model"></param>
        public void Insert(Model model)
        {
            if (model != null)
            {
                _context.Models.AddObject(model);
                SaveChanges();
            }
        }


        private void SaveChanges()
        {
            _context.SaveChanges();
        }  
    }
}