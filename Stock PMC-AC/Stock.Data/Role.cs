//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Stock.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Role
    {
        public Role()
        {
            this.ControlsToRoles = new HashSet<ControlsToRole>();
            this.UsersToRoles = new HashSet<UsersToRole>();
        }
    
        public int RoleID { get; set; }
        public string RoleName { get; set; }
    
        public virtual ICollection<ControlsToRole> ControlsToRoles { get; set; }
        public virtual ICollection<UsersToRole> UsersToRoles { get; set; }
    }
}
