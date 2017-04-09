using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace EducationSkills.Data
{
    public partial class EDU_Olympics
    {
        [Key]
        public int ID { get; set; }
        public string StaffCode { get; set; }
        public string TestContent { get; set; }
        public int? TestNumber { get; set; }
        public DateTime TestDate { get; set; }
        public string TestResults { get; set; }
    }
}
