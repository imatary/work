namespace Lib.Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class GADbContext : DbContext
    {
        public GADbContext()
            : base("name=GADbContext")
        {
        }

        public virtual DbSet<MS_Department> MS_Department { get; set; }
        public virtual DbSet<MS_Position> MS_Position { get; set; }
        public virtual DbSet<PR_Staff> PR_Staff { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MS_Department>()
                .Property(e => e.DeptCode)
                .IsUnicode(false);

            modelBuilder.Entity<MS_Department>()
                .Property(e => e.TypeOf)
                .IsUnicode(false);

            modelBuilder.Entity<MS_Position>()
                .Property(e => e.PosCode)
                .IsUnicode(false);

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
