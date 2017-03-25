namespace EducationSkills.Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class EducationSkillsDbContext : DbContext
    {
        public EducationSkillsDbContext()
            : base("name=EducationSkillsDbContext")
        {
        }

        public virtual DbSet<PR_AdminEdu> PR_AdminEdu { get; set; }
        public virtual DbSet<PR_Bomon> PR_Bomon { get; set; }
        public virtual DbSet<PR_Han> PR_Han { get; set; }
        public virtual DbSet<PR_Mat> PR_Mat { get; set; }
        public virtual DbSet<EDU_Certificates> EDU_Certificates { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PR_AdminEdu>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<PR_AdminEdu>()
                .Property(e => e.PassWord)
                .IsUnicode(false);

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

            modelBuilder.Entity<EDU_Certificates>()
                .Property(e => e.ValueMember);
                
        }
    }
}
