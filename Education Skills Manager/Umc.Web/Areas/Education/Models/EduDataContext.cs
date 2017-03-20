namespace Umc.Web.Areas.Education.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class EduDataContext : DbContext
    {
        public EduDataContext()
            : base("name=EduDataContext")
        {
        }

        public virtual DbSet<PR_Bomon> PR_Bomon { get; set; }
        public virtual DbSet<PR_Han> PR_Han { get; set; }
        public virtual DbSet<PR_Mat> PR_Mat { get; set; }
        public virtual DbSet<PR_SkillMap> PR_SkillMap { get; set; }
        public virtual DbSet<PR_Staff> PR_Staff { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PR_Bomon>()
                .Property(e => e.MaBoMon)
                .IsFixedLength();

            modelBuilder.Entity<PR_Han>()
                .Property(e => e.StaffCode)
                .IsUnicode(false);

            modelBuilder.Entity<PR_Han>()
                .Property(e => e.CNNguoiDaoTao)
                .IsUnicode(false);

            modelBuilder.Entity<PR_Han>()
                .Property(e => e.KetQuaThiXacNhan)
                .IsFixedLength();

            modelBuilder.Entity<PR_Mat>()
                .Property(e => e.StaffCode)
                .IsFixedLength();

            modelBuilder.Entity<PR_Mat>()
                .Property(e => e.LoaiChuyenDoi)
                .IsUnicode(false);

            modelBuilder.Entity<PR_Mat>()
                .Property(e => e.KetQuaThi)
                .IsUnicode(false);

            modelBuilder.Entity<PR_SkillMap>()
                .Property(e => e.StaffCode)
                .IsFixedLength();

            modelBuilder.Entity<PR_SkillMap>()
                .Property(e => e.MaBoMon)
                .IsFixedLength();

            modelBuilder.Entity<PR_Staff>()
                .Property(e => e.StaffCode)
                .IsUnicode(false);

            modelBuilder.Entity<PR_Staff>()
                .Property(e => e.ICCode)
                .IsUnicode(false);

            modelBuilder.Entity<PR_Staff>()
                .Property(e => e.BloodGroup)
                .IsUnicode(false);

            modelBuilder.Entity<PR_Staff>()
                .Property(e => e.MaritalStatus)
                .IsUnicode(false);

            modelBuilder.Entity<PR_Staff>()
                .Property(e => e.Nationality)
                .IsUnicode(false);

            modelBuilder.Entity<PR_Staff>()
                .Property(e => e.RelCode)
                .IsUnicode(false);

            modelBuilder.Entity<PR_Staff>()
                .Property(e => e.EduCode)
                .IsUnicode(false);

            modelBuilder.Entity<PR_Staff>()
                .Property(e => e.FLanguage1)
                .IsUnicode(false);

            modelBuilder.Entity<PR_Staff>()
                .Property(e => e.Telephone)
                .IsUnicode(false);

            modelBuilder.Entity<PR_Staff>()
                .Property(e => e.HandPhone)
                .IsUnicode(false);

            modelBuilder.Entity<PR_Staff>()
                .Property(e => e.IdentityNo)
                .IsUnicode(false);

            modelBuilder.Entity<PR_Staff>()
                .Property(e => e.PassportNo)
                .IsUnicode(false);

            modelBuilder.Entity<PR_Staff>()
                .Property(e => e.VisaNo)
                .IsUnicode(false);

            modelBuilder.Entity<PR_Staff>()
                .Property(e => e.ResidentCard)
                .IsUnicode(false);

            modelBuilder.Entity<PR_Staff>()
                .Property(e => e.WorkPermit)
                .IsUnicode(false);

            modelBuilder.Entity<PR_Staff>()
                .Property(e => e.TaxCode)
                .IsUnicode(false);

            modelBuilder.Entity<PR_Staff>()
                .Property(e => e.AccountNo)
                .IsUnicode(false);

            modelBuilder.Entity<PR_Staff>()
                .Property(e => e.BankName)
                .IsUnicode(false);

            modelBuilder.Entity<PR_Staff>()
                .Property(e => e.SocialInsuranceNo)
                .IsUnicode(false);

            modelBuilder.Entity<PR_Staff>()
                .Property(e => e.HealthInsuranceCard)
                .IsUnicode(false);

            modelBuilder.Entity<PR_Staff>()
                .Property(e => e.SkillCode)
                .IsUnicode(false);
        }
    }
}
