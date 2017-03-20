namespace Umc.Web.Areas.Education.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PR_SkillMap
    {
        public int ID { get; set; }

        [Required]
        [StringLength(10)]
        public string StaffCode { get; set; }

        [StringLength(10)]
        public string MaBoMon { get; set; }

        public DateTime? NgayThamGia { get; set; }

        [StringLength(250)]
        public string GhiChu { get; set; }
    }
}
