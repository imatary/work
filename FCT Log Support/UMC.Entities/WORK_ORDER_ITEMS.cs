using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace UMC.Entities
{
    public class WORK_ORDER_ITEMS
    {
        [Key]
        public Guid ID { get; set; }
        public string BOARD_NO { get; set; }
        public string BOARD_STATE { get; set; }
        public int PROCEDURE_INDEX { get; set; }
        public string STATION_NAME { get; set; }
        public string STATION_NO { get; set; }
        public bool IS_FINISHED { get; set; }
    }
}
