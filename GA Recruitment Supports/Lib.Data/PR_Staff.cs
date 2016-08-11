namespace Lib.Data
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public partial class PR_Staff
    {
        [Key]
        [StringLength(10)]
        public string StaffCode { get; set; }

        [StringLength(20)]
        public string ICCode { get; set; }

        public short KindOfWork { get; set; }

        public short? TimeTraining { get; set; }

        public DateTime? EntryDate { get; set; }

        public bool? Foreigner { get; set; }

        [StringLength(100)]
        public string FullName { get; set; }

        [StringLength(100)]
        public string FullNameOther { get; set; }

        public DateTime BirthDate { get; set; }

        [StringLength(200)]
        public string BirthPlace { get; set; }

        public byte? Sex { get; set; }

        [StringLength(10)]
        public string BloodGroup { get; set; }

        public bool? Children { get; set; }

        [StringLength(10)]
        public string MaritalStatus { get; set; }

        [StringLength(10)]
        public string Nationality { get; set; }

        [StringLength(50)]
        public string Homeland { get; set; }

        [StringLength(10)]
        public string RelCode { get; set; }

        [StringLength(50)]
        public string EduCode { get; set; }

        [StringLength(50)]
        public string FLanguage1 { get; set; }

        [StringLength(50)]
        public string FLanguage2 { get; set; }

        [StringLength(255)]
        public string PermanentAdd { get; set; }

        [StringLength(255)]
        public string PresentAdd { get; set; }

        [StringLength(50)]
        public string EmailAdd { get; set; }

        [StringLength(50)]
        public string Telephone { get; set; }

        [StringLength(50)]
        public string HandPhone { get; set; }

        public string UrgentContact { get; set; }

        [StringLength(50)]
        public string IdentityNo { get; set; }

        public DateTime? IssueDateIdentity { get; set; }

        [StringLength(255)]
        public string IssuePlaceIdentity { get; set; }

        [StringLength(50)]
        public string PassportNo { get; set; }

        public DateTime? IssueDatePassport { get; set; }

        public DateTime? ExpiredDatePassport { get; set; }

        [StringLength(50)]
        public string VisaNo { get; set; }

        public DateTime? IssueDateNoVisa { get; set; }

        public DateTime? ExpiredDateVisa { get; set; }

        [StringLength(50)]
        public string ResidentCard { get; set; }

        public DateTime? IssueDateResident { get; set; }

        public DateTime? ExpiredDateResident { get; set; }

        [StringLength(50)]
        public string WorkPermit { get; set; }

        public DateTime? IssueDateWorkPermit { get; set; }

        public DateTime? ExpiredDateWorkPermit { get; set; }

        public short? Distance { get; set; }

        public double? AllowBus { get; set; }

        [StringLength(500)]
        public string Note { get; set; }

        [StringLength(20)]
        public string TaxCode { get; set; }

        [StringLength(20)]
        public string AccountNo { get; set; }

        [StringLength(50)]
        public string BankName { get; set; }

        public bool? Insurance { get; set; }

        public bool? TradeUnion { get; set; }

        [StringLength(50)]
        public string SocialInsuranceNo { get; set; }

        [StringLength(50)]
        public string HealthInsuranceCard { get; set; }

        [StringLength(100)]
        public string RegistedHealthCenter { get; set; }

        [StringLength(10)]
        public string SkillCode { get; set; }

        public DateTime? SkillApplied { get; set; }

        public byte? IsStatus { get; set; }

        public byte? ModeInComeTax { get; set; }

        public bool? NoOverTime { get; set; }

        public bool NoOverTimeSunHol { get; set; }

        public bool? PIT { get; set; }
    }
}
