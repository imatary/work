namespace Umc.Web.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Umc.Web.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(Umc.Web.Models.ApplicationDbContext context)
        {
            string password = "@Umcvn";
            string[] roles = { "Edu", "Admin", "QA", "OQC" };

            foreach (var role in roles)
            {
                if (!context.Roles.Any(r => r.Name == role))
                {
                    var store = new RoleStore<IdentityRole>(context);
                    var manager = new RoleManager<IdentityRole>(store);
                    var roleAdd = new IdentityRole { Id = Guid.NewGuid().ToString(), Name = role };
                    manager.Create(roleAdd);
                }
            }

            if (!context.Users.Any(u => u.UserName == "edu"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = "edu",
                    Email = "edu@umcvn.com",
                    NameIdentifier= "edu@umcvn.com"
                };

                manager.Create(user, password);
                manager.AddToRole(user.Id, "Edu");
            }

            if (!context.Users.Any(u => u.UserName == "admin"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = "admin",
                    Email = "admin@umcvn.com",
                    NameIdentifier = "admin@umcvn.com"
                };

                manager.Create(user, password);
                manager.AddToRole(user.Id, "Admin");
            }

            if (!context.Users.Any(u => u.UserName == "oqc"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = "oqc",
                    Email = "oqc@umcvn.com",
                    NameIdentifier= "oqc@umcvn.com"
                };

                manager.Create(user, password);
                manager.AddToRole(user.Id, "OQC");
            }
        }


    }
}
