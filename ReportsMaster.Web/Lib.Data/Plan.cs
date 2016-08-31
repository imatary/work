namespace Lib.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Plan
    {
        public Guid ID { get; set; }

        [Required]
        [StringLength(50)]
        public string LineID { get; set; }

        [Required]
        [StringLength(50)]
        public string ModelID { get; set; }

        [Column("Plan")]
        public int Plan1 { get; set; }

        public int Actual { get; set; }
    }
}
