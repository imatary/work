namespace HondaLook_ICT.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class HD_Models
    {
        [StringLength(100)]
        public string ID { get; set; }

        [StringLength(150)]
        public string ModelName { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        public bool Active { get; set; }
    }
}
