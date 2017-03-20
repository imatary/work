namespace Umc.Web.Areas.oqc.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class QACheck
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(500)]
        public string ProductionID { get; set; }

        public int LineID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(20)]
        public string BoxID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateCheck { get; set; }

        public TimeSpan? TimeCheck { get; set; }

        [StringLength(1)]
        public string OperatorCode { get; set; }

        public int? OperationID { get; set; }

        public bool? JudgeResult { get; set; }
    }
}
