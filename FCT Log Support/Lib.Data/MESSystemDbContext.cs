namespace Lib.Data
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

        public virtual DbSet<INSPECTION_STATIONS> INSPECTION_STATIONS { get; set; }
        public virtual DbSet<SCANNING_LOGS> SCANNING_LOGS { get; set; }

        public virtual DbSet<WORK_ORDER_ITEMS> WORK_ORDER_ITEMS { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
