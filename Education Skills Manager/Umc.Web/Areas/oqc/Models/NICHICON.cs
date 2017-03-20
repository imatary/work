namespace Umc.Web.Areas.oqc.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NICHICON")]
    public partial class NICHICON
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
        public DateTime DateCheck { get; set; }

        public TimeSpan TimeCheck { get; set; }

        [StringLength(10)]
        public string OperatorCode { get; set; }

        public bool? JudgeResult { get; set; }
    }
}
