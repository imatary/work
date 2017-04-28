using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EducationSkills.Models
{
    public class ManageCertificates
    {
        public string StaffCode { get; set; }
        public string FullName { get; set; }
        public string DeptCode { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Sex { get; set; }
        public DateTime? EntryDate { get; set; }
        public string PosName { get; set; }
        public string TrainingContent { get; set; }
        public string TrainingType { get; set; }
        public DateTime? TrainingStartDate { get; set; }
        public DateTime? TraingEndDate { get; set; }
        public string Certificate { get; set; }
        public int? DeadlineCertificate { get; set; }
        public string Note { get; set; }
    }
}
