using System.Collections.Generic;
using System.Linq;
using Indicate.Data;

namespace IndicateReort.Service
{
    public class LineProcessService
    {
        public List<Lines_processes> GetLinesProcesseses(int lineId)
        {
            var context = new QUANLYSANXUATEntities();

            return context.Lines_processes.Where(l => l.Id_line == lineId)
                    .OrderBy(c => c.Position_process_in_line)
                    .ToList();

        } 
    }
}