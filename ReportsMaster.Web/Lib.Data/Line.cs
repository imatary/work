namespace Lib.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Line
    {
        public Guid ID { get; set; }

        [Required]
        [StringLength(50)]
        public string LineID { get; set; }

        [Required]
        [StringLength(150)]
        public string LineName { get; set; }
    }
}
