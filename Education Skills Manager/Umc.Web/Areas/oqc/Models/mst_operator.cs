namespace Umc.Web.Areas.oqc.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class mst_operator
    {
        [Key]
        [StringLength(5)]
        public string OperatorID { get; set; }

        [StringLength(30)]
        public string OperatorName { get; set; }
    }
}
