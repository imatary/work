namespace Lib.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Result
    {
        [StringLength(350)]
        public string Id { get; set; }

        [Required]
        [StringLength(150)]
        public string FullName { get; set; }

        [Column(TypeName = "date")]
        public DateTime Birthday { get; set; }

        [Required]
        [StringLength(5)]
        public string Sex { get; set; }

        public string GioiTinh {
            get {
                if(Sex == "0")
                {
                    return "Nam";
                }
                else if(Sex == "1")
                {
                    return "Nữ";
                }

                return null;
            }
        }

        [Required]
        [StringLength(15)]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(350)]
        public string NS { get; set; }

        [Required]
        [StringLength(350)]
        public string HKTT { get; set; }

        [Required]
        [StringLength(150)]
        public string DT { get; set; }

        [Required]
        [StringLength(10)]
        public string Hight { get; set; }

        [Required]
        [StringLength(15)]
        public string CMT { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgayCap { get; set; }

        [Required]
        [StringLength(150)]
        public string NoiCap { get; set; }

        [Required]
        [StringLength(1000)]
        public string Experiene { get; set; }

        [Required]
        [StringLength(15)]
        public string StaffID { get; set; }

        [Required]
        [StringLength(15)]
        public string StaffCode { get; set; }

        [Required]
        [StringLength(100)]
        public string Dept { get; set; }

        [Required]
        [StringLength(150)]
        public string Position { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgayPV { get; set; }

        [Required]
        [StringLength(150)]
        public string NguoiPV { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgayDiLam { get; set; }

        [Required]
        [StringLength(50)]
        public string CreatedBy { get; set; }

        [Column(TypeName = "date")]
        public DateTime CreatedDate { get; set; }

        [StringLength(50)]
        public string ModifyBy { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ModifyDate { get; set; }

        public bool IsAysnc { get; set; }
    }
}
