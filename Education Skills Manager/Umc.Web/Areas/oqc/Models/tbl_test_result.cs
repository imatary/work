namespace Umc.Web.Areas.oqc.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_test_result
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(500)]
        public string ProductionID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int OperationID { get; set; }

        public bool? JudgeResult { get; set; }

        [StringLength(5)]
        public string OperatorID { get; set; }

        public DateTime? OperationDate { get; set; }
    }
}
