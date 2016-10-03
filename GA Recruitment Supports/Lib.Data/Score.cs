namespace Lib.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Score
    {
        [Key]
        [Column(Order = 0)]
        public Guid Id { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "date")]
        public DateTime DateCreated { get; set; }

        [Required]
        [StringLength(150)]
        public string FullName { get; set; }

        [Required]
        [StringLength(15)]
        public string Birthday { get; set; }

        public int PI_P1 { get; set; }

        public int PI_P2 { get; set; }

        public int PI_P3 { get; set; }

        public int PI_P4 { get; set; }

        public int PI_P5 { get; set; }

        public int PI_P6 { get; set; }

        public int PI_P7 { get; set; }

        public int PI_P8 { get; set; }

        public int PI_P9 { get; set; }

        public int PI_P10 { get; set; }

        public int PI_P11 { get; set; }

        public int PI_P12 { get; set; }

        public int PI_P13 { get; set; }

        public int PI_E1 { get; set; }

        public int PI_E2 { get; set; }

        public int PI_E3 { get; set; }

        public int PI_E4 { get; set; }

        public int PI_E5 { get; set; }

        public int PI_E6 { get; set; }

        public int PI_E7 { get; set; }

        public int PI_E8 { get; set; }

        public int PI_E9 { get; set; }

        public int PI_E10 { get; set; }

        public int PI_E11 { get; set; }

        public int PI_E12 { get; set; }

        public int PI_E13 { get; set; }

        public int PII_P1 { get; set; }

        public int PII_P2 { get; set; }

        public int PII_P3 { get; set; }

        public int PII_P4 { get; set; }

        public int PII_P5 { get; set; }

        public int PII_P6 { get; set; }

        public int PII_P7 { get; set; }

        public int PII_P8 { get; set; }

        public int PII_P9 { get; set; }

        public int PII_P10 { get; set; }

        public int PII_P11 { get; set; }

        public int PII_P12 { get; set; }

        public int PII_P13 { get; set; }

        public int PII_E1 { get; set; }

        public int PII_E2 { get; set; }

        public int PII_E3 { get; set; }

        public int PII_E4 { get; set; }

        public int PII_E5 { get; set; }

        public int PII_E6 { get; set; }

        public int PII_E7 { get; set; }

        public int PII_E8 { get; set; }

        public int PII_E9 { get; set; }

        public int PII_E10 { get; set; }

        public int PII_E11 { get; set; }

        public int PII_E12 { get; set; }

        public int PII_E13 { get; set; }

        public int PI_SumPear { get; set; }

        public int PI_SumEven { get; set; }

        public int PII_SumPear { get; set; }

        public int PII_SumEven { get; set; }

        public int TotalPear { get; set; }

        public int TotalEven { get; set; }

        public int Percent { get; set; }

        public int Difference { get; set; }

        [Required]
        [StringLength(10)]
        public string KetQua { get; set; }

        public int ScorePicture { get; set; }

        public int PercentPicture { get; set; }

        [Required]
        [StringLength(10)]
        public string KetQuaPicture { get; set; }

        public int ScoreEye { get; set; }

        [Required]
        [StringLength(10)]
        public string KetQuaEye { get; set; }

        public bool IsOK { get; set; }
    }
}
