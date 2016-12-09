namespace Lib.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class TB_EVENT
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int nEventIdn { get; set; }

        [Required]
        [StringLength(64)]
        public string sName { get; set; }

        public short nPriority { get; set; }

        public short nAck { get; set; }

        public int nSWAlarmIdn { get; set; }

        public int nAlarmEmailIdn { get; set; }

        [Required]
        [StringLength(255)]
        public string sDescription { get; set; }
    }
}
