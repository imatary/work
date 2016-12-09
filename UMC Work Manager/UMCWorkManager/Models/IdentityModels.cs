using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace UMCWorkManager.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public byte[] Avatar { get; set; }
        [StringLength(15)]
        public string Code { get; set; }
        [StringLength(15)]
        public string Dept { get; set; }
        [StringLength(15)]
        public string Position { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            //userIdentity.AddClaim(new Claim("avatar", Avatar));
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }


        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Status> Statuses { get; set; }
        public DbSet<Work> Works { get; set; }
    }
}