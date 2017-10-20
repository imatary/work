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
        public string LevelCurrent
        {
            get
            {
                string level = "";
                // Cả 3 cùng có thì lấy Level III
                if (Ultils.IsNull(CNNguoiDaoTao) && Ultils.IsNull(NangCapDo) && Ultils.IsNull(CapDoHan))
                {
                    level = CNNguoiDaoTao;
                }

                // Level III = null thì lấy Level II
                else if (!Ultils.IsNull(CNNguoiDaoTao) && Ultils.IsNull(NangCapDo) && Ultils.IsNull(CapDoHan))
                {
                    level = NangCapDo;
                }

                // Level III & II = null thì lấy Level I
                else if (!Ultils.IsNull(CNNguoiDaoTao) && !Ultils.IsNull(NangCapDo) && Ultils.IsNull(CapDoHan))
                {
                    level = CapDoHan;
                }

                // Level III & I = null thì lấy Level II
                else if (!Ultils.IsNull(CNNguoiDaoTao) && Ultils.IsNull(NangCapDo) && !Ultils.IsNull(CapDoHan))
                {
                    level = NangCapDo;
                }

                return level;
            }
        }
        public DateTime? LevelDateCurrent { get; set; }

        /// <summary>
        /// Ngày cấp hiện tại
        /// </summary>
        public DateTime? CurrentGrantDate
        {
            get
            {
                DateTime current = new DateTime();
                if ((NgayCNNguoiDaoTao != null) && (NgayNangCap != null) && (NgayCap != null))
                {
                    current = (DateTime)NgayCNNguoiDaoTao;
                }
                else if ((NgayCNNguoiDaoTao == null) && (NgayNangCap != null) && (NgayCap != null))
                {
                    current = (DateTime)NgayNangCap;
                }

                else if ((NgayCNNguoiDaoTao == null) && (NgayNangCap == null) && (NgayCap != null))
                {
                    current = (DateTime)NgayCap;
                }
                else if ((NgayCNNguoiDaoTao == null) && (NgayNangCap != null) && (NgayCap == null))
                {
                    current = (DateTime)NgayNangCap;
                }
                return current;
            }
        }
    }
}
