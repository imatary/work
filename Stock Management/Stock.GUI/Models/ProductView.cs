using System;

namespace Stock.GUI.Models
{
    public class ProductView
    {
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductGroupID { get; set; }
        public string ProductGroupName { get; set; }
        public string StockID { get; set; }
        public string StockName { get; set; }
        public string UnitID { get; set; }
        public string UnitName { get; set; }
        public string SupplierID { get; set; }
        public string SupplierName { get; set; }
        public string Origin { get; set; }
        public int? Quantity { get; set; }
        public DateTime? ExpireDate { get; set; }
        public byte[] Image { get; set; }
        public string Description { get; set; }
        public bool? IsActive { get; set; }
        public long? Price { get; set; } 
    }
}