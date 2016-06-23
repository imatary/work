// cuongpv
// Cương Phạm Văn
// Lib.Data
// 21/04/2016

using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Lib.Models;

namespace Lib.Data
{
    public class OverTimeDbContext : DbContext
    {
        public OverTimeDbContext()
            : base("name=OverTimeDbContext")
        {
            var adapter = (IObjectContextAdapter)this;
            var objectContext = adapter.ObjectContext;
            objectContext.CommandTimeout = 5 * 60; // value in seconds
        }

        public virtual void Commit()
        {
            base.SaveChanges();
        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Employess> Employesses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<Tag>()
            //    .HasMany(c => c.Categories)
            //    .WithMany(t => t.Tags)
            //    .Map(ct =>
            //    {
            //        ct.ToTable("CategoriesInTags");
            //        ct.MapRightKey("CategoryId");
            //        ct.MapLeftKey("TagId");
            //    });

            modelBuilder.Conventions.Remove<IncludeMetadataConvention>();
        }
    }
}