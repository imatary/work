using System;
using Microsoft.AspNet.Identity.EntityFramework;

namespace OQC.Web.Models
{
    public class ApplicationRole : IdentityRole<string, ApplicationUserRole>
    {
        public ApplicationRole()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public ApplicationRole(string name, string description)
            : this()
        {
            this.Name = name;
            this.Description = description;
        }

        // Add any custom Role properties/code here
        public virtual string Description { get; set; }

    }
}