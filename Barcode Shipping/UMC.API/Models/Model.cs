namespace UMC.API.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Model
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Model()
        {
            PackingPOes = new HashSet<PackingPO>();
            Shippings = new HashSet<Shipping>();
            tbl_test_log = new HashSet<tbl_test_log>();
        }

        [StringLength(150)]
        public string ModelID { get; set; }

        [Required]
        [StringLength(250)]
        public string ModelName { get; set; }

        [StringLength(100)]
        public string CreatedBy { get; set; }

        public DateTime DateCreated { get; set; }

        public int Quantity { get; set; }

        [Required]
        [StringLength(50)]
        public string SerialNo { get; set; }

        [StringLength(150)]
        public string CustomerName { get; set; }

        public bool? CheckWidthModelCus { get; set; }

        [StringLength(50)]
        public string CodeMurata { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PackingPO> PackingPOes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Shipping> Shippings { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_test_log> tbl_test_log { get; set; }
    }
}
