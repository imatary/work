using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EducationSkills.Models
{
    public class PivotSkillMap
    {
        public string StaffCode { get; set; }
        public string FullName { get; set; }
        public string DeptCode { get; set; }
        public IEnumerable<string> MaBoMon { get; set; }
        public IEnumerable<DateTime?> NgayThamGia { get; set; }
    }
}
