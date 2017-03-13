using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Umc.Web.Models
{
    public partial class PR_Bomon
    {
        [Key]
        [StringLength(10)]
        public string MaBoMon { get; set; }

        [StringLength(250)]
        public string TenBoMon { get; set; }

        public string CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }

        public string ModifyBy { get; set; }

        public DateTime? ModifyDate { get; set; }

    }
}