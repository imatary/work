using System.Collections.Generic;
using System.Linq;
using Indicate.Data;

namespace IndicateReort.Service
{
    public class ModelService
    {
        private readonly QUANLYSANXUATEntities _context;

        public ModelService()
        {
            _context = new QUANLYSANXUATEntities();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Model> GetModels()
        {
            var context = new QUANLYSANXUATEntities();

            return context.Models.OrderByDescending(c => c.Id_model).ToList();

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelId"></param>
        /// <returns></returns>
        public Model GetModelById(string modelId)
        {
            return GetModels().FirstOrDefault(c => c.Id_model == modelId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Line_status> GetLineStatuses()
        {
            var context = new QUANLYSANXUATEntities();
            
                return context.Line_status.OrderByDescending(c => c.Id_Line).ToList();
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lineId"></param>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public Line_status GetLineStatusByLineAndCustomer(int lineId, string customerId)
        {
            return GetLineStatuses().FirstOrDefault(c => c.Id_Line == lineId && c.Id_customer == customerId);
        }
    }
}