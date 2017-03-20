namespace Umc.Web.Areas.oqc.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PackingPO")]
    public partial class PackingPO
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(150)]
        public string ModelID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(150)]
        public string PO_NO { get; set; }

        public int QuantityPO { get; set; }

        public int QuantityRemain { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateCreated { get; set; }

        public TimeSpan TimeCreated { get; set; }

        [StringLength(10)]
        public string CreateBy { get; set; }

        public virtual Model Model { get; set; }
    }
}
