using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lib.Data
{
    public class LineStatus
    {
        public int IdLine { get; set; }
        public string NameLine { get; set; }
        public int CountPerson { get; set; }
        public string ModelCurrent { get; set; }
        public int ProductionPlan { get; set; }
        public int ProductionActual { get; set; }
        public int StatusLine { get; set; }
        public string Comment { get; set; }
    }
}
