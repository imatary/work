using System;
using System.ComponentModel.DataAnnotations;

namespace UMC.Services
{
    //[Table("SCANNING_LOGS")]
    public class SCANNING_LOGS
    {
        [Key]
        public Guid ID { get; set; }
        public string BOARD_NO { get; set; }
        public string BOARD_STATE { get; set; }
        public int PROCEDURE_INDEX { get; set; }
        public string PRODUCT_ID { get; set; }
        public string STATION_NAME { get; set; }
        public string STATION_NO { get; set; }
    }
}
