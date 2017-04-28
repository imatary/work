using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace EducationSkills.Data
{
    public partial class EDU_ManageCertificates
    {
        [Key]
        public int ID { get; set; }
        public string StaffCode { get; set; }
        public string TrainingContent { get; set; }
        public string TrainingType { get; set; }
        public DateTime? TrainingStartDate { get; set; }
        public DateTime? TraingEndDate { get; set; }
        public string Certificate { get; set; }
        public int? DeadlineCertificate { get; set; }
        public string Note { get; set; }
    }
}
