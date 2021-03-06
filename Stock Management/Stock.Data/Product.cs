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
    
    public partial class Product
    {
        public Product()
        {
            this.Inventories = new HashSet<Inventory>();
            this.IssueDetails = new HashSet<IssueDetail>();
            this.ReceiptDetails = new HashSet<ReceiptDetail>();
        }
    
        public string ProductID { get; set; }
        public string StockID { get; set; }
        public string UnitID { get; set; }
        public string ProductGroupID { get; set; }
        public string ProductName { get; set; }
        public string Barcode { get; set; }
        public string Origin { get; set; }
        public string TaxCode { get; set; }
        public Nullable<int> Quantiry { get; set; }
        public Nullable<System.DateTime> ExpireDate { get; set; }
        public byte[] ProductImage { get; set; }
        public string Description { get; set; }
        public Nullable<long> Price { get; set; }
        public Nullable<bool> Active { get; set; }
        public string Supplier { get; set; }
        public string Color { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifyDate { get; set; }
        public string ModifyBy { get; set; }
    
        public virtual ICollection<Inventory> Inventories { get; set; }
        public virtual ICollection<IssueDetail> IssueDetails { get; set; }
        public virtual ProductGroup ProductGroup { get; set; }
        public virtual Stock Stock { get; set; }
        public virtual Unit Unit { get; set; }
        public virtual ICollection<ReceiptDetail> ReceiptDetails { get; set; }
    }
}
