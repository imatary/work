using System;

namespace EducationSkills.Models
{
    public class ReportsEye
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
        public string CNNguoiDaoTao { get; set; }
        public DateTime? NgayCNNguoiDaoTao { get; set; }
        public DateTime? NgayThi { get; set; }
        public DateTime? NgayThiThucTe { get; set; }
        public string KetQuaThi { get; set; }
        public int? Solanthi { get; set; }

        public string LevelCurrent {
            get {
                string level = "";
                // Cả 3 cùng có thì lấy Level III
                if (Ultils.IsNull(CNNguoiDaoTao) && Ultils.IsNull(NangCap) && Ultils.IsNull(CapDo))
                {
                    level = CNNguoiDaoTao;
                }

                // Level III = null thì lấy Level II
                else if (!Ultils.IsNull(CNNguoiDaoTao) && Ultils.IsNull(NangCap) && Ultils.IsNull(CapDo))
                {
                    level = NangCap;
                }

                // Level III & II = null thì lấy Level I
                else if (!Ultils.IsNull(CNNguoiDaoTao) && !Ultils.IsNull(NangCap) && Ultils.IsNull(CapDo))
                {
                    level = CapDo;
                }

                // Level III & I = null thì lấy Level II
                else if (!Ultils.IsNull(CNNguoiDaoTao) && Ultils.IsNull(NangCap) && !Ultils.IsNull(CapDo))
                {
                    level = NangCap;
                }

                return level;
            }
        }
        public DateTime? LevelDateCurrent { get; set; }

        
    }

    
}
