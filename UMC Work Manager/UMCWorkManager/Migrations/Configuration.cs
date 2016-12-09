namespace UMCWorkManager.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using UMCWorkManager.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "UMCWorkManager.Models.ApplicationDbContext";
        }

        protected override void Seed(ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            // Role
            context.Roles.AddOrUpdate(
              p => p.Name,
              new IdentityRole { Name = "Manager" },
              new IdentityRole { Name = "Employee" },
              new IdentityRole { Name = "Admin" }
            );


            string passwordHash = "AMJP5nyBAgf/u3vrBKT6jIkH35TttZMW5rP1mGJGhO/QXbSuTgR27pMutgFq9D55hA==";
            string securityStamp = "2debd1db-1570-4e49-8c57-476c88f3e9fa";
            context.Users.AddOrUpdate(
                p => p.Email,
                    new ApplicationUser() { UserName = "cuongpham@umcvn.com", Email= "cuongpham@umcvn.com", PasswordHash = passwordHash, SecurityStamp = securityStamp },
                    new ApplicationUser() { UserName = "admin@umcvn.com", Email = "admin@umcvn.com", PasswordHash = passwordHash, SecurityStamp = securityStamp },
                    new ApplicationUser() { UserName = "user@umcvn.com", Email = "user@umcvn.com", PasswordHash = passwordHash, SecurityStamp = securityStamp }
                );


            // Status
            context.Statuses.AddOrUpdate(
              p => p.Title,
                new Status() { Title = "Waiting", Color = "#5B9BE0" },
                new Status() { Title = "In progress", Color = "#FE7510" },
                new Status() { Title = "Done", Color = "#76B007" }
            );

            SeedAddToRole(context);
        }

        /// <summary>
        /// Add User to role
        /// </summary>
        /// <param name="context"></param>
        private void SeedAddToRole(ApplicationDbContext context)
        {
            string roleName = "Manager";
            // Role
            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);

            // User
            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);


            var user1 = context.Users.SingleOrDefault(u => u.UserName == "cuongpham@umcvn.com");
            if (user1 != null)
            {
                userManager.AddToRole(user1.Id, roleName);
            }

            var user2 = context.Users.SingleOrDefault(u => u.UserName == "admin@umcvn.com");
            if(user2 != null)
            {
                userManager.AddToRole(user2.Id, "Admin");
            }
            var user3 = context.Users.SingleOrDefault(u => u.UserName == "user@umcvn.com");
            if (user3 !=null )
            {
                userManager.AddToRole(user3.Id, "Employee");
            }
        }
    }
}
