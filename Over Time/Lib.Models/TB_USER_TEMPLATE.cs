namespace Lib.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TB_USER_TEMPLATE
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int nUserIdn { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short nIndex { get; set; }

        [Required]
        [MaxLength(384)]
        public byte[] bTemplate { get; set; }

        public int nTemplatecs { get; set; }

        public short nDuress { get; set; }

        public short nEncryption { get; set; }

        public int nSecurityLevel { get; set; }

        public int nFingerIndex { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short nTemplateIndex { get; set; }

        public int nEnrollQuality { get; set; }
    }
}
