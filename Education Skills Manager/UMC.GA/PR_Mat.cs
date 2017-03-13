namespace UMC.GA
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PR_Mat
    {
        [Key]
        [StringLength(10)]
        public string StaffCode { get; set; }

        [StringLength(50)]
        public string CapDo { get; set; }

        public DateTime? NgayCap { get; set; }

        [StringLength(50)]
        public string NangCap { get; set; }

        public DateTime? NgayNangCap { get; set; }

        [StringLength(50)]
        public string LoaiChuyenDoi { get; set; }

        public DateTime? NgayChuyenDoi { get; set; }

        public DateTime? NgayThi { get; set; }

        public DateTime? NgayThiThucTe { get; set; }

        [StringLength(50)]
        public string KetQuaThi { get; set; }

        public int? SoLanThi { get; set; }

        [StringLength(150)]
        public string CNNguoiDaoTao { get; set; }

        public DateTime? NgayCNNguoiDaoTao { get; set; }
    }
}
