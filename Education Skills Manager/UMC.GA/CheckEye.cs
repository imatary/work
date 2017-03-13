using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMC.GA
{
    public class CheckEye
    {
        public byte[] StaffPicture { get; set; }
        public string StaffCode { get; set; }
        public string FullName { get; set; }
        public string DeptCode { get; set; }
        public string CapDo { get; set; }
        public DateTime? NgayCap { get; set; }
        public string NangCap { get; set; }
        public DateTime? NgayNangCap { get; set; }
        public string LoaiChuyenDoi { get; set; }
        public DateTime? NgayChuyenDoi { get; set; }
        public DateTime? NgayThi { get; set; }
        public DateTime? NgayThiThucTe { get; set; }
        public string KetQuaThi { get; set; }
        public int? SoLanThi { get; set; }
        public string CNNguoiDaoTao { get; set; }
        public DateTime? NgayCNNguoiDaoTao { get; set; }
    }
}
