using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MeetingRoom.Web.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
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


        public DbSet<Room> Rooms { get; set; }

        public DbSet<Status> Statuses { get; set; }

        public DbSet<CalendarEvent> CalendarEvents { get; set; }

        public DbSet<ColoredEvent> ColoredEvents { get; set; }

        public DbSet<ValidEvent> ValidEvents { get; set; }

        public DbSet<Laptop> Laptops { get; set; }

        public DbSet<Projector> Projectors { get; set; }

        public DbSet<Phone> Phones { get; set; }
    }

    public class InitSampleData : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            SampleData(context);
            base.Seed(context);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        private void SampleData(ApplicationDbContext context)
        {

            /*
            if you need to create data tables
             */
            if (!context.Roles.Any(r => r.Name == "Manager"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole() { Name = "Manager" };
                manager.Create(role);
            }

            if (!context.Users.Any(u => u.UserName == "cuongpv"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser { UserName = "cuongpv", Email = "cuongpham@umcvn.com"};

                manager.Create(user, "umcevn");
                manager.AddToRole(user.Id, "Manager");
            }

            if (!context.Users.Any(u => u.UserName == "cuongpv"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser { UserName = "cuongpv", Email = "cuongpham@umcvn.com" };

                manager.Create(user, "umcevn");
                manager.AddToRole(user.Id, "Manager");
            }

            if (!context.Users.Any(u => u.UserName == "chinhha"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser { UserName = "chinhha", Email = "chinhha@umcvn.com" };

                manager.Create(user, "umcevn");
                manager.AddToRole(user.Id, "Manager");
            }


            if (!context.Users.Any(u => u.UserName == "tungnt"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser { UserName = "tungnt", Email = "tungnt@umcvn.com" };

                manager.Create(user, "umcevn");
                manager.AddToRole(user.Id, "Manager");
            }


            if (!context.Users.Any(u => u.UserName == "huypq"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser { UserName = "huypq", Email = "huypq@umcvn.com" };

                manager.Create(user, "umcevn");
                manager.AddToRole(user.Id, "Manager");
            }
            if (!context.Users.Any(u => u.UserName == "longnv"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser { UserName = "longnv", Email = "longnv@umcvn.com" };

                manager.Create(user, "umcevn");
                manager.AddToRole(user.Id, "Manager");
            }

            if (!context.Users.Any(u => u.UserName == "hangpt"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser { UserName = "hangpt", Email = "hangpt@umcvn.com" };

                manager.Create(user, "umcevn");
                manager.AddToRole(user.Id, "Manager");
            }

            if (!context.Users.Any(u => u.UserName == "thept"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser { UserName = "thept", Email = "thept@umcvn.com" };

                manager.Create(user, "umcevn");
                manager.AddToRole(user.Id, "Manager");
            }
            if (!context.Users.Any(u => u.UserName == "phuongdt"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser { UserName = "phuongdt", Email = "phuongdt@umcvn.com" };

                manager.Create(user, "umcevn");
                manager.AddToRole(user.Id, "Manager");
            }

            context.Statuses.AddRange(new[]
            {
                new Status() {title = "Waiting", color = "#5B9BE0"},
                new Status() {title = "In progress", color = "#FE7510"},
                new Status() {title = "Done", color = "#76B007"}
            });

            context.Rooms.AddRange(
                new[]
                {
                    new Room {key = 1, label = "Meeting Room 1", is_projector = false, phone = "2011", position = 2, },
                    new Room {key = 2, label = "Meeting Room 2", is_projector = false, phone = "2400", position = 3, },
                    new Room {key = 3, label = "Meeting Room 3", is_projector = false, phone = "2401", position = 4,  },
                    new Room {key = 4, label = "Meeting Room 4", is_projector = false, phone = "2402", position = 5, },
                    new Room {key = 5, label = "Meeting Room 5", is_projector = false, phone = "2346", position = 6, },
                    new Room {key = 6, label = "Meeting Room 6", is_projector = false, phone = "2333", position = 7,},
                    new Room {key = 7, label = "Meeting Room 7", is_projector = true, phone = "2010", position = 8,},
                    new Room {key = 8, label = "Meeting Room 8", is_projector = false, phone = "2001", position = 9,},
                    new Room {key = 9, label = "Meeting Room 9", is_projector = false, phone = "2102", position = 10,},
                    new Room {key = 10, label = "Meeting Room B", is_projector = false, phone = "2304", position = 11,},
                    new Room {key = 11, label = "General Director", is_projector = false, phone = "2222", position = 1,},
                });

            context.Laptops.AddRange(new[]
            {
                new Laptop {laptop_id = "NotUse", laptop_name = "Not Use", is_empty = false, position = 1,},
                new Laptop {laptop_id = "UMC-C161", laptop_name = "UMC-C161", is_empty = false, position = 2,},
                new Laptop {laptop_id = "UMC-C240", laptop_name = "UMC-C240", is_empty = false, position = 3,},
                new Laptop {laptop_id = "UMC-C241", laptop_name = "UMC-C241", is_empty = false, position = 4,},
                new Laptop {laptop_id = "UMC-C242", laptop_name = "UMC-C242", is_empty = false, position = 5,},
                new Laptop {laptop_id = "UMC-C321", laptop_name = "UMC-C321", is_empty = false, position = 6,},
                new Laptop {laptop_id = "UMC-C322", laptop_name = "UMC-C322", is_empty = false, position = 7,},
                new Laptop {laptop_id = "UMC-C390", laptop_name = "UMC-C390", is_empty = false, position = 9,},
                new Laptop {laptop_id = "Empty", laptop_name = "Empty", is_empty = true, position = 10,},

            });


            context.Projectors.AddRange(new[]
            {
                new Projector() {projector_id = "NotUse", projector_name = "Not Use", is_empty = false, position = 1, },
                new Projector() {projector_id = "UMC-PJ003", projector_name = "UMC-PJ003", is_empty = false, position = 2, },
                new Projector() {projector_id = "UMC-PJ004", projector_name = "UMC-PJ004", is_empty = false, position = 3, },
                new Projector() {projector_id = "UMC-PJ006", projector_name = "UMC-PJ006", is_empty = false, position = 4, },
                new Projector() {projector_id = "UMC-PJ007", projector_name = "UMC-PJ007", is_empty = false, position = 5, },
                new Projector() {projector_id = "UMC-PJ008", projector_name = "UMC-PJ008", is_empty = false, position = 6, },
                new Projector() {projector_id = "UMC-PJ009", projector_name = "UMC-PJ009", is_empty = false, position = 7, },
                new Projector() {projector_id = "UMC-PJ0010", projector_name = "UMC-PJ0010", is_empty = false, position = 8, },
                new Projector() {projector_id = "Empty", projector_name = "Empty", is_empty = true, position = 9, },
            });

            context.Phones.AddRange(new[]
            {
                new Phone() {phone_id = "NotUse", phone_name = "Not Use", is_empty = false, position = 1, },
                new Phone() {phone_id = "PHONE-01", phone_name = "PHONE-01", is_empty = false, position = 2, },
                new Phone() {phone_id = "Empty", phone_name = "Empty", is_empty = true, position = 3, },
            });
        }
       
    }
}