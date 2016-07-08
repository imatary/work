using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace OQC.Web.Models
{
    public class ApplicationUser
        : IdentityUser<string, ApplicationUserLogin,
            ApplicationUserRole, ApplicationUserClaim>
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid().ToString();
            // Add any custom User properties/code here
        }
        public ApplicationUser(string fullName)
        {
            FullName = fullName;
        }

        public virtual string FullName { get; set; }

        public async Task<ClaimsIdentity>
            GenerateUserIdentityAsync(ApplicationUserManager manager)
        {
            var userIdentity = await manager
                .CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }
    }
}