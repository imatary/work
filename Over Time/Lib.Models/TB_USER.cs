namespace Lib.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TB_USER
    {
        [Key]
        public int nUserIdn { get; set; }

        [Required]
        [StringLength(96)]
        public string sUserName { get; set; }

        public int nDepartmentIdn { get; set; }

        [Required]
        [StringLength(64)]
        public string sTelNumber { get; set; }

        [Required]
        [StringLength(100)]
        public string sEmail { get; set; }

        [Required]
        [StringLength(64)]
        public string sUserID { get; set; }

        [Required]
        [StringLength(64)]
        public string sPassword { get; set; }

        [Required]
        [MaxLength(32)]
        public byte[] bPassword2 { get; set; }

        public int nStartDate { get; set; }

        public int nEndDate { get; set; }

        public int nAdminLevel { get; set; }

        public int nAuthMode { get; set; }

        public int nAuthLimitCount { get; set; }

        public int nTimedAPB { get; set; }

        public int nEncryption { get; set; }
    }
}
