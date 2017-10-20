namespace CartonLabels.App
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Label
    {
        [Required]
        [StringLength(250)]
        public string CreatedDate { get; set; }

        [StringLength(150)]
        public string DeliveryDate { get; set; }

        [StringLength(250)]
        public string FinalConsignee { get; set; }

        [StringLength(500)]
        public string Supplier { get; set; }

        [StringLength(250)]
        public string PoNo { get; set; }

        [StringLength(150)]
        public string GrossWeight { get; set; }

        [StringLength(150)]
        public string BoxQuantity { get; set; }

        [StringLength(150)]
        public string POQuantity { get; set; }

        [StringLength(250)]
        public string PartNo { get; set; }

        [StringLength(150)]
        public string CNO { get; set; }

        [StringLength(150)]
        public string ManufactureDate { get; set; }

        public int ID { get; set; }
    }
}
