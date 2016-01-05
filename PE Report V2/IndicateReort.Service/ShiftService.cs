using System.Linq;
using Indicate.Data;

namespace IndicateReort.Service
{
    public class ShiftService
    {
        private readonly QUANLYSANXUATEntities _context;
        public ShiftService()
        {
            _context = new QUANLYSANXUATEntities();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Sheet_productions GetSheetProductionsById(int id)
        {
            return _context.Sheet_productions.FirstOrDefault(c => c.Id_sheet_production == id);
        }
    }
}