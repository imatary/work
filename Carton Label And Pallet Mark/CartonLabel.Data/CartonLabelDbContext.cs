namespace CartonLabel.Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class CartonLabelDbContext : DbContext
    {
        public CartonLabelDbContext()
            : base("name=CartonLabelDbContext")
        {
        }

        public virtual DbSet<Label> Labels { get; set; }
        public virtual DbSet<Part> Parts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Label>()
                .Property(e => e.CreatedDate)
                .IsUnicode(false);

            modelBuilder.Entity<Label>()
                .Property(e => e.DeliveryDate)
                .IsUnicode(false);

            modelBuilder.Entity<Label>()
                .Property(e => e.GrossWeight)
                .IsUnicode(false);

            modelBuilder.Entity<Label>()
                .Property(e => e.BoxQuantity)
                .IsUnicode(false);

            modelBuilder.Entity<Label>()
                .Property(e => e.POQuantity)
                .IsUnicode(false);

            modelBuilder.Entity<Label>()
                .Property(e => e.PartNo)
                .IsUnicode(false);

            modelBuilder.Entity<Label>()
                .Property(e => e.CNO)
                .IsUnicode(false);

            modelBuilder.Entity<Label>()
                .Property(e => e.ManufactureDate)
                .IsUnicode(false);

            modelBuilder.Entity<Part>()
                .Property(e => e.PartNoID)
                .IsUnicode(false);

            modelBuilder.Entity<Part>()
                .Property(e => e.PartNoValue)
                .IsUnicode(false);
        }
    }
}
