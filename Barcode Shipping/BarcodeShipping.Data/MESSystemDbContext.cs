namespace BarcodeShipping.Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MESSystemDbContext : DbContext
    {
        public MESSystemDbContext()
            : base("name=MESSystemDbContext")
        {
        }

        public virtual DbSet<WORK_ORDER_ITEMS> WORK_ORDER_ITEMS { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }
    }
}
