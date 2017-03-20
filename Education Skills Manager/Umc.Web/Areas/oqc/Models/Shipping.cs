namespace Umc.Web.Areas.oqc.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Shipping")]
    public partial class Shipping
    {
        [Key]
        [Column(Order = 0)]
        public Guid ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Operator { get; set; }

        [Required]
        [StringLength(150)]
        public string Model { get; set; }

        [Required]
        [StringLength(50)]
        public string WorkingOder { get; set; }

        public int Quantity { get; set; }

        [Required]
        [StringLength(50)]
        public string BoxID { get; set; }

        [Required]
        [StringLength(150)]
        public string ProductID { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "date")]
        public DateTime DateCheck { get; set; }

        [Required]
        [StringLength(150)]
        public string MacAddress { get; set; }

        [StringLength(150)]
        public string PO_NO { get; set; }

        public virtual Model Model1 { get; set; }
    }
}
