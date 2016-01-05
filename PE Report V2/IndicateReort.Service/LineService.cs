using System.Collections.Generic;
using System.Linq;
using Indicate.Data;

namespace IndicateReort.Service
{
    public class LineService
    {
        private readonly QUANLYSANXUATEntities _context;

        public LineService()
        {
            _context = new QUANLYSANXUATEntities();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Line> GetLines()
        {
            var context = new QUANLYSANXUATEntities();

           return context.Lines.OrderByDescending(c => c.Id_line).ToList();

        }

        /// <summary>
        /// Trả về thông tin Line theo tên
        /// </summary>
        /// <param name="lineName"></param>
        /// <returns></returns>
        public Line GetLineByName(string lineName)
        {
            return GetLines().FirstOrDefault(c => c.Name_line == lineName);
        }
    }
}