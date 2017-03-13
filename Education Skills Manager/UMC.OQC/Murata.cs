namespace UMC.OQC
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Murata
    {
        [Key]
        [StringLength(150)]
        public string ProductionID { get; set; }

        public int LineID { get; set; }

        [Required]
        [StringLength(20)]
        public string BoxID { get; set; }

        [Required]
        [StringLength(150)]
        public string ModelID { get; set; }

        [StringLength(150)]
        public string ModelName { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateCheck { get; set; }

        public TimeSpan? TimeCheck { get; set; }

        [StringLength(10)]
        public string OperatorCode { get; set; }

        [StringLength(150)]
        public string ModelCustomer { get; set; }

        public bool? JudgeResult { get; set; }

        [StringLength(150)]
        public string CustomerName { get; set; }
    }
}
