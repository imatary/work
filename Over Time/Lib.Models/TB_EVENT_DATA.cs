namespace Lib.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TB_EVENT_DATA
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int nEventIdn { get; set; }

        [Required]
        [StringLength(64)]
        public string sName { get; set; }

        [Required]
        [StringLength(255)]
        public string sDescription { get; set; }
    }
}
