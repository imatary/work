namespace Lib.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<TB_USER_TEMPLATE> TB_USER_TEMPLATE { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TB_USER_TEMPLATE>()
                .Property(e => e.bTemplate)
                .IsFixedLength();
        }
    }
}
