using System.Data.Entity.Infrastructure;

namespace Lib.Models
{
    using System.Data.Entity;

    public partial class BioStarDbContext : DbContext
    {
        public BioStarDbContext()
            : base("name=BioStarDbContext")
        {
            var adapter = (IObjectContextAdapter)this;
            var objectContext = adapter.ObjectContext;
            objectContext.CommandTimeout = 5 * 60; // value in seconds
        }

        public virtual DbSet<TB_EVENT> TB_EVENT { get; set; }
        public virtual DbSet<TB_EVENT_DATA> TB_EVENT_DATA { get; set; }
        public virtual DbSet<TB_EVENT_FACE> TB_EVENT_FACE { get; set; }
        public virtual DbSet<TB_EVENT_LOG> TB_EVENT_LOG { get; set; }
        public virtual DbSet<TB_EVENT_LOG_BK> TB_EVENT_LOG_BK { get; set; }
        public virtual DbSet<TB_USER> TB_USER { get; set; }
        public virtual DbSet<TB_USER_DEPT> TB_USER_DEPT { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TB_USER>()
                .Property(e => e.sTelNumber)
                .IsUnicode(false);

            modelBuilder.Entity<TB_USER>()
                .Property(e => e.sUserID)
                .IsUnicode(false);

            modelBuilder.Entity<TB_USER>()
                .Property(e => e.sPassword)
                .IsUnicode(false);

            modelBuilder.Entity<TB_USER>()
                .Property(e => e.bPassword2)
                .IsFixedLength();
        }
    }
}
