using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lib.Data
{
    public partial class WORK_ORDER_ITEMS
    {
        public Guid ID { get; set; }

        public string BOARD_NO { get; set; }

        public int BOARD_STATE { get; set; }

        public bool IS_FINISHED { get; set; }

        public int PROCEDURE_INDEX { get; set; }

        public string STATION_NAME { get; set; }

        public string STATION_NO { get; set; }

    }
}
