//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Indicate.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Customer
    {
        public Customer()
        {
            this.Lines = new HashSet<Line>();
        }
    
        public string Id_customer { get; set; }
        public string Name_customer { get; set; }
    
        public virtual ICollection<Line> Lines { get; set; }
    }
}
