using System.Collections.Generic;
using System.Linq;
using Indicate.Data;

namespace IndicateReort.Service
{
    public class ProcessService
    {
        private readonly QUANLYSANXUATEntities _context;

        public ProcessService()
        {
            _context = new QUANLYSANXUATEntities();
        }

        public List<Lines_processes> GetAllProcesseses(int lineId)
        {
            var context = new QUANLYSANXUATEntities();

            return context.Lines_processes.Include("Line")
                    .Include("All_Processes")
                    .Where(c => c.Id_line == lineId)
                    .OrderBy(c => c.Position_process_in_line)
                    .ToList();

        } 
    }

    //Dim ProcessInLine = (From line In load_data.Lines
    //                           From process In line.All_Processes
    //                           Where line.Id_line = id_line_setup
    //                           Select process).ToList
}