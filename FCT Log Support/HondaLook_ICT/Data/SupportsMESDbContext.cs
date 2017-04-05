namespace HondaLook_ICT.Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class SupportsMESDbContext : DbContext
    {
        public SupportsMESDbContext()
            : base("name=SupportsMESDbContext")
        {
        }

        public virtual DbSet<HD_Models> HD_Models { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HD_Models>()
                .Property(e => e.ID)
                .IsUnicode(false);

            modelBuilder.Entity<HD_Models>()
                .Property(e => e.ModelName)
                .IsUnicode(false);
        }
    }
}
