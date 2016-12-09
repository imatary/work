using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using UMCWorkManager.Models;

namespace UMCWorkManager.ViewModels
{
    public class RoleUserViewModel
    {
        public ApplicationUser ManagerUser { get; set; }
        public IdentityRole Roles { get; set; }
        public IEnumerable<ApplicationUser> ApplicationUsers { get; set; }
    }
}