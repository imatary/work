namespace Lib.GA.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MS_Department
    {
        [Key]
        [StringLength(50)]
        public string DeptCode { get; set; }

        [StringLength(255)]
        public string DeptName { get; set; }

        [StringLength(3)]
        public string TypeOf { get; set; }
    }
}
