using System;

namespace Stock.GUI.Models
{
    public class StockView
    {
        public string StockID { get; set; }
        public string EmployeeID { get; set; }
        public string StockName { get; set; }
        public string Contact { get; set; }
        public string Adress { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string Fax { get; set; }
        public string Mobile { get; set; }
        public string Manager { get; set; }
        public string Description { get; set; }
        public bool? IsActive { get; set; } 
    }
}