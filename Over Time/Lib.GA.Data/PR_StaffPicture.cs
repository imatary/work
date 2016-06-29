namespace Lib.GA.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PR_StaffPicture
    {
        [Key]
        [StringLength(10)]
        public string StaffCode { get; set; }

        [StringLength(50)]
        public string ImageName { get; set; }

        [Column(TypeName = "image")]
        public byte[] StaffPicture { get; set; }
    }
}
