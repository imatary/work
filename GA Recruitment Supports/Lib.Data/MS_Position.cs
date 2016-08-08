namespace Lib.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MS_Position
    {
        [Key]
        [StringLength(10)]
        public string PosCode { get; set; }

        [StringLength(255)]
        public string PosName { get; set; }
    }
}
