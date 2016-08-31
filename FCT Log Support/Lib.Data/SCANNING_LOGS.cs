namespace Lib.Data
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public partial class SCANNING_LOGS
    {
        public Guid ID { get; set; }

        [Required]
        [StringLength(64)]
        public string BOARD_NO { get; set; }

        public int PROCEDURE_INDEX { get; set; }

        [Required]
        [StringLength(64)]
        public string PRODUCT_ID { get; set; }

        [Required]
        [StringLength(64)]
        public string STATION_NAME { get; set; }

        [Required]
        [StringLength(64)]
        public string STATION_NO { get; set; }
    }
}
