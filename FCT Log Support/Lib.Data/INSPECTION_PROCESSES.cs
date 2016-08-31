using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lib.Data
{
    public partial class INSPECTION_PROCESSES
    {
        public Guid ID { get; set; }

        public bool IS_ACTIVATED { get; set; }

        public string PROCESS_NO { get; set; }

        public string PRODUCT_ID { get; set; }
    }
}
