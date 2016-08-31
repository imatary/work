namespace Lib.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Broad
    {
        [StringLength(150)]
        public string BroadID { get; set; }

        [Required]
        [StringLength(50)]
        public string CusID { get; set; }

        [Required]
        [StringLength(50)]
        public string LineID { get; set; }

        [Required]
        [StringLength(50)]
        public string ModelID { get; set; }

        [Column(TypeName = "date")]
        public DateTime CreatedDate { get; set; }

        public TimeSpan CreatedTime { get; set; }
    }
}
