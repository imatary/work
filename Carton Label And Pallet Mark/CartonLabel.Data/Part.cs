namespace CartonLabel.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Part
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string PartNoID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string PartNoValue { get; set; }

        public int? Quantity { get; set; }

        public long? Price { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        public double? Weight { get; set; }
    }
}
