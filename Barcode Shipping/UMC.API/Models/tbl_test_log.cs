namespace UMC.API.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_test_log
    {
        [Key]
        [StringLength(500)]
        public string ProductionID { get; set; }

        public int LineID { get; set; }

        [Required]
        [StringLength(12)]
        public string MacAddress { get; set; }

        [Required]
        [StringLength(10)]
        public string BoxID { get; set; }

        [StringLength(150)]
        public string ModelID { get; set; }

        [StringLength(50)]
        public string WorkingOder { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateCheck { get; set; }

        public TimeSpan? TimeCheck { get; set; }

        public int? Quantity { get; set; }

        [StringLength(10)]
        public string OperatorCode { get; set; }

        public bool QA_Check { get; set; }

        [Required]
        [StringLength(10)]
        public string CheckBy { get; set; }

        [StringLength(250)]
        public string ClinetInput { get; set; }

        [StringLength(150)]
        public string ModelCustomer { get; set; }

        public virtual Model Model { get; set; }
    }
}
