namespace UMC.GA
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PR_Han
    {
        [Key]
        [StringLength(10)]
        public string StaffCode { get; set; }

        [StringLength(50)]
        public string CapDoHan { get; set; }

        public DateTime? NgayCap { get; set; }

        [StringLength(50)]
        public string NangCapDo { get; set; }

        public DateTime? NgayNangCap { get; set; }

        [StringLength(150)]
        public string CNNguoiDaoTao { get; set; }

        public DateTime? NgayCNNguoiDaoTao { get; set; }

        public DateTime? NgayThiXacNhan { get; set; }

        public DateTime? NgayThiThucTe { get; set; }

        [StringLength(10)]
        public string KetQuaThiXacNhan { get; set; }

        public int? Solanthi { get; set; }
    }
}
