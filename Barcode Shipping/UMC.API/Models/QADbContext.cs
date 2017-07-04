namespace UMC.API.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class QADbContext : DbContext
    {
        public QADbContext()
            : base("name=QADbContext")
        {
        }

        public virtual DbSet<Model> Models { get; set; }
        public virtual DbSet<mst_operator> mst_operator { get; set; }
        public virtual DbSet<Murata> Muratas { get; set; }
        public virtual DbSet<NICHICON> NICHICONs { get; set; }
        public virtual DbSet<PackingPO> PackingPOes { get; set; }
        public virtual DbSet<QACheck> QAChecks { get; set; }
        public virtual DbSet<Shipping> Shippings { get; set; }
        public virtual DbSet<tbl_test_log> tbl_test_log { get; set; }
        public virtual DbSet<tbl_test_result> tbl_test_result { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Model>()
                .Property(e => e.ModelID)
                .IsUnicode(false);

            modelBuilder.Entity<Model>()
                .Property(e => e.ModelName)
                .IsUnicode(false);

            modelBuilder.Entity<Model>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Model>()
                .Property(e => e.SerialNo)
                .IsUnicode(false);

            modelBuilder.Entity<Model>()
                .Property(e => e.CustomerName)
                .IsUnicode(false);

            modelBuilder.Entity<Model>()
                .Property(e => e.CodeMurata)
                .IsUnicode(false);

            modelBuilder.Entity<Model>()
                .HasMany(e => e.PackingPOes)
                .WithRequired(e => e.Model)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Model>()
                .HasMany(e => e.Shippings)
                .WithRequired(e => e.Model1)
                .HasForeignKey(e => e.Model)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<mst_operator>()
                .Property(e => e.OperatorID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Murata>()
                .Property(e => e.ProductionID)
                .IsUnicode(false);

            modelBuilder.Entity<Murata>()
                .Property(e => e.BoxID)
                .IsUnicode(false);

            modelBuilder.Entity<Murata>()
                .Property(e => e.ModelID)
                .IsUnicode(false);

            modelBuilder.Entity<Murata>()
                .Property(e => e.ModelName)
                .IsUnicode(false);

            modelBuilder.Entity<Murata>()
                .Property(e => e.ModelCustomer)
                .IsUnicode(false);

            modelBuilder.Entity<NICHICON>()
                .Property(e => e.ProductionID)
                .IsUnicode(false);

            modelBuilder.Entity<NICHICON>()
                .Property(e => e.BoxID)
                .IsUnicode(false);

            modelBuilder.Entity<NICHICON>()
                .Property(e => e.ModelID)
                .IsUnicode(false);

            modelBuilder.Entity<NICHICON>()
                .Property(e => e.ModelName)
                .IsUnicode(false);

            modelBuilder.Entity<NICHICON>()
                .Property(e => e.OperatorCode)
                .IsUnicode(false);

            modelBuilder.Entity<PackingPO>()
                .Property(e => e.ModelID)
                .IsUnicode(false);

            modelBuilder.Entity<PackingPO>()
                .Property(e => e.PO_NO)
                .IsUnicode(false);

            modelBuilder.Entity<PackingPO>()
                .Property(e => e.CreateBy)
                .IsUnicode(false);

            modelBuilder.Entity<QACheck>()
                .Property(e => e.ProductionID)
                .IsUnicode(false);

            modelBuilder.Entity<QACheck>()
                .Property(e => e.BoxID)
                .IsUnicode(false);

            modelBuilder.Entity<QACheck>()
                .Property(e => e.OperatorCode)
                .IsUnicode(false);

            modelBuilder.Entity<Shipping>()
                .Property(e => e.Operator)
                .IsUnicode(false);

            modelBuilder.Entity<Shipping>()
                .Property(e => e.Model)
                .IsUnicode(false);

            modelBuilder.Entity<Shipping>()
                .Property(e => e.WorkingOder)
                .IsUnicode(false);

            modelBuilder.Entity<Shipping>()
                .Property(e => e.BoxID)
                .IsUnicode(false);

            modelBuilder.Entity<Shipping>()
                .Property(e => e.ProductID)
                .IsUnicode(false);

            modelBuilder.Entity<Shipping>()
                .Property(e => e.MacAddress)
                .IsUnicode(false);

            modelBuilder.Entity<Shipping>()
                .Property(e => e.PO_NO)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_test_log>()
                .Property(e => e.ProductionID)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_test_log>()
                .Property(e => e.MacAddress)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tbl_test_log>()
                .Property(e => e.BoxID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tbl_test_log>()
                .Property(e => e.ModelID)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_test_log>()
                .Property(e => e.WorkingOder)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_test_log>()
                .Property(e => e.OperatorCode)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_test_log>()
                .Property(e => e.CheckBy)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_test_log>()
                .Property(e => e.ModelCustomer)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_test_result>()
                .Property(e => e.ProductionID)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_test_result>()
                .Property(e => e.OperatorID)
                .IsFixedLength()
                .IsUnicode(false);
        }
    }
}
