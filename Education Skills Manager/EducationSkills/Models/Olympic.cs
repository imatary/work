using System;

namespace EducationSkills.Models
{
    public class Olympic
    {
        public int ID { get; set; }
        public string StaffCode { get; set; }
        public string FullName { get; set; }
        public string DeptCode { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Sex { get; set; }
        public DateTime? EntryDate { get; set; }
        public string PosName { get; set; }
        public string TestContent { get; set; }
        public int? TestNumber { get; set; }
        public DateTime TestDate { get; set; }
        public string TestResults { get; set; }
    }
}
