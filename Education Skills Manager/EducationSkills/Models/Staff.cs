using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationSkills
{
    public class Staff
    {
        public string StaffCode { get; set; }
        public string FullName { get; set; }
        public string DeptCode { get; set; }
        public byte[] StaffPicture { get; set; }
        public string MaBoMon { get; set; }
        public DateTime? NgayThamGia { get; set; }
        public string TenBoMon { get; set; }
    }
}
