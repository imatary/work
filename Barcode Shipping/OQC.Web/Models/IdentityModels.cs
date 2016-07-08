using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace OQC.Web.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUserLogin : IdentityUserLogin<string>
    {
        
    }

    public class ApplicationUserClaim : IdentityUserClaim<string>
    {
        
    }

    public class ApplicationUserRole : IdentityUserRole<string>
    {
        
    }

    // Must be expressed in terms of our custom Role and other types:


    // Must be expressed in terms of our custom UserRole:

    // Must be expressed in terms of our custom types:
    public class ApplicationDbContext
        : IdentityDbContext<ApplicationUser, ApplicationRole,
        string, ApplicationUserLogin, ApplicationUserRole, ApplicationUserClaim>
    {
        public ApplicationDbContext()
            : base("name=OQCDbContext")
        {

        }

        //static ApplicationDbContext()
        //{
        //    Database.SetInitializer<ApplicationDbContext>(new ApplicationDbInitializer());
        //}

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        // Add the ApplicationGroups property:
        public virtual IDbSet<ApplicationGroup> ApplicationGroups { get; set; }

        // Override OnModelsCreating:
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationGroup>()
                .HasMany<ApplicationUserGroup>((ApplicationGroup g) => g.ApplicationUsers)
                .WithRequired().HasForeignKey<string>((ApplicationUserGroup ag) => ag.ApplicationGroupId);
            modelBuilder.Entity<ApplicationUserGroup>()
                .HasKey((ApplicationUserGroup r) =>
                    new
                    {
                        ApplicationUserId = r.ApplicationUserId,
                        ApplicationGroupId = r.ApplicationGroupId
                    }).ToTable("ApplicationUserGroups");

            modelBuilder.Entity<ApplicationGroup>()
                .HasMany<ApplicationGroupRole>((ApplicationGroup g) => g.ApplicationRoles)
                .WithRequired().HasForeignKey<string>((ApplicationGroupRole ap) => ap.ApplicationGroupId);
            modelBuilder.Entity<ApplicationGroupRole>().HasKey((ApplicationGroupRole gr) =>
                new
                {
                    ApplicationRoleId = gr.ApplicationRoleId,
                    ApplicationGroupId = gr.ApplicationGroupId
                }).ToTable("ApplicationGroupRoles");

        }
    }
}