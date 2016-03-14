//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BarcodeShipping.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Model
    {
        public Model()
        {
            this.PackingPOes = new HashSet<PackingPO>();
            this.Shippings = new HashSet<Shipping>();
            this.tbl_test_log = new HashSet<tbl_test_log>();
        }
    
        public string ModelID { get; set; }
        public string ModelName { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime DateCreated { get; set; }
        public int Quantity { get; set; }
        public string SerialNo { get; set; }
    
        public virtual ICollection<PackingPO> PackingPOes { get; set; }
        public virtual ICollection<Shipping> Shippings { get; set; }
        public virtual ICollection<tbl_test_log> tbl_test_log { get; set; }
    }
}
