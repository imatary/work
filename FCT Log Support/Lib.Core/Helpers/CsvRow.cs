using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lib.Core.Helpers
{
    /// <summary>
    /// Class to store one CSV row
    /// </summary>
    public class CsvRow : List<string>
    {
        public string LineText { get; set; }
    }
}
