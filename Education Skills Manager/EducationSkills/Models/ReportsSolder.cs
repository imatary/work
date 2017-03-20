using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationSkills.Models
{
    public class ReportsSolder
    {
        public byte[] StaffPicture { get; set; }
        public string StaffCode { get; set; }
        public string FullName { get; set; }
        public string DeptCode { get; set; }
        public string CapDoHan { get; set; }
        public DateTime? NgayCap { get; set; }
        public string NangCapDo { get; set; }
        public DateTime? NgayNangCap { get; set; }
        public string CNNguoiDaoTao { get; set; }
        public DateTime? NgayCNNguoiDaoTao { get; set; }
        public DateTime? NgayThiXacNhan { get; set; }
        public DateTime? NgayThiThucTe { get; set; }
        public string KetQuaThiXacNhan { get; set; }
        public int? Solanthi { get; set; }
    }
}
