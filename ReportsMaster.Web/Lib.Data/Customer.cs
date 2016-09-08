namespace Lib.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Customer
    {
        public Guid ID { get; set; }

        [Required]
        [StringLength(50)]
        public string CusID { get; set; }

        [Required]
        [StringLength(150)]
        public string CusName { get; set; }

        [StringLength(350)]
        public byte[] Logo { get; set; }
    }
}
