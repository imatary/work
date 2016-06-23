using Lib.Models;

namespace Lib.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Lib.Data.OverTimeDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(Lib.Data.OverTimeDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Departments.AddOrUpdate(
                d=>d.DepartmentID,
                new Department() { DepartmentID = "PD-IT", Name = "PD-IT", Description = "Dept PD-IT"},
                new Department() { DepartmentID = "EQ", Name = "EQ", Description = "Dept EQ" },
                new Department() { DepartmentID = "PL", Name = "PL", Description = "Dept PL" },
                new Department() { DepartmentID = "GA", Name = "GA", Description = "Dept GA" },
                new Department() { DepartmentID = "EDU", Name = "Edu", Description = "Dept Edu" }
                );
        }


    }
}
