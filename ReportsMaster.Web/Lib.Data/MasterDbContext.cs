namespace Lib.Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MasterDbContext : DbContext
    {
        public MasterDbContext()
            : base("name=MasterDbContext")
        {
        }

        public virtual DbSet<Broad> Broads { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Line> Lines { get; set; }
        public virtual DbSet<Model> Models { get; set; }
        public virtual DbSet<Plan> Plans { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Broad>()
                .Property(e => e.BroadID)
                .IsUnicode(false);

            modelBuilder.Entity<Broad>()
                .Property(e => e.CusID)
                .IsUnicode(false);

            modelBuilder.Entity<Broad>()
                .Property(e => e.LineID)
                .IsUnicode(false);

            modelBuilder.Entity<Broad>()
                .Property(e => e.ModelID)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.CusID)
                .IsUnicode(false);

            modelBuilder.Entity<Line>()
                .Property(e => e.LineID)
                .IsUnicode(false);

            modelBuilder.Entity<Model>()
                .Property(e => e.ModelID)
                .IsUnicode(false);

            modelBuilder.Entity<Model>()
                .Property(e => e.LineID)
                .IsUnicode(false);

            modelBuilder.Entity<Model>()
                .Property(e => e.CusID)
                .IsUnicode(false);

            modelBuilder.Entity<Plan>()
                .Property(e => e.LineID)
                .IsUnicode(false);

            modelBuilder.Entity<Plan>()
                .Property(e => e.ModelID)
                .IsUnicode(false);
        }
    }
}
