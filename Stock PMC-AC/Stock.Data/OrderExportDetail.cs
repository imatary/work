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
    
    public partial class OrderExportDetail
    {
        public string OrderExportID { get; set; }
        public string ProductID { get; set; }
        public Nullable<int> Quantity { get; set; }
        public Nullable<long> Price { get; set; }
        public Nullable<long> Total { get; set; }
        public Nullable<bool> IsActive { get; set; }
    
        public virtual OrderExport OrderExport { get; set; }
        public virtual Product Product { get; set; }
    }
}
