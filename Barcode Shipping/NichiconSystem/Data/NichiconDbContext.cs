using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace NichiconSystem.Data
{
    public class NichiconDbContext : DbContext
    {
        //static string connecting()
        //{
        //    var pathDB = System.IO.Path.Combine(Environment.CurrentDirectory, "Nichicon.sqlite");
        //    if (!System.IO.File.Exists(pathDB))
        //        System.IO.File.Create(pathDB);
        //    string path = "c:\\db\\test.sqlite";
        //    return string.Format("data source={0}", path);

        //}

        public NichiconDbContext()
            : base("name=NichiconDbContext")
        {
            Configuration.ProxyCreationEnabled = true;
            Configuration.LazyLoadingEnabled = true;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Model>();
            modelBuilder.Entity<Operator>();

            var initializer = new NichiconInitializers(modelBuilder);

            Database.SetInitializer(initializer);
        }

        public DbSet<Model> Models { get; set; }
        public DbSet<Operator> Operators { get; set; }
        public DbSet<Nichicon> Nichicon { get; set; }
    }
}
