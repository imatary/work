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
    
    public partial class ProductGroup
    {
        public ProductGroup()
        {
            this.Products = new HashSet<Product>();
        }
    
        public string ProductGroupID { get; set; }
        public string ProductGroupName { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifyDate { get; set; }
        public string ModifyBy { get; set; }
    
        public virtual ICollection<Product> Products { get; set; }
    }
}
