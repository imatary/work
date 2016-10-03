namespace Lib.Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class GARecruitmentDbContext : DbContext
    {
        public GARecruitmentDbContext()
            : base("name=GARecruitmentDbContext")
        {
        }

        public virtual DbSet<Result> Results { get; set; }
        public virtual DbSet<Score> Scores { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Result>()
                .Property(e => e.Id)
                .IsUnicode(false);

            modelBuilder.Entity<Result>()
                .Property(e => e.Sex)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Result>()
                .Property(e => e.PhoneNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Result>()
                .Property(e => e.Hight)
                .IsUnicode(false);

            modelBuilder.Entity<Result>()
                .Property(e => e.CMT)
                .IsUnicode(false);

            modelBuilder.Entity<Result>()
                .Property(e => e.StaffID)
                .IsUnicode(false);

            modelBuilder.Entity<Result>()
                .Property(e => e.StaffCode)
                .IsUnicode(false);

            modelBuilder.Entity<Result>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Result>()
                .Property(e => e.ModifyBy)
                .IsUnicode(false);

            modelBuilder.Entity<Score>()
                .Property(e => e.Birthday)
                .IsUnicode(false);

            modelBuilder.Entity<Score>()
                .Property(e => e.KetQua)
                .IsUnicode(false);

            modelBuilder.Entity<Score>()
                .Property(e => e.KetQuaPicture)
                .IsUnicode(false);

            modelBuilder.Entity<Score>()
                .Property(e => e.KetQuaEye)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsUnicode(false);
        }
    }
}
